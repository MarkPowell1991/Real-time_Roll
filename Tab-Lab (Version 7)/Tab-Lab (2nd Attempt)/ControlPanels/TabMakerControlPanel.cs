using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Threading;
using Pitch;
using NAudio.Wave;
using NAudio.Midi;
using VoiceRecorder.Audio;
using MindFusion.Diagramming;
using MindFusion.Diagramming.WinForms;
using System.Threading;
using System.Windows;
using Tab_Lab__2nd_Attempt_.ControlPanels;



// initially, the notation XAML code was going to be run within the large space on this page. 
// I decided however that it would look a bit cramped however. i left all the ptichtracketr stuff here
// however as the top left label was useful in easily viewing the pitch results for debugging.

    //ive tried to comment out everything thats now redundant on this page however have left in the pitch detection 
    // functionality as it was good for debugging and made the space look less empty

namespace Tab_Lab__2nd_Attempt_
{
    public partial class TabMakerControlPanel : UserControl
    {

        private static TabMakerControlPanel _instance;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private NAudio.Wave.WaveIn sourceStream = null; //creates a seperate source for this control panel
        private NAudio.Wave.WaveOut wOut = null;
        private NAudio.Wave.DirectSoundOut waveOut = null;
        private NAudio.Wave.WaveFileWriter waveWriter = null;
        private SaveFileDialog SFD = new SaveFileDialog();


        Recorder TheRecorder = new Recorder();
        public static Thread PlayNoteThread = null;

        private BufferedWaveProvider buffer;
        List<string> noteList = new List<string>();
        ListViewItem nListView = new ListViewItem();

        private VoiceRecorder.Audio.SampleAggregator sampleAggregator = new SampleAggregator();
     
        private Settings setting = new Settings();

        private Pitch.PitchTracker m_pitchTracker;
        private DispatcherTimer m_timer;
        private float[] m_audioBuffer;
        private int m_timeInterval;
        private float m_sampleRate;
        private float prevPitch = 0.0f;



        private List<float> floatBuffer;

        

        //uses singleton pattern to provide global access to my tab maker page
        public static TabMakerControlPanel instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TabMakerControlPanel();
                return _instance;
            }
        }

        //sets the default option values in case nothing is selected
        private string _title = "Title";
        private int _topSignature = 4 ;
        private int _bottomSignature = 4;

        //allows the selected option values to be retreived alsewhere. They currently have no purpose however 
        public string title { get { return _title; } set { _title = value; } } //get and setters for selecting sheet music options
        public int topSignature { get { return _topSignature; } set { _topSignature = value; } }    //
        public int bottomSignature { get { return _bottomSignature; } set { _bottomSignature = value; } }



        public TabMakerControlPanel()
        {
            m_sampleRate = 44100.0f; //sets up the samplerate as per the standard for most devices
            m_timeInterval = 100;  // the timer will tick once every 100ms           
            InitializeComponent();
      
        }


        //this method sets up the sourcestream, the waveout and the buffer where our sourcestream data will be sent.
        //the devices are set up either as chosen in the settings panel or as the first(and usually only) availuable devices as default
        private void InitializeSound()
        {
            sourceStream = new NAudio.Wave.WaveIn();             
            sourceStream.DeviceNumber = setting.deviceNumber;           // input device number = 0 as default to prevent error. thats also usually the mic when using my PC. need to ensure its the same for my laptop for presentation
            sourceStream.WaveFormat = setting.format;           
            sourceStream.DataAvailable += waveIn_DataAvailable;         // calls method to control what happens to data as it comes in
            waveOut = new NAudio.Wave.DirectSoundOut();                     //creates wave output device
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
                buffer.ClearBuffer(); //this prevents the "buffer full" error i was getting. This would occur after 5 seconds of recording
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


        //sets up the timer
        private void StartTimer()
        {
            m_timer = new DispatcherTimer();
            m_timer.Interval = TimeSpan.FromMilliseconds(m_timeInterval);
            m_timer.Tick += OnTimerTick;
            m_timer.Start();
        }


        string RecordString = "";           //as default, the string of notes are cleared
        bool Recording = false; //as default, the string of notes are not being recorded

        private void startBtn_Click(object sender, EventArgs e) // this button is meant to be where the notes played become listed
        {
            InitializeSound(); // sets up sourcestream, datain event, buffer and waveout for data to be sent

            //the below is all for saving the .wav file as it goes along. come back to later

            //try
            //{
            //    waveWriter = new NAudio.Wave.WaveFileWriter(SFD.FileName, sourceStream.WaveFormat); 
            //    //attempts to create a filewriter using the openfiledialogue path and the sourcesream waveformat

            //    
            //}
            //catch (NullReferenceException) //both these errors occur when no file has been selected
            //{
            //    System.Windows.MessageBox.Show("Please select save file name and location");
            //    return;
            //}
            //catch (ArgumentException)
            //{
            //    System.Windows.MessageBox.Show("Please select save file name and location");
            //    return;
            //}



            try
            {
                sourceStream.StartRecording();
            }
            catch (NAudio.MmException exception) //this error may occur when no input device is connected
            {
                System.Windows.MessageBox.Show("No Input Device available");
            }
            //  waveOut.Play();
            m_pitchTracker = new PitchTracker();                //initilises class for detecting pitch
            m_pitchTracker.SampleRate = m_sampleRate;           // sample rate is set to 44100.0f as standard
        //    m_pitchTracker.PitchDetected += OnPitchDetected;    //
            m_audioBuffer = new float[(int)Math.Round(m_sampleRate * m_timeInterval / 1000.0)];
            StartTimer();
           // UpdateDisplay();
            //we need to initialise the customsheetmusicstaff item here once its done
            //Also call the "fittoscreen" method
            /*StartTimer(); */                      //starts the timer. this was meant as part of the sheetmusic timing indications
            title = titleBox.Text;              //Set the given title name to the title at the top of the sheet music form. 
                                                //SheetMusicForm frm = new SheetMusicForm();      // initialises the sheet music form
                                                //frm.Show();                                     // shows the form

             //  ControlPanels.PianoRoll pRoll = new ControlPanels.PianoRoll();  //this was an experiment to try and create a pianoroll style layout
            ControlPanels.MyPianoRollCreator pRoll = new ControlPanels.MyPianoRollCreator();
            var host = new Window();                                        //xml forms can not be diplayed in the same way normal forms can. they need a "host"
            host.Content = pRoll;                                           //fills that host with the xaml code i produced to draw the pianoroll style form
            host.Show();
            ControlPanels.RollCreaterControls pRollControlls = new ControlPanels.RollCreaterControls();
            //var host2 = new Window();                                        //xml forms can not be diplayed in the same way normal forms can. they need a "host"
            //host2.Content = pRollControlls;                                           //fills that host with the xaml code i produced to draw the pianoroll style form
            //host2.MaxHeight = 92;
            //host2.MaxWidth = 592;
            //host2.WindowStyle = WindowStyle.ToolWindow ;
            //host2.Show();


            RecordString = "";                                              //the string of notes is cleared from last time
            Recording = true;                                               //the notes are being recorded
            stopBtn.Enabled = true;
            // Change Color of button
            composerBtn.BackColor = Color.PowderBlue;

        }

        private void OnTimerTick(object sender, EventArgs e) //every set period of time (i think this is set to 10ms but i may have two timers going on)
        {

            m_pitchTracker.ProcessBuffer(floatBuffer.ToArray()); // the buffer is passed through the pitchtrackers process class. This performs the calculations to determine the pitch etc

            UpdateDisplay();

        }


        private void checkNotePlayed()
        {
            var curPitchRecord = m_pitchTracker.CurrentPitchRecord;

            if (curPitchRecord.Pitch > 1.0f)                        // if a significant value is given 
            {
                //Note_start();
                //note has started 
                //identify note and draw
                //if midi note changes
                //note ended
                //new note has started
                //elseif currpitchrecord.pitch < 1.0f{
                //note has ended
                //}

            }

                //this method will not work as the pitch alters significantly as the same note is being played
                //need to try trigger when frequency has stopped

                //float curPitch = (curPitchRecord.Pitch);                //an attempt to identify that the previous note has ended and a new one has started
                //if (prevPitch != curPitch)          // "if the frequncy has changed since last update,"
                //{
                //    //add note rectangle to canvas
                //    Note_start();
                //    Note_End();
                //}
                //prevPitch = curPitch;               //

            }

        //Before i looked in to using MIDI , i had attempted to create methods that as it turns out, worked the same way.
        //private void Note_start()
        //{
        //    var curPitchRecord = m_pitchTracker.CurrentPitchRecord;
        //    float freq = curPitchRecord.Pitch;
        //    StartDuration = this.TimeInterval;
        //    CurrentFrequency = ((int)freq);
        //}

        //private void Note_End()
        //{
        //    EndDuration = this.TimeInterval;
        //    if (Recording)
        //    {
        //        RecordString = TheRecorder.AddNextNote(CurrentFrequency, (int)(EndDuration - StartDuration));
        //    }
        //}

        private void UpdateDisplay()
        {
            // Show the detector results
            var curPitchRecord = m_pitchTracker.CurrentPitchRecord; // places the current pitch in to the curpitchrecord variable
            var curNote = PitchDsp.GetNoteName(curPitchRecord.MidiNote, true, true);

            if (curPitchRecord.Pitch > 1.0f)                        // if a significant value is given 
            {

                if (curPitchRecord.Pitch >= 1000.0f)                // for the purpose of converting the units from khz to hz
                {
                    pFrequencyValueLbl.Text = (curPitchRecord.Pitch / 1000.0f).ToString("F4"); // converts given value in to khz
                    pFrequencyUnitsLbl.Text = "kHz";                                            // sho9ws that value is in khz
                }
                else                                                                            //if pitch !>= 1000, then it is in hz
                {
                    pFrequencyValueLbl.Text = curPitchRecord.Pitch.ToString("F3");              //no need to convert to khz
                    pFrequencyUnitsLbl.Text = "Hz";                                             // shows that value is in hz
                }
                noteValueLbl.Text = curNote;
                noteList.Add(curNote);
                nListView.SubItems.Add(curNote);

            }
        }

        //more MIDI style attempts

        //int CurrentFrequency = 0;
        //long StartDuration = 0;
        //long EndDuration = 0;

        //private void Note_start()
        //{
        //    var curPitchRecord = m_pitchTracker.CurrentPitchRecord;
        //    int freq = FindFrequency(new Point(e.X, e.Y), out CurrentKey);
        //    float freq = curPitchRecord.Pitch;
        //    StartDuration = this.TimeInterval;
        //    CurrentFrequency = ((int)freq) ;
        //}

        //private void Note_End()
        //{
        //    EndDuration = this.TimeInterval;
        //    if (Recording)
        //    {
        //        RecordString = TheRecorder.AddNextNote(CurrentFrequency, (int)(EndDuration - StartDuration));
        //    }
        //}


        //long TimeInterval = 0;       
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    TimeInterval++;
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (components != null)
        //        {
        //            components.Dispose();
        //        }
        //    }
        //    base.Dispose(disposing);
        //}

        public string QueryString
        {
            get
            {
                return titleBox.Text;
            }

            set
            {
                titleBox.Text = value;
            }
        }

        public string QueryLabel
        {
            set
            {
                songTitleLbl.Text = value;
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            //SaveFileDialog SFD = new SaveFileDialog(); // i need to come back to the stop recording conditions
            //if (Recording == true)
            //{
            //    if (SFD.ShowDialog() == DialogResult.OK)
            //    {
            //        TheRecorder.SaveRecording(SFD.FileName);
            //    }

            //    TheRecorder.Clear();
            //    Recording = false;

            //}

            composerBtn.BackColor = stopBtn.BackColor;
        }

        private void saveSelectBtn_Click(object sender, EventArgs e)
        {
            //SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Wave File (*.wav)| *.wav;";
            if (SFD.ShowDialog() != DialogResult.OK) return;
            fileSaveLocationLbl.Text = SFD.FileName;

        }
    }



    }

