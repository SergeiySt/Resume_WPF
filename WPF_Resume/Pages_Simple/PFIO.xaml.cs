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

namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for PFIO.xaml
    /// </summary>
    public partial class PFIO : Page
    {
        //public event Action NextPageClicked;

        public string Surname { get { return textBoxSurname.Text; } }
        public string UserName { get { return textBoxName.Text; } }
        public string Pobatkovi { get { return textBoxPobatkovi.Text; } }
        public DateTime Date { get { return datePicker.SelectedDate ?? DateTime.MinValue; } }
        public string Adress { get { return textBoxAdress.Text; } }
        public string PhoneNumber { get { return textBoxPhone.Text; } }
        public string Email { get { return textBoxEmail.Text; } }

        public PFIO()
        {
            InitializeComponent();
        }
    }
}
