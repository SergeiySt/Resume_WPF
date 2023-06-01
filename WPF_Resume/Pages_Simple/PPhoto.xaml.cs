using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for PPhoto.xaml
    /// </summary>
    public partial class PPhoto : Page
    {
        public byte[] Picture
        {
            get
            {
                BitmapImage bitmapImage = pictureBox.Source as BitmapImage;
                if (bitmapImage != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        BitmapEncoder encoder;
                        if (bitmapImage.Format == PixelFormats.Pbgra32)
                        {
                            encoder = new PngBitmapEncoder();
                        }
                        else if (bitmapImage.Format == PixelFormats.Pbgra32)
                        {
                            encoder = new JpegBitmapEncoder();
                        }
                        else
                        {
                            return null;
                        }

                        encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                        encoder.Save(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
                return null;
            }
        }
        public PPhoto()
        {
            InitializeComponent();
        }
        private void buttonAddPicture_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                pictureBox.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}
