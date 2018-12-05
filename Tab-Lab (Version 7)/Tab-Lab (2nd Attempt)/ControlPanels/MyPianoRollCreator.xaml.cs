using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Wave;
using NAudio.Midi;
using System.Windows.Threading;
using Pitch;
using Microsoft.Win32;

namespace Tab_Lab__2nd_Attempt_.ControlPanels
{
    /// <summary>
    /// Interaction logic for MyPianoRollCreator.xaml
    /// </summary>
    public partial class MyPianoRollCreator : UserControl
    {

        //XAML & MIDI variables
        private List<int> noteList;
        //  private IEnumerable<NoteOnEvent> NoteOnList;
        private List<NoteOnEvent> NoteOnList;
        double xScale = 1.0 / 10;
        double yScale = 15;
        long lastPosition = 48000;
        long DefinedDeltaTicksPerQuarterNote = 480; //this is manually defined as values are usually definded in MIDI file header and i havent decided how to set them yet
        int noteNumber = 0;
        int previousNoteNumber = 0;
        int notenumberChangeCheck = 0;
        float previousPitchRecord = 0;
        int timeNoteStarted = 0;
        int noteDuration = 0;
        int thisNoteNumber = 0;

        //  long startTime = 0;
        long timePassed = 300;
        int startTime = 0;
        int duration = 0;
        int channel = 2;
        Boolean holdNote = false;
        private RecordControlPanel rcp = new RecordControlPanel();

        //Pitchtracker Variables
        private PitchTracker m_pitchTracker;
        private DispatcherTimer m_timer;
        private float[] m_audioBuffer;
        private float m_sampleRate = 44100.0f;
        private int m_timeInterval = 50;  // 50ms      this conbtrols the process speed of pitchtracker as well as the value of each note in terms of draw space and scroll speed

        //NAudio Variables
        private NAudio.Wave.WaveIn sourceStream = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;
        private BufferedWaveProvider buffer;
        private List<float> floatBuffer;


        //Other
        private Settings setting = new Settings();
        private MidiEvent midiEvent;
        private NoteOnEvent noteOn;

        public MyPianoRollCreator()
        {
            InitializeComponent(); //runs and initialises componenet whenever application is called to run
            CreateBackgroundCanvas();
            DrawGrid();
            DrawNoteLabelTab();
            //you can use this area to set the startup location. can possibly look in to making this run within the main app panel
            rootCanvas.Width = lastPosition * xScale;
            rootCanvas.Height = (84 - 33) * yScale;
            noteScaleTransform.ScaleX = rootCanvas.Width;
        }

        private void InitializeSound()
        {
            sourceStream = new NAudio.Wave.WaveIn();             //sourcestream = wavein
            sourceStream.DeviceNumber = setting.deviceNumber;   // input device number = 0 as default to prevent error. thats also usually the mic when using my PC. need to ensure its the same for my laptop for presentation
            sourceStream.WaveFormat = setting.format;           // 
            sourceStream.DataAvailable += waveIn_DataAvailable; // calls method to control what happens to data as it comes in
                                                                // waveWriter = new NAudio.Wave.WaveFileWriter(SFD.FileName, sourceStream.WaveFormat);
                                                                //  sourceStream.StartRecording();
            waveOut = new NAudio.Wave.DirectSoundOut();                        //creates wave output device
            buffer = new BufferedWaveProvider(sourceStream.WaveFormat);           //initialises buffer in the same format as the wavestream
            waveOut.Init(buffer); //connects the buffer with the output device

        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e) //deals with new data as it goes in to sourcestream
        {
            try
            {
                buffer.AddSamples(e.Buffer, 0, e.BytesRecorded); //adds each sample to the buffer as it is recorded
            }
            catch (InvalidOperationException)
            {
                buffer.ClearBuffer(); //this prevents the "buffer full" error i was getting.
                return;
            }

            floatBuffer = new List<float>();                // initialises a list of float values to represent buffer samples in a format thats easier to handle

            for (int index = 0; index < e.BytesRecorded; index += 2) //
            {
                short sample = BitConverter.ToInt16(e.Buffer, index); //converts each sample from bits to short format
                float sample32 = (float)sample;                         //converts the samples from short to float
                sample32 /= (float)Int16.MaxValue;                      //calculates sample values as a ratio of the max short value
                floatBuffer.Add(sample32);                              //adds that value to the floatbuffer list/buffer
            }
        }

        private void StartTimer()
        {
            m_timer = new DispatcherTimer();
            m_timer.Interval = TimeSpan.FromMilliseconds(m_timeInterval);
            m_timer.Tick += OnTimerTick;
            m_timer.Start();
        }


        private void OnTimerTick(object sender, EventArgs e) //every set period of time
        {
            timePassed += m_timeInterval;
            try
            {
                m_pitchTracker.ProcessBuffer(floatBuffer.ToArray()); // the buffer is passed through the pitchtrackers process class. This performs the calculations to determine the pitch etc
            }

            catch (NullReferenceException) //every now and again, this error would occur randomly as the buffer would try to process before the it had data
            {

                return;
            }
            //    UpdateDisplay();

           


            checkNotePlayed(); //checks once every time to see if a note is being played

            if (timePassed > 48000) // when the time reaches the end of the page, it will just keep extending it and redraw the grid and background
            {
                lastPosition = timePassed + 1000;
                rootCanvas.Width = lastPosition * xScale; // 
                rootCanvas.Height = (84 - 33) * yScale;
                noteScaleTransform.ScaleX = rootCanvas.Width;
                DrawGrid();
                CreateBackgroundCanvas();

            }

        }

        //what defines a noteOn:
        //*note was 0, now has value
        //*note had value, now its a different value


        //what defines a noteOff:
        //note had a value, now its a different value
        //note had value, now it is 0


        //this is where all the decision making happens as to how to deal with the current note being played



        private void checkNotePlayed()
        {
            var curPitchRecord = m_pitchTracker.CurrentPitchRecord;     //curPitchrecord = the current pitch
            noteNumber = m_pitchTracker.CurrentPitchRecord.MidiNote;    //notenumber = the midi note value linked with that pitch



            //this segment corrects the notevalue when it changes in error.

            //if the pitch has changed by less that 1hz, then it pretends the notenumber never changed.
            //this was due to held notes flickering between note values too easily
            if (noteNumber != previousNoteNumber && Math.Abs(curPitchRecord.Pitch - previousPitchRecord) < 1 && previousNoteNumber != 0)
            {
                noteNumber = previousNoteNumber; //then its still the same note as previous. this stops the notes from changing spontaneously
            }
            //not certain i need this bit. come back to it
            //if pitch has changed by more than 1 hz, add the note to the list
            else if (noteNumber != previousNoteNumber && Math.Abs(curPitchRecord.Pitch - previousPitchRecord) >= 1 && previousNoteNumber != 0)
            { //if the pitch has changed more than 1hz and is therefore a different note, add the note to the list
              // noteList.Add(noteNumber);

            }


            //if notevalue was 0 but now has a value
            if (previousNoteNumber < 32 && noteNumber >= 33 && noteNumber <= 84)
            {//a note has been played
                timeNoteStarted = (int)timePassed;
                thisNoteNumber = noteNumber;
                //if a note was being played but now has changed (within range)
            }
            else if (previousNoteNumber >= 33 && previousNoteNumber <= 84 && noteNumber >= 33 && noteNumber <= 84 && noteNumber != previousNoteNumber)
            {//then one note had ended and another begins
             //   noteOn.NoteLength = timePassed - noteOn.AbsoluteTime;
                noteDuration = (int)timePassed - timeNoteStarted;
                CreateNoteOnEvent(timeNoteStarted, noteDuration, thisNoteNumber);
                timeNoteStarted = (int)timePassed;
                thisNoteNumber = noteNumber;

                //if a note had a value but now it has none
            }
            else if (previousNoteNumber >= 33 && previousNoteNumber <= 84 && noteNumber < 33)
            {//the current note had ended
                noteDuration = (int)timePassed - timeNoteStarted;
                CreateNoteOnEvent(timeNoteStarted, noteDuration, thisNoteNumber);
            }

            //we dont want it to wait until the note had finished to start drawing it on so we draw more of the note on as it is being played
            if (noteNumber >= 33 && noteNumber <= 84) //if notes within range, draw it on
            {
                Rectangle rectangle = CreateNoterectangle(noteNumber, timePassed); //creates note rectangle based upon (notenumber, delta time it starts, length of note, channel of note
                NoteCanvas.Children.Add(rectangle);   //adds that rectangle to the notecanvas
                lastPosition = Math.Max(lastPosition, timePassed + 200); //updates lastposition variable to either stay the same or time has passed + 200 (whichever is larger)
                noteNumber = m_pitchTracker.CurrentPitchRecord.MidiNote;

                //Insert code here to do the following
                //* Construct a noteOn event from teh details provided
                //* add note to some form of buffer so it may be saved as a MIDI file later on
            }

            previousPitchRecord = m_pitchTracker.CurrentPitchRecord.Pitch; //stores this pitch so decide if the change is significant enough to be a different note
            previousNoteNumber = noteNumber;  //stores this notenumber so it can be compared in the next notecheck

        }

        //this should be passed the necessary values to create a NoteOn event at the end of each note.
        private NoteOnEvent CreateNoteOnEvent(int time, int length, int noteNumber)
        {
            int channelNumber = 1;
            int noteVelocity = 100;
            noteOn = new NoteOnEvent(time, channelNumber, noteNumber, noteVelocity, length);
            NoteOnList.Add(noteOn);
            return noteOn;
        }


        // the method to draw the note values on the left will look similar to this 
        private void CreateBackgroundCanvas() //draws the dividing horizontal lines between each note on the background canvas
        {
            noteBackgroundCanvas.Children.Clear(); //clears the canvas before redrawing
            for (int note = 0; note < (84 - 33); note++)      //Pitchtracker can only detect from note 33 and my piano only has 84 keys (guitar goes up to note 72)
            { //the below section ensures the "black notes" such as c# or e flat are slightly shaded

                if ((note % 12 == 11) // C# 
                || (note % 12 == 9) // Eb
                || (note % 12 == 6) // F#
                || (note % 12 == 4) // Ab
                || (note % 12 == 2)) // Bb
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = yScale; //uses the y scale to stretch the height of the rectangle acordingly
                                          //  rect.Width = 100;                                              // each standards note value is 1 unit wide
                    rect.Width = noteBackgroundCanvas.Width; // we need to make this extend as long as the song
                    rect.Fill = new SolidColorBrush(Colors.LightGray);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));  //
                    noteBackgroundCanvas.Children.Add(rect);
                }
            }
            for (int note = 0; note < (84 - 33); note++) //this part just draws the lines in between each note
            {
                Line line = new Line();
                line.X1 = 0;
                line.X2 = noteBackgroundCanvas.Width;
                line.Y1 = GetNoteYPosition(note);
                line.Y2 = GetNoteYPosition(note);
                line.Stroke = new SolidColorBrush(Colors.Silver);
                noteBackgroundCanvas.Children.Add(line);
            }
        }

        private double GetNoteYPosition(int noteNumber) 
        {
            double note = noteNumber * yScale;
            return note;
        }


        private void DrawGrid() //this vertical grid is drawn over the top of the background
        { //the grid lines are used to give an indicator of time
            gridCanvas.Children.Clear(); //clears the canvas before redrawing
            int beat = 0; //counts each line from left to right
            for (long n = 0; n < lastPosition; n += DefinedDeltaTicksPerQuarterNote) //draw vertical lines the set distance apart
            {
                Line line = new Line(); 
                line.X1 = n * xScale; //line starts and ends at the same point on the X axis
                line.X2 = n * xScale;
                line.Y1 = 0;          //draw line from the top of the canvas
                line.Y2 = (84 - 33) * yScale;
                // line.Y2 = 128 * yScale;     //line extends to the yscale multiplier defines * the range of notes
                if (beat % 4 == 0) //one line in four is coloured black
                {
                    line.Stroke = new SolidColorBrush(Colors.Black); ; //this draws the skyblue lines used to identify each measure
                }
                else // the rest are coloured crimson
                {
                    line.Stroke = new SolidColorBrush(Colors.Crimson); //this draws the silver lines used to identify each beat
                }
                gridCanvas.Children.Add(line);
                beat++; //counts an extra beat each time this loop is run.
            }
        }


        private void DrawNoteLabelTab()
        {
            NoteLabelCanvas.Children.Clear(); //clears the canvas before redrawing
            int NLCWidth = 75;
            for (int note = 0; note < (84 - 33); note++)
            {
                if ((note % 12 == 11) // C# 
               || (note % 12 == 9) // Eb
               || (note % 12 == 6) // F#
               || (note % 12 == 4) // Ab
               || (note % 12 == 2)) // Bb
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = yScale; //uses the y scale to stretch the height of the rectangle acordingly
                                          //  rect.Width = 100;                                              // each standards note value is 1 unit wide
                    rect.Width = NLCWidth; // make the rectangles the width of the canvas
                    rect.Fill = new SolidColorBrush(Colors.Black);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));
                    NoteLabelCanvas.Children.Add(rect);

                }
                else
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = yScale; //uses the y scale to stretch the height of the rectangle acordingly
                                          //  rect.Width = 100;                                              // each standards note value is 1 unit wide
                    rect.Width = NLCWidth; // we need to make this extend as long as the song
                    rect.Fill = new SolidColorBrush(Colors.White);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));  //
                    NoteLabelCanvas.Children.Add(rect);
                    TextBox noteText = new TextBox();
                    if (note % 12 == 0)
                    {
                        noteText.Text = "C";
                    }
                    else if (note % 12 == 10)
                    {
                        noteText.Text = "D";
                    }
                    else if (note % 12 == 8)
                    {
                        noteText.Text = "E";
                    }
                    else if (note % 12 == 7)
                    {
                        noteText.Text = "F";
                    }
                    else if (note % 12 == 5)
                    {
                        noteText.Text = "G";
                    }
                    else if (note % 12 == 3)
                    {
                        noteText.Text = "A";
                    }
                    else if (note % 12 == 1)
                    {
                        noteText.Text = "B";
                    }
                    noteText.Height = yScale;
                    noteText.Width = (20);
                    noteText.SetValue(Canvas.TopProperty, (GetNoteYPosition(note)));
                    noteText.SetValue(Canvas.LeftProperty, (NLCWidth - noteText.Width));
                    NoteLabelCanvas.Children.Add(noteText);
                }
                NoteLabelCanvas.Width = NLCWidth;
                Line line = new Line();
                line.X1 = NoteLabelCanvas.Width;
                line.X2 = NoteLabelCanvas.Width;
                line.Y1 = 0;
                line.Y2 = (84 - 33) * yScale;
                line.Stroke = new SolidColorBrush(Colors.Black);
                NoteLabelCanvas.Children.Add(line);
                TextBox text = new TextBox();

                if (note % 12 == 11)
                {
                    text.Text = "C#";
                }
                else if (note % 12 == 9)
                {
                    text.Text = "Eb";
                }
                else if (note % 12 == 6)
                {
                    text.Text = "F#";
                }
                else if (note % 12 == 4)
                {
                    text.Text = "Ab";
                }
                else if (note % 12 == 2)
                {
                    text.Text = "Bb";
                }

                text.Height = yScale;
                text.Width = (20);
                text.SetValue(Canvas.TopProperty, (GetNoteYPosition(note)));
                //text.SetValue(Canvas.LeftProperty, ;
                NoteLabelCanvas.Children.Add(text);
                //}

            }

            for (int note = 0; note < (84 - 33); note++) //this part just draws the lines in between each note
            {
                Line line = new Line();
                line.X1 = 0;
                line.X2 = NLCWidth;
                line.Y1 = GetNoteYPosition(note);
                line.Y2 = GetNoteYPosition(note);
                line.Stroke = new SolidColorBrush(Colors.Black);
                NoteLabelCanvas.Children.Add(line);
            }


        }

        private Rectangle CreateNoterectangle(int noteNumber, long currentTime) //fills the note lines being played by drawing small 10 units wide rectangles as the note is being played
        {
            Rectangle rect = new Rectangle();
            rect.Fill = new SolidColorBrush(Colors.DarkBlue);  // changed from lighblue to make it stand out more as outline was making the notes segment every 10s
            rect.Width = 10;
            rect.Height = yScale; //the height of the rectangle matches the height of the note lines
            rect.SetValue(Canvas.TopProperty, (double)(84 - noteNumber) * yScale); //Y position has been reversed to put all low notes at the bottom. (distance from top of canvas
            rect.SetValue(Canvas.LeftProperty, (double)currentTime * xScale); //sets the left of the rectangle to the current time
            return rect;
        }

        private void Stoprecording()
        {
            if (m_timer != null)
            {
                m_timer.Stop();
            }

            {
                if (sourceStream != null)
                {
                    if (waveOut != null) //stops sound from playing and disposes
                    {
                        waveOut.Stop();
                        waveOut.Dispose();
                        waveOut = null;
                    }
                    if (sourceStream != null) //stops sourcestream from recording and disposes
                    {
                        sourceStream.StopRecording();
                        sourceStream.Dispose();
                        sourceStream = null;
                    }

                    return;
                }
            }
        }

       
     

       




        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sourceStream == null)
            {
                InitializeSound(); // sets up sourcestream, dataIn event, buffer and waveout for data to be sent
                timePassed = 300;
            }

            try
            {
                sourceStream.StartRecording();
                StartTimer();
                noteList = new List<int>();
                NoteOnList = new List<NoteOnEvent>();
                waveOut.Play();
            }
            catch (NAudio.MmException exception) //this error may occur when no input device is connected
            {
                System.Windows.MessageBox.Show("No Input Device available");
            }
            catch (InvalidOperationException)
            {

            }
            if (m_pitchTracker == null)
            {
                m_pitchTracker = new PitchTracker();                //initilises class for detecting pitch
                m_pitchTracker.SampleRate = m_sampleRate;           // sample rate is set to 44100.0f as standard
                //  m_pitchTracker.PitchDetected += OnPitchDetected;    //
                m_audioBuffer = new float[(int)Math.Round(m_sampleRate * m_timeInterval / 1000.0)];
            }
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (m_timer == null)
            {
            }
            else
            {
                m_timer.Stop();
                if (sourceStream != null)
                {
                    sourceStream.StopRecording();
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to clear this session?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Stoprecording();
                NoteOnList.Clear();

                
                NoteCanvas.Children.Clear();

            }
            //open mesage box "you sure you want to clear?"
            //if yes - timer reset, canvas's cleared and redrawn(except notes)

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Stoprecording();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "MIDI Files (*.mid)|*.mid|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog().Value)
            {
                //  MidiFile midiFile = new MidiFile(saveFileDialog.FileName);
                //  this.MidiEvents = midiFile.Events;               //the piano roll control MIDI events = same as the selected file


                SaveToFile(saveFileDialog.FileName, NoteOnList);

            }
        }

        public void SaveToFile(string fileName, List<NoteOnEvent> NoteOnList)
        {
            const int MidiFileType = 0;
            const int BeatsPerMinute = 60;
            const int TicksPerQuarterNote = 120;

            const int TrackNumber = 0;
            const int ChannelNumber = 1;

            long absoluteTime = 0;

            var collection = new MidiEventCollection(MidiFileType, TicksPerQuarterNote);

            collection.AddEvent(new TextEvent("Note Stream", MetaEventType.TextEvent, absoluteTime), TrackNumber);
            ++absoluteTime;
            collection.AddEvent(new TempoEvent(CalculateMicrosecondsPerQuaterNote(BeatsPerMinute), absoluteTime), TrackNumber);

            // var patchParser = new PatchParser();
            int patchNumber = 25;

            collection.AddEvent(new PatchChangeEvent(0, ChannelNumber, patchNumber), TrackNumber);

            //  const int NoteVelocity = 100;
            //  const int NoteDuration = 3 * TicksPerQuarterNote / 4; // i need this to reflect the actual time
            const long SpaceBetweenNotes = TicksPerQuarterNote;  // currently irrelevant

            if (NoteOnList != null)
            {
                foreach (var note in NoteOnList)
                {
                    collection.AddEvent(new NoteOnEvent(note.AbsoluteTime, ChannelNumber, note.NoteNumber, note.Velocity, note.NoteLength), TrackNumber);
                    collection.AddEvent(new NoteEvent(note.AbsoluteTime + note.NoteLength, ChannelNumber, MidiCommandCode.NoteOff, note.NoteNumber, 0), TrackNumber);

                    absoluteTime += SpaceBetweenNotes;
                }

                collection.PrepareForExport();
                MidiFile.Export(fileName, collection);
            }
        }

        private static int CalculateMicrosecondsPerQuaterNote(int bpm)
        {
            return 60 * 1000 * 1000 / bpm;
        }

        private void scrollViewerMouse_Move(object sender, RoutedEventArgs e)
        {

        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
