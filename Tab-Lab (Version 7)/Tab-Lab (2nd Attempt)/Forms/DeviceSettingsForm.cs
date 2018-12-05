using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tab_Lab__2nd_Attempt_
{
    public partial class DeviceSettingsForm : Form
    {

        public NAudio.Wave.WaveIn sStream = null; //source
        public NAudio.Wave.DirectSoundOut wOut = null; //sync (directsoundout)
        public NAudio.Wave.WaveFileWriter wWriter = null; //writes source to .wav file

        public DeviceSettingsForm()
        {
            InitializeComponent();
            

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            refresh(sender, e);
        }

        private void deviceSelectBtn_Click(object sender, EventArgs e)
        {

        }

        private void refresh(object sender, EventArgs e)
        {
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }

            inputDeviceList.Items.Clear();

            foreach (var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                inputDeviceList.Items.Add(item);
            }
        }

        private void deviceRefreshBtn_Click(object sender, EventArgs e)
        {
            refresh(sender, e);
        }

        private void outputRefreshBtn_Click(object sender, EventArgs e)
        {
            List<NAudio.Wave.WaveOutCapabilities> outputs = new List<NAudio.Wave.WaveOutCapabilities>();

            for (int i = 0; i < NAudio.Wave.WaveOut.DeviceCount; i++)
            {
                outputs.Add(NAudio.Wave.WaveOut.GetCapabilities(i));
            }

            outputDeviceList.Items.Clear();

            foreach (var output in outputs)
            {

                ListViewItem item = new ListViewItem(output.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, output.Channels.ToString()));
                outputDeviceList.Items.Add(item);
            }
        }

        private void outputSelectBtn_Click(object sender, EventArgs e)
        {
            //plan was to allow choice of output device however currently seems redundant as you can select your output device using windows
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (inputDeviceList.SelectedItems.Count == 0) return; //if 0, exit method
                                                                  // if (sourceStream != null) return;

            int deviceNumber = inputDeviceList.SelectedItems[0].Index; //gets index of selected item

            sStream = new NAudio.Wave.WaveIn(); //source stream constructer
            sStream.DeviceNumber = deviceNumber; //sets device number
            sStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);
            // assigns a standard wave format and retreives capabilities and number of channels of chosen device

            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sStream); //bridges gap between wavein object and directsoundout

            wOut = new NAudio.Wave.DirectSoundOut(); //creates wave output device
            wOut.Init(waveIn); //initialises waveout using wavein

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
