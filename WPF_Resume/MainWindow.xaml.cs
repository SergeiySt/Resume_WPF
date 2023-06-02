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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBegin_Click(object sender, RoutedEventArgs e)
        {
            WChoice wChoice = new WChoice();
            wChoice.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard labelAnimation = FindResource("LabelAnimation") as Storyboard;
            Storyboard imageAnimation = FindResource("ImageAnimation") as Storyboard;
            Storyboard buttonAnimation = FindResource("ButtonAnimation") as Storyboard;

            labelAnimation.Begin(label1);
            labelAnimation.Begin(label2);
            imageAnimation.Begin(pictureBox);
            buttonAnimation.Begin(buttonBegin);
        }
    }
}
