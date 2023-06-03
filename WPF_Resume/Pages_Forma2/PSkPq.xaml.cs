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
    /// Interaction logic for PSkPq.xaml
    /// </summary>
    public partial class PSkPq : Page
    {
        public string Skills { get { return new TextRange(richTextBoxSkills.Document.ContentStart, richTextBoxSkills.Document.ContentEnd).Text; } }
        public string Personal { get { return new TextRange(richTextBoxPersonal.Document.ContentStart, richTextBoxPersonal.Document.ContentEnd).Text; } }
        public PSkPq()
        {
            InitializeComponent();
        }
    }
}
