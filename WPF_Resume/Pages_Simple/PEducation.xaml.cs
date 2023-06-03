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

namespace WPF_Resume.Pages_Simple
{
    /// <summary>
    /// Interaction logic for PEducation.xaml
    /// </summary>
    public partial class PEducation : Page
    {

        public string Education { get { return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text; } }

        public PEducation()
        {
            InitializeComponent();
        }
    }
}
