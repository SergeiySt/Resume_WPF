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
using WPF_Resume.Pages_Forma2;
using WPF_Resume.Pages_Simple;

namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for WSecondForm.xaml
    /// </summary>
    public partial class WSecondForm : Window
    {
        UserResumeForma2 userResumeForma2 = new UserResumeForma2();

        PFIO2 pFIO2 = new PFIO2();
        PPhoto2 photo2 = new PPhoto2();
        PEdEx pEdEx = new PEdEx();
        PSkPq pSkPq = new PSkPq();
        PResult2 pResult2 = new PResult2();

        public WSecondForm()
        {
            InitializeComponent();

            mainFrame2.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainFrame2.NavigationService.Navigate(pFIO2);
        }

        private void Page1_NextButtonClick()
        {
            mainFrame2.NavigationService.Navigate(photo2);
        }

        private void Page2_BackButtonClick()
        {

            mainFrame2.NavigationService.Navigate(pFIO2);
        }

        private void Page2_NextButtonClick()
        {

            mainFrame2.NavigationService.Navigate(pEdEx);
        }

        private void Page3_BackButtonClick()
        {

            mainFrame2.NavigationService.Navigate(photo2);
        }

        private void Page3_NextButtonClick()
        {

            mainFrame2.NavigationService.Navigate(pSkPq);
        }

        private void Page4_BackButtonClick()
        {
            mainFrame2.NavigationService.Navigate(pEdEx);
        }

        private void Page4_NextButtonClick()
        {

            mainFrame2.NavigationService.Navigate(pResult2);
        } 
        private void Page5_BackButtonClick()
        {
            mainFrame2.NavigationService.Navigate(pSkPq);
        }

        private void buttonBack2_Click(object sender, RoutedEventArgs e)
        {
            if(mainFrame2.Content is  PPhoto2)
                {
                    Page2_BackButtonClick();
                }
            if(mainFrame2.Content is PEdEx) 
            {
                Page3_BackButtonClick();
            }
            if (mainFrame2.Content is PSkPq)
            {
                Page4_BackButtonClick();
            }
            if(mainFrame2.Content is PResult2)
            {
                Page5_BackButtonClick();
            }
        }

        private void buttonNext2_Click(object sender, RoutedEventArgs e)
        {
            if(mainFrame2.Content is PFIO2) 
            {
                Page1_NextButtonClick();
            }
            if(mainFrame2.Content is PPhoto2)
            {
                Page2_NextButtonClick();
            } 
            if(mainFrame2.Content is PEdEx)
            {
                Page3_NextButtonClick();
            }
            if(mainFrame2.Content is PSkPq)
            {
                Page4_NextButtonClick();
            }
        }

        private bool IsFieldsFilled()
        {

            if (string.IsNullOrEmpty(pFIO2.textBoxSurname.Text))
                return false;

            if (string.IsNullOrEmpty(pFIO2.textBoxName.Text))
                return false;

            if (string.IsNullOrEmpty(pFIO2.textBoxPobatkovi.Text))
                return false;

            if (string.IsNullOrEmpty(pFIO2.textBoxAdress.Text))
                return false;

            if (pFIO2.datePicker.SelectedDate == null)
                return false;

            if (string.IsNullOrEmpty(pFIO2.textBoxPhone.Text))
                return false;

            if (string.IsNullOrEmpty(pFIO2.textBoxEmail.Text))
                return false;


            if (photo2.pictureBox.Source == null)
                return false;

            TextRange textRange = new TextRange(pEdEx.richTextBoxEducation.Document.ContentStart, pEdEx.richTextBoxEducation.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange.Text.Trim()))
                return false;

            TextRange textRange2 = new TextRange(pEdEx.richTextBoxExperience.Document.ContentStart, pEdEx.richTextBoxExperience.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange2.Text.Trim()))
                return false;

            TextRange textRange3 = new TextRange(pSkPq.richTextBoxSkills.Document.ContentStart, pSkPq.richTextBoxSkills.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange3.Text.Trim()))
                return false;

            TextRange textRange4 = new TextRange(pSkPq.richTextBoxPersonal.Document.ContentStart, pSkPq.richTextBoxPersonal.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange4.Text.Trim()))
                return false;

            return true;
        }
    }
}
