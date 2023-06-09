﻿using System;
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
    /// Interaction logic for PEdEx.xaml
    /// </summary>
    public partial class PEdEx : Page
    {
        public string Education { get { return new TextRange(richTextBoxEducation.Document.ContentStart, richTextBoxEducation.Document.ContentEnd).Text; } }
        public string Experience { get { return new TextRange(richTextBoxExperience.Document.ContentStart, richTextBoxExperience.Document.ContentEnd).Text; } }
        public PEdEx()
        {
            InitializeComponent();
        }
    }
}
