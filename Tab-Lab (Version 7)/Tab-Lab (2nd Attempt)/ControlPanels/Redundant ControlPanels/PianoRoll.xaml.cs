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
using NAudio.Midi;
using NAudio.Utils;
using Tab_Lab__2nd_Attempt_.ControlPanels;
using Microsoft.Win32;

namespace Tab_Lab__2nd_Attempt_.ControlPanels
{
    /// <summary>
    /// Interaction logic for PianoRoll.xaml
    /// </summary>
    public partial class PianoRoll : UserControl
    {
        MidiEventCollection midiEvents; //initialises the MIDI library used to add tracks, start timers etc
        double xScale = 1.0 / 10;
        double yScale = 15;
        long lastPosition = 0;
        private static PianoRoll _instance;

        //deltaticksperquarternotes is an integer value. i beleive its the value given within the MIDI file header which works gives each quarter note a delta time value between 1 and 4

        public static PianoRoll instance // added with the purpose of trying to run this xaml within a panel on the tabmakercontrol panel as opposed to a seperate "xaml form"
        {
            get
            {
                if (_instance == null)
                    _instance = new PianoRoll();
                return _instance;
            }
        }

        public PianoRoll()
        {
            InitializeComponent();
          //  CreateBackgroundCanvas();
        }

        public MidiEventCollection MidiEvents       //deals with the passed in MIDIevents collection (e.g a MIDI file)
        {
        get
            {
                return midiEvents; //returns the midievent object
            }
            set
            {
                // a quarter note is 20 units wide
                xScale = (20.0 / value.DeltaTicksPerQuarterNote); //determines the xscale ratio. 20 units for each quarter note
                midiEvents = value; // value = the properties of the midifile
                NoteCanvas.Children.Clear();

                long lastPosition = 0; //used to keep track of the most current noteposition
                for (int track = 0; track < midiEvents.Tracks; track++) //for every track (instrument section) in the MIDI file
                {
                    foreach (MidiEvent midiEvent in value[track])   //check every midevent within that track
                    {
                        if (midiEvent.CommandCode == MidiCommandCode.NoteOn)    //whenever that event happens to be a note being played,
                        {
                            NoteOnEvent noteOn = (NoteOnEvent)midiEvent;        //fills noteon variable with the noteoneevent details
                            if (noteOn.OffEvent != null)        //in theory, all noteon events should have an end however some midi files contain errors
                            {
                                Rectangle rectangle = MakeNoteRectangle(noteOn.NoteNumber, noteOn.AbsoluteTime, noteOn.NoteLength, noteOn.Channel); //creates note rectangle based upon (notenumber, delta time it starts, length of note, channel of note
                                NoteCanvas.Children.Add(rectangle);   //adds that rectangle to the notecanvas
                                lastPosition = Math.Max(lastPosition, noteOn.AbsoluteTime + noteOn.NoteLength); //updates lastposition variable to either stay the same or notes start delta time + notelength (whichever is larger)
                            }
                        }
                    }
                }
                this.Width = lastPosition * xScale; //changes width of usercontrol in proportion to how much time has passed * the x scaling factor
                this.Height = 128 * yScale;         //changes height to y scale factor * the amount of possible notes
                CreateBackgroundCanvas();
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
                    rect.Width = noteBackgroundCanvas.Width;                                              // each standards note value is 1 unit wide
                    rect.Fill = new SolidColorBrush(Colors.SkyBlue);            //fills the rectangle with skyblue colouring
                    rect.SetValue(Canvas.TopProperty, GetNoteYPosition(note));  //
                    noteBackgroundCanvas.Children.Add(rect);
                }
            }
            for (int note = 0; note < 128; note++) //this part just draws the lines in between each note
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

        private void DrawGrid() //this vertical grid is drawn over the top of the background
        { //the grid lines show where each measure/beat start
            //this method is run after the MIDI file has been loaded however i should draw it before, using the measurements drop down box values
            gridCanvas.Children.Clear(); //clears the canvas before redrawing
            int beat = 0; //how many notes fit in each measure. beat is set to 0
            for (long n = 0; n < lastPosition; n += midiEvents.DeltaTicksPerQuarterNote) //i think ticksperquarrternote refers to the time value given to each quarternote e.g 0.5 seconds
            {//i think this means, for every quarternote in the midifile
                Line line = new Line(); //
                line.X1 = n * xScale; //line starts and ends at the same point on the X axis
                line.X2 = n * xScale;
                line.Y1 = 0;                //draw line from the top of the canvas
                line.Y2 = 128 * yScale;     //line extends to the yscale multiplier defines * the range of notes
                if (beat % 4 == 0) //i assume this means "if beat is a multiple of 4"? although this would imply that each note HAS to be measured in qaurter notes. therefore the top or bottom signature should be preset
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
                foreach (MidiEvent midiEvent in midiEvents[track])
                {
              // create note rectangles
                }
            }
            // the rootcanvas is resized instead of the user control itself as it is the child element of the scrollviewer 
            rootCanvas.Width = lastPosition * xScale; // 
            rootCanvas.Height = 128 * yScale;
            noteScaleTransform.ScaleX = rootCanvas.Width;
        }


        private double GetNoteYPosition(int noteNumber) //i beleive this will need to be taken from the given measurment values in the form. need to figure ouit how they match up however
        {


            double note = midiEvents.DeltaTicksPerQuarterNote / 4; //MIDI files calculate time in "delta time" and so 
            return note;
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
            rect.SetValue(Canvas.TopProperty, (double)(127 - noteNumber) * yScale); //Y position has been reversed to put all low notes at the bottom
            rect.SetValue(Canvas.LeftProperty, (double)startTime * xScale);
            return rect;
        }

        private class NoteBackgroundRenderScaleTransform
        {
        }

        //private void button1_Click(object sender, RoutedEventArgs e)                  //as we are not loading from a file, this part will not be needed however may be useful to see hot the MIDI event interprets a file
        //{
        //    System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
        //    openFileDialog.Filter = "MIDI Files (*.mid)|*.mid|All Files (*.*)|*.*";
        //    openFileDialog.FilterIndex = 1;
        //    if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        MidiFile midiFile = new MidiFile(openFileDialog.FileName);
        //        this.MidiEvents = midiFile.Events;               //the piano roll control MIDI events = same as the selected file
        //    }
        //}

        private void button_1_Click(object sender, RoutedEventArgs e)
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
    }
}
