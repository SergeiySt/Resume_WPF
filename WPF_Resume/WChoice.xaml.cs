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
using System.Windows.Shapes;

namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for WChoice.xaml
    /// </summary>
    public partial class WChoice : Window
    {
        public WChoice()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonSimply.IsChecked == true)
            {
                WFirtsResume wFirtsResume = new WFirtsResume();
                wFirtsResume.Show();
                this.Close();
            }
        }
    }
}
