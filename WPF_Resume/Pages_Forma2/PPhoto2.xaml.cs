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

namespace WPF_Resume.Pages_Forma2
{
    /// <summary>
    /// Interaction logic for PPhoto2.xaml
    /// </summary>
    public partial class PPhoto2 : Page
    {
        public PPhoto2()
        {
            InitializeComponent();
        }

        public ImageSource Picture { get; private set; }
       

        private void buttonAddPicture_Click_1(object sender, RoutedEventArgs e)
        {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".jpg";
                dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    Picture = new BitmapImage(new Uri(filename));
                    pictureBox.Source = Picture;
                }
        }
    }
}
