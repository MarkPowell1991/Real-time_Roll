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
using Tab_Lab__2nd_Attempt_.ControlPanels;

namespace Tab_Lab__2nd_Attempt_.ControlPanels
{
    /// <summary>
    /// Interaction logic for RollCreaterControls.xaml
    /// </summary>
    public partial class RollCreaterControls : UserControl
    {

        MyPianoRollCreator pnrCreator = new MyPianoRollCreator();


        public RollCreaterControls()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
           // pnrCreator.Start();
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            //pnrCreator.Stop();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
