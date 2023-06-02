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
using WPF_Resume.Pages_Simple;


namespace WPF_Resume
{
    /// <summary>
    /// Interaction logic for WFirtsResume.xaml
    /// </summary>
    public partial class WFirtsResume : Window
    {
        //AplicationContext db = new AplicationContext();

        UserResume userResumes = new UserResume();

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
            userResumes.Surname = pFIO.Surname;
            userResumes.UserName = pFIO.UserName;
            userResumes.Pobatkovi = pFIO.Pobatkovi;
            userResumes.Date = pFIO.Date;
            userResumes.Adress = pFIO.Adress;
            userResumes.PhoneNumber = pFIO.PhoneNumber;
            userResumes.Email = pFIO.Email;

            mainFrame.NavigationService.Navigate(pPhoto);
        }

        private void Page2_BackButtonClick()
        {
           
            mainFrame.NavigationService.Navigate(pFIO);
        }

        private void Page2_NextButtonClick()
        {
            // userResumes.Picture = pPhoto.Picture;
            userResumes.Picture = pPhoto.Picture != null ? ImageToByteArray(pPhoto.Picture) : null;
            mainFrame.NavigationService.Navigate(pEducation);
        }

        private void Page3_BackButtonClick()
        {
            mainFrame.NavigationService.Navigate(pPhoto);
        }

        private void Page3_NextButtonClick() 
        {
            userResumes.Education = pEducation.Education;


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
            //CloseApplication(); 
            using (AplicationContext db = new AplicationContext())
            {
                UserResume exitUserResume = db.UserResume.FirstOrDefault();
                if(exitUserResume != null)
                {
                    exitUserResume.Surname = pFIO.Surname;
                    exitUserResume.UserName = pFIO.UserName;
                    exitUserResume.Pobatkovi = pFIO.Pobatkovi;
                    exitUserResume.Date = pFIO.Date;
                    exitUserResume.Adress = pFIO.Adress;
                    exitUserResume.PhoneNumber = pFIO.PhoneNumber;
                    exitUserResume.Email = pFIO.Email;

                    exitUserResume.Picture = pPhoto.Picture != null ? ImageToByteArray(pPhoto.Picture) : null;
                    exitUserResume.Education = pEducation.Education;

                    db.SaveChanges();
                }
                else
                {
                    UserResume newResume = new UserResume
                    {
                        Surname = pFIO.Surname,
                        UserName = pFIO.UserName,
                        Pobatkovi = pFIO.Pobatkovi,
                        Date = pFIO.Date,
                        Adress = pFIO.Adress,
                        PhoneNumber = pFIO.PhoneNumber,
                        Email = pFIO.Email,
                        Picture = pPhoto.Picture != null ? ImageToByteArray(pPhoto.Picture) : null,
                        Education = pEducation.Education                        
                     };

                    db.UserResume.Add(newResume);
                    db.SaveChanges();
                }
            }
            CloseApplication();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (AplicationContext db = new AplicationContext())
            {
                UserResume exitUserResume = db.UserResume.FirstOrDefault();
                if (exitUserResume != null)
                {
                    exitUserResume.Surname = pFIO.Surname;
                    exitUserResume.UserName = pFIO.UserName;
                    exitUserResume.Pobatkovi = pFIO.Pobatkovi;
                    exitUserResume.Date = pFIO.Date;
                    exitUserResume.Adress = pFIO.Adress;
                    exitUserResume.PhoneNumber = pFIO.PhoneNumber;
                    exitUserResume.Email = pFIO.Email;

                    exitUserResume.Picture = pPhoto.Picture != null ? ImageToByteArray(pPhoto.Picture) : null;
                    exitUserResume.Education = pEducation.Education;

                    db.SaveChanges();
                }
                else
                {
                    UserResume newResume = new UserResume
                    {
                        Surname = pFIO.Surname,
                        UserName = pFIO.UserName,
                        Pobatkovi = pFIO.Pobatkovi,
                        Date = pFIO.Date,
                        Adress = pFIO.Adress,
                        PhoneNumber = pFIO.PhoneNumber,
                        Email = pFIO.Email,
                        Picture = pPhoto.Picture != null ? ImageToByteArray(pPhoto.Picture) : null,
                        Education = pEducation.Education
                    };

                    db.UserResume.Add(newResume);
                    db.SaveChanges();
                }
            }
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (AplicationContext db = new AplicationContext())
            {
                UserResume existingResume = db.UserResume.FirstOrDefault();
               
                if (existingResume != null)
                {
                    bool resumeIncomplete = false;
                    //bool resumeFio = false;
                    //bool resumeEducation = false;


                    pFIO.textBoxSurname.Text = existingResume.Surname;
                    pFIO.textBoxName.Text = existingResume.UserName;
                    pFIO.textBoxPobatkovi.Text = existingResume.Pobatkovi;
                    pFIO.datePicker.SelectedDate = existingResume.Date;
                    pFIO.textBoxAdress.Text = existingResume.Adress;
                    pFIO.textBoxPhone.Text = existingResume.PhoneNumber;
                    pFIO.textBoxEmail.Text = existingResume.Email;



                    if (existingResume.Picture != null)
                    {
                        using (MemoryStream stream = new MemoryStream(existingResume.Picture))
                        {
                            BitmapImage bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = stream;
                            bitmapImage.EndInit();

                            pPhoto.pictureBox.Source = bitmapImage;
                        }
                    }
                    else
                    {
                        resumeIncomplete = true;
                    }

                    FlowDocument flowDocument = new FlowDocument();
                    flowDocument.Blocks.Add(new Paragraph(new Run(existingResume.Education)));
                    pEducation.richTextBox.Document = flowDocument;

                    //MessageBoxResult result = MessageBox.Show("Бажаєте продовжити попередню роботу?", "Відновлення резюме", MessageBoxButton.YesNo);
                    //if (result == MessageBoxResult.Yes)
                    //{
                    //    mainFrame.NavigationService.Navigate(pEducation);
                    //}
                    MessageBoxResult result;
                    if (resumeIncomplete)
                    {
                        result = MessageBox.Show("Резюме неполное. Желаете продолжить заполнение?", "Восстановление резюме", MessageBoxButton.YesNo);
                    }
                    else
                    {
                        result = MessageBox.Show("Желаете продолжить предыдущую работу?", "Восстановление резюме", MessageBoxButton.YesNo);
                    }

                    if (result == MessageBoxResult.Yes)
                    {
                        if (resumeIncomplete)
                        {
                            mainFrame.NavigationService.Navigate(pPhoto);
                        }
                        else
                        {
                            mainFrame.NavigationService.Navigate(pEducation);
                        }
                    }
                    if(result == MessageBoxResult.No)
                    {
                        ClearTextBox();
                        mainFrame.NavigationService.Navigate(pFIO);
                    }
                }
            }
        }
   

        private void ClearTextBox()
        {
            pFIO.textBoxSurname.Text = "";
            pFIO.textBoxName.Text = "";
            pFIO.textBoxPobatkovi.Text = "";
            pFIO.datePicker.Text = "";
            pFIO.textBoxPhone.Text = "";
            pFIO.textBoxAdress.Text = "";
            pFIO.textBoxEmail.Text = "";

            pPhoto.pictureBox.Source = null;

            pEducation.richTextBox.Document.Blocks.Clear();

        }
    }
}
