using Microsoft.Win32;
using NAudio.Midi;
using Midi;
using System.Threading;
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
using System.Windows.Threading;
using System.ComponentModel;

namespace Tab_Lab__2nd_Attempt_.ControlPanels
{
    /// <summary>
    /// Interaction logic for MIDIViewer.xaml
    /// </summary>
    public partial class MIDIViewer : UserControl
    {

        MidiEventCollection midiEvents; //initialises the MIDI event library used to add tracks, start timers etc
        private List<NoteOnEvent> NoteOnList;
        private NoteOnEvent noteOn;

        double xScale = 1.0 / 10;
        double yScale = 15;
        long lastPosition = 48000;
        long DefinedDeltaTicksPerQuarterNote = 480; //this is manually defined as values are usually definded in MIDI file header
        private DispatcherTimer m_timer;
        private int m_timeInterval = 10;
        long timePassed = 0;
        private double pointInTime = 0;
        double convertAbsoluteTimeToMilliseconds = 1.0 / 30.0;
        int listCount = 0;

        private BackgroundWorker bw = new BackgroundWorker();
        OutputDevice outputDevice = OutputDevice.InstalledDevices[0] ;


        public MIDIViewer()
        {
            InitializeComponent();
            CreateBackgroundCanvas();
           // DrawGrid();
            DrawNoteLabelTab();
            //you can use this area to set the startup location. can possibly look in to making this run within the main app panel
            rootCanvas.Width = lastPosition * xScale;
            rootCanvas.Height = 128 * yScale;
            noteScaleTransform.ScaleX = rootCanvas.Width;
            // noteScaleTransform.ScaleY = rootCanvas.Height;

            //sets up the background worker thread so my GUI doesnt freeze when playing back MIDI
            bw.WorkerReportsProgress = true; //optional - allows display of playback progress
            bw.WorkerSupportsCancellation = true;   // so i can stop the thread from running
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);     //sets an event handler for what to do while running
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);      //identifies what to do when progress changes
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted); //identifies what to do when thread is completed 

        }


        //some of the example MIDI files i tested actually have about 15-20 tracks however the library method only picks oujt 2 of them, sometimes casuing parts of the song to play all buggy
        public MidiEventCollection MidiEvents       //deals with the passed in MIDIevents collection (e.g a MIDI file)
        {
            get
            {
                return midiEvents; //returns the midievent object
            }
            set
            {
                // a quarter note is 20 units wide
                xScale = (20.0 / value.DeltaTicksPerQuarterNote); //determines the xscale ratio. no units for each
                midiEvents = value; // value = the properties of the midifile
                NoteCanvas.Children.Clear();
                NoteOnList = new List<NoteOnEvent>();
                long lastPosition = 0;
                for (int track = 0; track < midiEvents.Tracks; track++) //for every track in the MIDI file
                {
                    foreach (MidiEvent midiEvent in value[track])   //for each event within that track
                    {
                        if (midiEvent.CommandCode == MidiCommandCode.NoteOn)    //sieves through all MIDI events to find the "noteon" events,
                        {
                            NoteOnEvent noteOn = (NoteOnEvent)midiEvent;        //fills noteon variable with the noteoneevent details
                            if (noteOn.OffEvent != null)        //in theory, all noteon events should have an end however some midi files contain errors
                            {   // the absolutetime offset is to shift notes to the right so they dont overlap the not label column
                                Rectangle rectangle = MakeNoteRectangle(noteOn.NoteNumber, noteOn.AbsoluteTime , noteOn.NoteLength, noteOn.Channel); //creates note rectangle based upon (notenumber, delta time it starts, length of note, channel of note
                                NoteCanvas.Children.Add(rectangle);   //adds that rectangle to the notecanvas
                                NoteOnList.Add(noteOn);
                               // CreateNoteOnEvent((int)noteOn.AbsoluteTime, noteOn.NoteLength, noteOn.NoteNumber);
                                lastPosition = Math.Max(lastPosition, noteOn.AbsoluteTime + noteOn.NoteLength); //updates lastposition variable to either stay the same or notes start delta time + notelength (whichever is larger)
                            }
                        }
                    }
                }
                // this.Width = lastPosition * xScale; //changes width of usercontrol in proportion to how much time has passed * the x scaling factor
                //this.Height = 128 * yScale;         //changes height to y scale factor * the amount of possible notes
                DrawGrid();
            }

        }

        private void CreateBackgroundCanvas() //draws the dividing horizontal lines between each note on the background canvas
        {
            for (int note = 0; note < 128; note++)      //need to determine how many notes my pitchtracker library is capable of detecting
            { //the below section ensures the "black notes" such as c# or e flat are slightly shaded
                if ((note % 12 == 1) // C# 
                 || (note % 12 == 3) // Eb
                 || (note % 12 == 6) // F#
                 || (note % 12 == 8) // Ab
                 || (note % 12 == 10)) // Bb
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = yScale; //uses the y scale to stretch the height of the rectangle acordingly
                    rect.Width = 1;                                              // each standards note value is 1 unit wide
                    rect.Fill = new SolidColorBrush(Colors.SkyBlue);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));  //
                    noteBackgroundCanvas.Children.Add(rect);
                }
            }
            for (int note = 0; note < 128; note++) //this part just draws the lines in between each note
            {
                Line line = new Line();
                line.X1 = 0;
                line.X2 = 1;
                line.Y1 = GetNoteYPosition(note);
                line.Y2 = GetNoteYPosition(note);
                line.Stroke = new SolidColorBrush(Colors.Silver);
                noteBackgroundCanvas.Children.Add(line);
            }
        }

        private void DrawGrid() //this vertical grid is drawn over the top of the background
        { //the grid lines show where each measure/beat start
            //   this method is run after the MIDI file has been loaded however i should draw it before, using the measurements drop down box values
            gridCanvas.Children.Clear(); //clears the canvas before redrawing
            int beat = 0; //how many notes fit in each measure. beat is set to 0
            for (long n = 0; n < lastPosition; n += midiEvents.DeltaTicksPerQuarterNote)
            {
                Line line = new Line(); //
                line.X1 = n * xScale; //line starts and ends at the same point on the X axis
                line.X2 = n * xScale;
                line.Y1 = 0;                //draw line from the top of the canvas
                line.Y2 = 128 * yScale;     //line extends to the yscale multiplier defines * the range of notes
                if (beat % 4 == 0) //1 in every 4 lines
                {
                    line.Stroke = new SolidColorBrush(Colors.SkyBlue); ; //this draws the skyblue lines used to identify each measure
                }
                else
                {
                    line.Stroke = new SolidColorBrush(Colors.Silver); //this draws the silver lines used to identify each beat
                }
                gridCanvas.Children.Add(line);
                beat++; //counts an extra beat each time this loop is run.
            }
        }


        //draws notes on to the notecanvas.
        private void DrawNotes()
        {
            NoteCanvas.Children.Clear(); //clears canvas before drawing

            NoteCanvas.Children.Add(MakeNoteRectangle(0, 0, midiEvents.DeltaTicksPerQuarterNote, 0)); //draws note rectangles on to the notecanvas
            for (int track = 0; track < midiEvents.Tracks; track++)
            {
                //foreach (MidiEvent midiEvent in midiEvents[track])
                //{
                //    //       create note rectangles
                //}
            }
            //  the rootcanvas is resized instead of the user control itself as it is the child element of the scrollviewer
            rootCanvas.Width = lastPosition * xScale; // 
            rootCanvas.Height = 128 * yScale;
            noteScaleTransform.ScaleX = rootCanvas.Width;
        }


        private double GetNoteYPosition(int noteNumber) 
        {
            double note = 0;
            if (midiEvents != null) //if a MIDI file has been loaded
            {
                note = midiEvents.DeltaTicksPerQuarterNote / 4; //MIDI files calculate time in "delta time" and so 
            }
            else
            {
                note = noteNumber * yScale;
            }
            return note;
        }


        //MIDI notes range between 0 - 128
        private void DrawNoteLabelTab()
        {
            NoteLabelCanvas.Children.Clear(); //clears the canvas before redrawing
            int NLCWidth = 75;
            for (int note = 0; note < 128; note++)
            {
                if ((note % 12 == 1) // C# 
                 || (note % 12 == 3) // Eb
                 || (note % 12 == 6) // F#
                 || (note % 12 == 8) // Ab
                 || (note % 12 == 10)) // Bb
                {
                    Rectangle rect = new Rectangle();
                    rect.Height = yScale; //uses the y scale to stretch the height of the rectangle acordingly
                    //  rect.Width = 100;                                              // each standards note value is 1 unit wide
                    rect.Width = NLCWidth; // we need to make this extend as long as the song
                    rect.Fill = new SolidColorBrush(Colors.Black);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));  //
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
                    // if ((note % 12 == 1) // C# 
                    //|| (note % 12 == 3) // Eb
                    //|| (note % 12 == 6) // F#
                    //|| (note % 12 == 8) // Ab
                    //|| (note % 12 == 10)) // Bb
                    if (note % 12 == 4)
                    {
                        noteText.Text = "C";
                    }
                    else if (note % 12 == 2)
                    {
                        noteText.Text = "D";
                    }
                    else if (note % 12 == 0)
                    {
                        noteText.Text = "E";
                    }
                    else if (note % 12 == 11)
                    {
                        noteText.Text = "F";
                    }
                    else if (note % 12 == 9)
                    {
                        noteText.Text = "G";
                    }
                    else if (note % 12 == 7)
                    {
                        noteText.Text = "A";
                    }
                    else if (note % 12 == 5)
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
                line.Y2 = 128 * yScale;
                line.Stroke = new SolidColorBrush(Colors.Black);
                NoteLabelCanvas.Children.Add(line);
                TextBox text = new TextBox();

                //if ((note % 12 == 1) // C# 
                //|| (note % 12 == 3) // Eb
                //|| (note % 12 == 6) // F#
                //|| (note % 12 == 8) // Ab
                //|| (note % 12 == 10)) // Bb

                if (note % 12 == 3)
                {
                    text.Text = "C#";
                }
                else if (note % 12 == 1)
                {
                    text.Text = "Eb";
                }
                else if (note % 12 == 10)
                {
                    text.Text = "F#";
                }
                else if (note % 12 == 8)
                {
                    text.Text = "Ab";
                }
                else if (note % 12 == 6)
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
        }


        private void DrawTimeIndicatorCanvas()
        {
            TimeIndicatorCanvas.Children.Clear();
            Line line = new Line();
            line.X1 = (pointInTime ) ;
            line.X2 = (pointInTime ) + 1;

            line.Y1 = 0;
            line.Y2 = 128 * yScale;
            line.Stroke = new SolidColorBrush(Colors.Black);
            TimeIndicatorCanvas.Children.Add(line);
        }

        private void StartTimer()
        {
            m_timer = new DispatcherTimer();
            
            m_timer.Interval = TimeSpan.FromMilliseconds(m_timeInterval);
            m_timer.Tick += OnTimerTick;
            m_timer.Start();
            //timeerOn = true;
        }

        private void OnTimerTick(object sender, EventArgs e) //once over 10ms after play is clicked
        {
            try
            {
            timePassed += m_timeInterval;  //count up the time
            DrawTimeIndicatorCanvas();      //redraw the time indicator line
            pointInTime = (timePassed * xScale) ;

                if (timePassed == NoteOnList[listCount].AbsoluteTime)
                {
                    noteOn = new NoteOnEvent(NoteOnList[listCount].AbsoluteTime, NoteOnList[listCount].Channel, NoteOnList[listCount].NoteNumber, NoteOnList[listCount].Velocity, NoteOnList[listCount].NoteLength);
                    PlayNote(noteOn.NoteNumber, noteOn.NoteLength);
                    //  pointInTime = (noteOn.AbsoluteTime * xScale) + 168 ;

                    //  (double)startTime * xScale)
                    listCount++;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                listCount = 0;
            }
            catch (NullReferenceException)
            {
                m_timer.Stop();
                outputDevice.Close();
            }

        }

        private Rectangle MakeNoteRectangle(int noteNumber, long startTime, int duration, int channel)
        {
            Rectangle rect = new Rectangle();
            if (channel == 10) //channel 10 is the MIDI convention for drums and is given a different colour + normalised lengths
            {
                rect.Stroke = new SolidColorBrush(Colors.DarkGreen);
                rect.Fill = new SolidColorBrush(Colors.LightGreen);
                duration = midiEvents.DeltaTicksPerQuarterNote / 4; //duration is overwritten as all drum beats have a set duration
            }
            else // for all normal notes
            {
                rect.Stroke = new SolidColorBrush(Colors.DarkBlue); //  a darkblue outline
                rect.Fill = new SolidColorBrush(Colors.LightBlue);  // with a lighblue fill
            }
            rect.Width = (double)duration * xScale; // width = legth in MIDI ticks * scale factor
            rect.Height = yScale; //the height of the rectangle is currently 15 unis
            rect.SetValue(Canvas.TopProperty, (double)((127 - noteNumber ) * yScale) + 5); //Y position has been reversed to put all low notes at the bottom
            rect.SetValue(Canvas.LeftProperty, (double)startTime * xScale);
            return rect;
        }

        //private class NoteBackgroundRenderScaleTransform
        //{
        //}

        public void PlayNote(int key, double duration)
        {
            Midi.Pitch Note = ((Midi.Pitch[])Enum.GetValues(typeof(Midi.Pitch)))[key + 21];           
            outputDevice.SendNoteOn(Channel.Channel1, Note, 80);
            Thread.Sleep((int)duration);
            
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            PlayNote(noteOn.NoteNumber, noteOn.NoteLength);

            //for (int track = 0; track < midiEvents.Tracks; track++) //for every track in the MIDI file
            //{
            //    //if ((worker.CancellationPending == true))
            //    //{
            //    //    e.Cancel = true;
            //    //    break;
            //    //}
            //    foreach (MidiEvent midiEvent in this.midiEvents[track])   //checks each track for all MIDI events within
            //    {
                   
            //        if (midiEvent.CommandCode == MidiCommandCode.NoteOn)    //sieves through all MIDI events to find the "noteon" events,
            //        {
            //            NoteOnEvent noteOn = (NoteOnEvent)midiEvent;        //fills noteon variable with the noteoneevent details
            //            //while (noteOn.AbsoluteTime == timePassed)
            //            //{
            //                if (noteOn.OffEvent != null)        //in theory, all noteon events should have an end however some midi files contain errors
            //                {
            //                    if ((worker.CancellationPending == true))
            //                    {
            //                        e.Cancel = true;
            //                        break;
            //                    }
            //                    PlayNote(noteOn.NoteNumber, noteOn.NoteLength);
            //                    worker.ReportProgress(((int)noteOn.AbsoluteTime));
            //                    pointInTime = noteOn.AbsoluteTime + 1000;
            //                }
            //            //}
            //        }
            //        else if (midiEvent.CommandCode == MidiCommandCode.StopSequence)
            //        {

            //            bw.CancelAsync();
            //         //   return;
            //        }
            //    }
                
            //}

            //for (int i = 1; (i <= 10); i++)
            //{
            //    if ((worker.CancellationPending == true))
            //    {
            //        e.Cancel = true;
            //        break;
            //    }
            //    else
            //    {
            //        // Perform a time consuming operation and report progress.
            //        System.Threading.Thread.Sleep(500);
            //        worker.ReportProgress((i * 10));
            //    }
            //}
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            outputDevice.Close();
            if ((e.Cancelled == true))
            {
                this.tbProgress.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                this.tbProgress.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.tbProgress.Text = "Done!";
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tbProgress.Text = (e.ProgressPercentage.ToString()  ); // +"/" + this.midiEvents.
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MIDI Files (*.mid)|*.mid|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog().Value)
            {
                MidiFile midiFile = new MidiFile(openFileDialog.FileName);
                this.MidiEvents = midiFile.Events;               //the piano roll control MIDI events = same as the selected file
            }
        }

       

        //somewhere, the timer will need to be calibrated with the speed of the song to ensure the timeline indicator matches up
        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            if (outputDevice.IsOpen != true)
            {
                outputDevice.Open();
                timePassed = 0;
            }
            try
            {

                StartTimer();
                 if (m_timer != null)
                    {
                        timePassed = 0;
                    }
                    else if (m_timer == null)
                    {
                        timePassed = 0;
                        StartTimer();
                    }

                //was contemplating running the play function from a seperate thread
                // this would hopefully make the timeindicater run smoother and less juddery on notes.
                    //if (bw.IsBusy != true) //if the workerthread isnt busy, run it
                    //{
                    //    //bw.RunWorkerAsync();
                    //}

                    int trackAmount = midiEvents.Tracks;
 

            }
            catch (NAudio.MmException exception) //this error may occur when no input device is connected
            {
                System.Windows.MessageBox.Show("No Input Device available");
            }
            catch (NullReferenceException)
            {
                System.Windows.MessageBox.Show("Please select a file to play");
            }


            //try
            //{
            //    try
            //    {
            //        outputDevice.Open();
            //    }
            //    catch (InvalidOperationException)
            //    {

            //    }
                    
            //        if (m_timer != null)
            //        {
            //            timePassed = 0;
            //        }
            //        else if (m_timer == null)
            //        {
            //            timePassed = 0;
            //            StartTimer();
            //        }

            //        if (bw.IsBusy != true) //if the workerthread isnt busy, run it
            //        {
            //            //bw.RunWorkerAsync();
            //        }

            //        int trackAmount = midiEvents.Tracks;
                
            //}
            //catch (NullReferenceException)
            //{
            //    System.Windows.MessageBox.Show("Please select a MIDI file to enable playback");
            //    return;
            //}
           


           
        }
    
     
        

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (m_timer == null)
            {
            }
            else
            {
                m_timer.Stop();
                if (outputDevice.IsOpen == true)
                {
                    outputDevice.Close();
                }
            }

            //if (bw.WorkerSupportsCancellation == true)
            //{
            //    bw.CancelAsync();
            //}

            //MIDIplaying = false;
        }

    }
}
