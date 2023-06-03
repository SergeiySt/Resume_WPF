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
            if (IsFieldsFilled2())
            {
                mainFrame2.NavigationService.Navigate(photo2);
            }
            else
            {
                MessageBox.Show("Заповніть всі поля", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void Page2_BackButtonClick()
        {

            mainFrame2.NavigationService.Navigate(pFIO2);
        }

        private void Page2_NextButtonClick()
        {
            if (IsFieldsFilled3())
            {

                mainFrame2.NavigationService.Navigate(pEdEx);
            }
            else
            {
                MessageBox.Show("Завантажте фото", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void Page3_BackButtonClick()
        {

            mainFrame2.NavigationService.Navigate(photo2);
        }

        private void Page3_NextButtonClick()
        {
            if (IsFieldsFilled4())
            {
                mainFrame2.NavigationService.Navigate(pSkPq);
            }
            else
            {
                MessageBox.Show("Заповніть всі поля", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void Page4_BackButtonClick()
        {
            mainFrame2.NavigationService.Navigate(pEdEx);
        }

        private void Page4_NextButtonClick()
        {
            if (IsFieldsFilled5())
            {
                mainFrame2.NavigationService.Navigate(pResult2);
            }
            else
            {
                MessageBox.Show("Заповніть всі поля", "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }
        private void Page5_BackButtonClick()
        {
            mainFrame2.NavigationService.Navigate(pSkPq);
        }

        private void buttonBack2_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame2.Content is PPhoto2)
            {
                Page2_BackButtonClick();
            }
            if (mainFrame2.Content is PEdEx)
            {
                Page3_BackButtonClick();
            }
            if (mainFrame2.Content is PSkPq)
            {
                Page4_BackButtonClick();
            }
            if (mainFrame2.Content is PResult2)
            {
                Page5_BackButtonClick();
            }
        }

        private void buttonNext2_Click(object sender, RoutedEventArgs e)
        {
            if (mainFrame2.Content is PFIO2)
            {
                Page1_NextButtonClick();
            }
            if (mainFrame2.Content is PPhoto2)
            {
                Page2_NextButtonClick();
            }
            if (mainFrame2.Content is PEdEx)
            {
                Page3_NextButtonClick();
            }
            if (mainFrame2.Content is PSkPq)
            {
                Page4_NextButtonClick();
            }
        }

        private bool IsFieldsFilled2()
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

            return true;
        }

        private bool IsFieldsFilled3()
        {

            if (photo2.pictureBox.Source == null)
                return false;
            return true;
        }

        private bool IsFieldsFilled4()
        {

            TextRange textRange = new TextRange(pEdEx.richTextBoxEducation.Document.ContentStart, pEdEx.richTextBoxEducation.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange.Text.Trim()))
                return false;

            TextRange textRange2 = new TextRange(pEdEx.richTextBoxExperience.Document.ContentStart, pEdEx.richTextBoxExperience.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange2.Text.Trim()))
                return false;

            return true;
        }

        private bool IsFieldsFilled5()
        {

            TextRange textRange3 = new TextRange(pSkPq.richTextBoxSkills.Document.ContentStart, pSkPq.richTextBoxSkills.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange3.Text.Trim()))
                return false;

            TextRange textRange4 = new TextRange(pSkPq.richTextBoxPersonal.Document.ContentStart, pSkPq.richTextBoxPersonal.Document.ContentEnd);
            if (string.IsNullOrEmpty(textRange4.Text.Trim()))
                return false;

            return true;
        }

        private void CloseApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
   
        private byte[] ImageToByteArray(ImageSource imageSource)
        {
            BitmapImage bitmapImage = (BitmapImage)imageSource;
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        private void ClearTextBox()
        {
            pFIO2.textBoxSurname.Text = "";
            pFIO2.textBoxName.Text = "";
            pFIO2.textBoxPobatkovi.Text = "";
            pFIO2.datePicker.Text = "";
            pFIO2.textBoxPhone.Text = "";
            pFIO2.textBoxAdress.Text = "";
            pFIO2.textBoxEmail.Text = "";

            photo2.pictureBox.Source = null;

            pEdEx.richTextBoxEducation.Document.Blocks.Clear();
            pEdEx.richTextBoxExperience.Document.Blocks.Clear();

            pSkPq.richTextBoxSkills.Document.Blocks.Clear();
            pSkPq.richTextBoxPersonal.Document.Blocks.Clear();
        }

        private void buttonClose2_Click_1(object sender, RoutedEventArgs e)
        {
            using (AplicationContextForma2 db = new AplicationContextForma2())
            {
                UserResumeForma2 exitUserResume2 = db.UserResumeForma.FirstOrDefault();
                if (exitUserResume2 != null)
                {
                    exitUserResume2.Surname = pFIO2.Surname;
                    exitUserResume2.UserName = pFIO2.UserName;
                    exitUserResume2.Pobatkovi = pFIO2.Pobatkovi;
                    exitUserResume2.Date = pFIO2.Date;
                    exitUserResume2.Adress = pFIO2.Adress;
                    exitUserResume2.PhoneNumber = pFIO2.PhoneNumber;
                    exitUserResume2.Email = pFIO2.Email;

                    exitUserResume2.Picture = photo2.Picture != null ? ImageToByteArray(photo2.Picture) : null;
                    exitUserResume2.Education = pEdEx.Education;
                    exitUserResume2.Experience = pEdEx.Experience;

                    exitUserResume2.Skills = pSkPq.Skills;
                    exitUserResume2.Personal_qualities = pSkPq.Personal;

                    db.SaveChanges();
                }
                else
                {
                    UserResumeForma2 newResume2 = new UserResumeForma2
                    {
                        Surname = pFIO2.Surname,
                        UserName = pFIO2.UserName,
                        Pobatkovi = pFIO2.Pobatkovi,
                        Date = pFIO2.Date,
                        Adress = pFIO2.Adress,
                        PhoneNumber = pFIO2.PhoneNumber,
                        Email = pFIO2.Email,
                        Picture = photo2.Picture != null ? ImageToByteArray(photo2.Picture) : null,
                        Education = pEdEx.Education,
                        Experience = pEdEx.Experience,
                        Skills = pSkPq.Skills,
                        Personal_qualities = pSkPq.Personal,
                    };

                    db.UserResumeForma.Add(newResume2);
                    db.SaveChanges();
                }
            }
            CloseApplication();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (AplicationContextForma2 db = new AplicationContextForma2())
            {
                UserResumeForma2 exitUserResume2 = db.UserResumeForma.FirstOrDefault();
                if (exitUserResume2 != null)
                {
                    exitUserResume2.Surname = pFIO2.Surname;
                    exitUserResume2.UserName = pFIO2.UserName;
                    exitUserResume2.Pobatkovi = pFIO2.Pobatkovi;
                    exitUserResume2.Date = pFIO2.Date;
                    exitUserResume2.Adress = pFIO2.Adress;
                    exitUserResume2.PhoneNumber = pFIO2.PhoneNumber;
                    exitUserResume2.Email = pFIO2.Email;

                    exitUserResume2.Picture = photo2.Picture != null ? ImageToByteArray(photo2.Picture) : null;
                    exitUserResume2.Education = pEdEx.Education;
                    exitUserResume2.Experience = pEdEx.Experience;

                    exitUserResume2.Skills = pSkPq.Skills;
                    exitUserResume2.Personal_qualities = pSkPq.Personal;

                    db.SaveChanges();
                }
                else
                {
                    UserResumeForma2 newResume2 = new UserResumeForma2
                    {
                        Surname = pFIO2.Surname,
                        UserName = pFIO2.UserName,
                        Pobatkovi = pFIO2.Pobatkovi,
                        Date = pFIO2.Date,
                        Adress = pFIO2.Adress,
                        PhoneNumber = pFIO2.PhoneNumber,
                        Email = pFIO2.Email,
                        Picture = photo2.Picture != null ? ImageToByteArray(photo2.Picture) : null,
                        Education = pEdEx.Education,
                        Experience = pEdEx.Experience,
                        Skills = pSkPq.Skills,
                        Personal_qualities = pSkPq.Personal,
                    };

                    db.UserResumeForma.Add(newResume2);
                    db.SaveChanges();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AplicationContextForma2 db = new AplicationContextForma2())
            {
                UserResumeForma2 existingResume2 = db.UserResumeForma.FirstOrDefault();

                if (existingResume2 != null)
                {
                    bool resumeIncomplete = false;

                    pFIO2.textBoxSurname.Text = existingResume2.Surname;
                    pFIO2.textBoxName.Text = existingResume2.UserName;
                    pFIO2.textBoxPobatkovi.Text = existingResume2.Pobatkovi;
                    pFIO2.datePicker.SelectedDate = existingResume2.Date;
                    pFIO2.textBoxAdress.Text = existingResume2.Adress;
                    pFIO2.textBoxPhone.Text = existingResume2.PhoneNumber;
                    pFIO2.textBoxEmail.Text = existingResume2.Email;

                    if (existingResume2.Picture != null)
                    {
                        using (MemoryStream stream = new MemoryStream(existingResume2.Picture))
                        {
                            BitmapImage bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = stream;
                            bitmapImage.EndInit();

                            photo2.pictureBox.Source = bitmapImage;
                        }
                    }
                    else
                    {
                        resumeIncomplete = true;
                    }

                    FlowDocument flowDocument = new FlowDocument();
                    flowDocument.Blocks.Add(new Paragraph(new Run(existingResume2.Education)));
                    pEdEx.richTextBoxEducation.Document = flowDocument;

                    FlowDocument flowDocument2 = new FlowDocument();
                    flowDocument2.Blocks.Add(new Paragraph(new Run(existingResume2.Experience)));
                    pEdEx.richTextBoxExperience.Document = flowDocument2;

                    FlowDocument flowDocument3 = new FlowDocument();
                    flowDocument3.Blocks.Add(new Paragraph(new Run(existingResume2.Skills)));
                    pSkPq.richTextBoxSkills.Document = flowDocument3;


                    FlowDocument flowDocument4 = new FlowDocument();
                    flowDocument4.Blocks.Add(new Paragraph(new Run(existingResume2.Personal_qualities)));
                    pSkPq.richTextBoxPersonal.Document = flowDocument4;

                    //MessageBoxResult result = MessageBox.Show("Бажаєте продовжити попередню роботу?", "Відновлення резюме", MessageBoxButton.YesNo);
                    //if (result == MessageBoxResult.Yes)
                    //{
                    //    mainFrame.NavigationService.Navigate(pEducation);
                    //}
                    MessageBoxResult result;
                    if (resumeIncomplete)
                    {
                        result = MessageBox.Show("Резюме неповне. Бажаєте продовжити наповнення?", "Відновлення резюме", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    }
                    else
                    {
                        // result = MessageBox.Show("Бажаєте продовжити попередню роботу?", "Відновлення резюме", MessageBoxButton.YesNo);
                        result = MessageBox.Show("Бажаєте продовжити попередню роботу?", "Відновлення резюме", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    }

                    if (result == MessageBoxResult.Yes)
                    {
                        if (resumeIncomplete)
                        {
                            mainFrame2.NavigationService.Navigate(pFIO2);
                        }
                        else
                        {
                            mainFrame2.NavigationService.Navigate(pSkPq);
                        }
                    }
                    if (result == MessageBoxResult.No)
                    {
                        ClearTextBox();
                        mainFrame2.NavigationService.Navigate(pFIO2);
                    }
                }
            }
        }
    }
}
