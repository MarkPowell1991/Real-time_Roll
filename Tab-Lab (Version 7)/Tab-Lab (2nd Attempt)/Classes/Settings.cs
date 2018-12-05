using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tab_Lab__2nd_Attempt_
{
    class Settings
    {

        // This class is generally used to store all the getters and setters that may be needed
        //to pass values in between forms/classes

        private NAudio.Wave.WaveFormat _format = new NAudio.Wave.WaveFormat();
        NAudio.Wave.WaveInCapabilities _capabilities = new NAudio.Wave.WaveInCapabilities();

        private int _inDeviceNumber = 0;
        private int _outDeviceNumber = 0;
        private string _productName = null;
        private string _outputName = null;

        public string ProductName
        {
            get
            {
                _productName = NAudio.Wave.WaveIn.GetCapabilities(_inDeviceNumber).ProductName;
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }

        public string outputName
        {
            get
            {
                _outputName = NAudio.Wave.WaveOut.GetCapabilities(_outDeviceNumber).ProductName;
                return _outputName;
            }
            set
            {
                _outputName = value;
            }
        }

        public int deviceNumber { get { return _inDeviceNumber; } set { _inDeviceNumber = value; } }
        public int outDeviceNumber { get { return _outDeviceNumber; } set { _outDeviceNumber = value; } }
        public NAudio.Wave.WaveFormat format { get { return _format; } set { _format = value; } }
    }
}
