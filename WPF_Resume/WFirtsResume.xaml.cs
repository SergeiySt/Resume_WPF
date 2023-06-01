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
using WPF_Resume.Pages_Simple;


namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for WFirtsResume.xaml
    /// </summary>
    public partial class WFirtsResume : Window
    {
        AplicationContext db = new AplicationContext();

        UserResume userResume = new UserResume();

        //public event Action NextPageClicked;

        PFIO pFIO = new PFIO();
        PPhoto pPhoto = new PPhoto();
        PEducation pEducation = new PEducation();
        PResult pResult = new PResult();
        public WFirtsResume()
        {
            InitializeComponent();
            mainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainFrame.NavigationService.Navigate(pFIO);
        }

        private void Page1_NextButtonClick()
        {
            userResume.Surname = pFIO.Surname;
            userResume.UserName = pFIO.UserName;
            userResume.Pobatkovi = pFIO.Pobatkovi;
            userResume.Date = pFIO.Date;
            userResume.Adress = pFIO.Adress;
            userResume.PhoneNumber = pFIO.PhoneNumber;
            userResume.Email = pFIO.Email;

            mainFrame.NavigationService.Navigate(pPhoto);
        }

        private void Page2_BackButtonClick()
        {
           
            mainFrame.NavigationService.Navigate(pFIO);
        }

        private void Page2_NextButtonClick()
        {
            userResume.Picture = pPhoto.Picture;
            mainFrame.NavigationService.Navigate(pEducation);
        }

        private void Page3_BackButtonClick()
        {
            mainFrame.NavigationService.Navigate(pPhoto);
        }

        private void Page3_NextButtonClick() 
        {
            mainFrame.NavigationService.Navigate(pResult);
        }

        private void Page4_BackButtonClick()
        {
            mainFrame.NavigationService.Navigate(pEducation);
        }
        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is PPhoto)
            {
                Page2_BackButtonClick();
            }
            
            if (mainFrame.Content is PEducation)
            {
                Page3_BackButtonClick();
            }

             if(mainFrame.Content is PResult)
            {
                Page4_BackButtonClick();
            }
        }
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame.Content is PFIO)
            {
                Page1_NextButtonClick();
            }

            if (mainFrame.Content is PPhoto)
            {
                Page2_NextButtonClick();
            }

            if (mainFrame.Content is PEducation)
            {
                Page3_NextButtonClick();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            CloseApplication(); 
        }
    }
}
