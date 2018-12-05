using System;
using System.Collections.Generic;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tab_Lab__2nd_Attempt_
{
    public partial class SettingsControlPanel : UserControl
    {

        //this dynamic panel layout was intended to be used to edit any settings that may effect the
        //application such as the input device, output device, default save location etc. I decided 
        //many of these seetting were unnecessary as they are controlled using windows anyway. There is still
        //the ability to select the input devices from a list however

        private static SettingsControlPanel _instance;
        private Settings setting = new Settings();

        int deviceNumber = new int() ; //gets selected item index from list


        //uses singleton pattern to provide global access to my setting page
        public static SettingsControlPanel instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SettingsControlPanel();
                return _instance;
            }
        }


        public SettingsControlPanel()
        {
            InitializeComponent();
            bufferSaveTextBox.Text = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //the buffersave stuff was all about a buffer full error i was getting when trying to record to sourcestream.
            //i read online it was due to the buffer not being emptied anywhere so i tried setting up an auto save file
            //to dump the buffer contents as a temporary measure.
        }

        //refreshes the input list contents with list of availuable input devices
        private void refreshInputs(object sender, EventArgs e)
        {

            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>(); //list containing all the aviluable inputs and their properties

            //for every device availuablew, add it to the sourceslist
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

        //refreshes the output list contents with list of availuable input devices. works the same as for the output devices
        private void refreshOutputs(object sender, EventArgs e)
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



        private void applyButton_Click(object sender, EventArgs e)
        {
            if (inputDeviceList.SelectedItems.Count == 0 && outputDeviceList.SelectedItems.Count == 0) return; //if no item selected, exit method

            if (inputDeviceList.SelectedItems.Count != 0)
            {
                setting.deviceNumber = inputDeviceList.SelectedItems[0].Index;
            }
            if (outputDeviceList.SelectedItems.Count != 0)
            {
                setting.outDeviceNumber = outputDeviceList.SelectedItems[0].Index;
            }

            setting.format = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);           

        }

        
        private void bufferSaveLocEditBtn_Click(object sender, EventArgs e)
        {

        }

        private void refreshInputsButton_Click(object sender, EventArgs e)
        {
            refreshInputs(sender, e);
        }

        private void refreshOutputsButton_Click(object sender, EventArgs e)
        {
            refreshOutputs(sender, e);
        }

    }
}
