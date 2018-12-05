using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tab_Lab__2nd_Attempt_
{
    public partial class RecordControlPanel : UserControl
    {

        private static RecordControlPanel _instance;

        private NAudio.Wave.WaveIn sourceStream = null; //creates a seperate source for this control panel
        private NAudio.Wave.DirectSoundOut waveOut = null; // controls where the data goes e.g speakers
        private NAudio.Wave.WaveFileReader wFileReader = null;
        private NAudio.Wave.WaveFileWriter waveWriter = null;
        private Settings setting = new Settings();

        private Boolean isRecording = false; 

        //uses singleton pattern to provide global access to my recording page
        public static RecordControlPanel instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RecordControlPanel();
                return _instance;
            }
        }


        public RecordControlPanel()
        {
            InitializeComponent();
            inDeviceLbl.Text = setting.ProductName;
            outDeviceLbl.Text = setting.outputName;
        }

        //The record button can be used to stop/start recording
        private void recordButton_Click(object sender, EventArgs e)
        {
            //if its already recording, it will stop recording
            if (isRecording == true) 
            {
                DisposeWave();
                stopRecording();
            }
            else if (isRecording == false) //it will start recording if not recording already
            {
                //sets up the sourcestream, ready for recording
                sourceStream = new NAudio.Wave.WaveIn();    
                sourceStream.DeviceNumber = setting.deviceNumber;
                sourceStream.WaveFormat = setting.format;

                //requests where to save files BEFORE recording has started.
                //i contemplated requesting filepath/name after recording but it was of low priority.
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Wave File (*.wav)|*.wav;";
                if (save.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                filePathLbl.Text = save.FileName;

                //creates a wavefilewriter to write the sourcestream data in to the savefile
                waveWriter = new NAudio.Wave.WaveFileWriter(save.FileName, sourceStream.WaveFormat);
                NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream); //bridges gap between wavein object and directsoundout

                waveOut = new NAudio.Wave.DirectSoundOut(); //creates wave output device
                waveOut.Init(waveIn); //sets the waveout device up to receive sourcestream data

                sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(SourceStream_DataAvailuable); //creates an event handler to deal with data as it is received in to the sourcestream

                sourceStream.StartRecording(); //instructs source to start retreiving samples from audio device
                isRecording = true; //impacts the effects next time the record button is pressed
                waveOut.Play(); //begins playback from buffer
            }
        }

        //this ensures that all resources are correctly  closed and disposed of when recording is stopped
        private void stopRecording()
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
                if (waveWriter != null)
                {
                    waveWriter.Dispose();
                    waveWriter = null;
                }
                isRecording = false;
                return;
            }
        }

        
        private void stopBtn_Click(object sender, EventArgs e) //stop button
        {
            
            waveOut.Stop(); //stoprecording only happens when sourcestream != null. That doesnt effect only playing a .wav file
            stopRecording();
            
        }

        //what happens when the sourcestream receives data
        private void SourceStream_DataAvailuable(object sender, NAudio.Wave.WaveInEventArgs e)
        {
            if (waveWriter == null) return; //exit method if wavewriter hasnt been set up yet

            waveWriter.Write(e.Buffer, 0, e.BytesRecorded); //write the contents to the savefile using the wavewriter
            waveWriter.Flush(); //flush the wavewriters contents after
        }

        //allows the user to playback recorded .wav files or use it as a media player
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Wave File (*.wav)|*.wav;";
            if (open.ShowDialog() != DialogResult.OK) return;
            filePathLbl.Text = open.FileName;
            DisposeWave(); //clears the wavefilereader of any previous contents and disposes of the waveout device

            // sets the wavefile reader and waveout up afresh using the contents of the newly selected file
            wFileReader = new NAudio.Wave.WaveFileReader(open.FileName); 
            waveOut = new NAudio.Wave.DirectSoundOut();
            waveOut.Init(new NAudio.Wave.WaveChannel32(wFileReader));

            //The rest of this method was an attempt at creating a waveViewer object in the large open white space using a graph
            // to plot the points of each sample.

            //NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));
            //automatically converts format to get 32bit floating point number of wave file

            //converts from byte array to a floating pint number
            //byte[] buffer = new byte[16384]; //read 16kb at a time from wav file
            //int read = 0; //number of bytes read

            //while (wave.Position < wave.Length) //do until end of wave file
            //{
            //    read = wave.Read(buffer, 0, 16384); //reading from byte buffer, from beginning, read all bytes in buffer
            //    for (int i = 0; i < read / 4; i++) // 4 bytes per floating point number
            //    {
            //     //   waveViewChart.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 4)); 
            //        //add point to chart from converted bit to 32bit floating point number
            //        //uses the buffer as byte array and 1 * 4 as the index point from buffer in which to read
            //    }
            //}
        }


        private void playBtn_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Paused || waveOut.PlaybackState == NAudio.Wave.PlaybackState.Stopped) waveOut.Play();
            }
            //if recording is paused, continue recording from where it was
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) waveOut.Pause();
                
            }
            //pause recording position if recording
        }



        private void DisposeWave()
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing) waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
            if (wFileReader != null)
            {
                wFileReader.Dispose();
                wFileReader = null;
            }
        }

        private void Application_Close(object sender, FormClosingEventArgs e)
        {
            DisposeWave();
        }

        //apparently Naudio doesnt support the voume function it supplies you with and so ive disabled the voume changer
        //private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        //{
        //    waveOut.Volume = volumeTrackBar.Value;
            
        //}
    }
}
