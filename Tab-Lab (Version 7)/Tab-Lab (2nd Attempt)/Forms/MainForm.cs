using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;



namespace Tab_Lab__2nd_Attempt_
{
    public partial class MainForm : Form
    {

      //  private NAudio.Wave.WaveIn sourceStream = null; //source
      //  private NAudio.Wave.DirectSoundOut waveOut = null; //sync (directsoundout)
      //  private NAudio.Wave.WaveFileWriter waveWriter = null; //writes source to .wav file
        

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void devicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeviceSettingsForm frm = new DeviceSettingsForm();
            frm.Show();
        }



        private void menuRecordBtn_Click(object sender, EventArgs e)
        {
            if (!mainDynamicPanel.Controls.Contains(RecordControlPanel.instance))
                {
                mainDynamicPanel.Controls.Add(RecordControlPanel.instance);
                RecordControlPanel.instance.Dock = DockStyle.Fill;
                RecordControlPanel.instance.BringToFront();
            }
            else
                RecordControlPanel.instance.BringToFront();
        }

        private void menuSettingsBtn_Click(object sender, EventArgs e)
        {
            if (!mainDynamicPanel.Controls.Contains(SettingsControlPanel.instance))
            {
                mainDynamicPanel.Controls.Add(SettingsControlPanel.instance);
                SettingsControlPanel.instance.Dock = DockStyle.Fill;
                SettingsControlPanel.instance.BringToFront();
                SettingsControlPanel.instance.Refresh();
            }
            else
                SettingsControlPanel.instance.BringToFront();
        }

        private void tabMakerBtn_Click(object sender, EventArgs e)
        {
            if (!mainDynamicPanel.Controls.Contains(TabMakerControlPanel.instance))
            {
                mainDynamicPanel.Controls.Add(TabMakerControlPanel.instance);
                TabMakerControlPanel.instance.Dock = DockStyle.Fill;
                TabMakerControlPanel.instance.BringToFront();
                TabMakerControlPanel.instance.Refresh();
            }
            else
                TabMakerControlPanel.instance.BringToFront();
        }

        private void MIDIViewBtn_Click(object sender, EventArgs e)
        {
            ControlPanels.MIDIViewer mView = new ControlPanels.MIDIViewer();
            var host = new Window();                                        //xml forms can not be diplayed in the same way normal forms can. they need a "host"
            host.Content = mView;                                           //fills that host with the xaml code i produced to draw the pianoroll style form
            host.Show();
        }
    }
}
