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
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WPF_Resume.Pages_Forma2
{
    /// <summary>
    /// Interaction logic for PResult2.xaml
    /// </summary>
    public partial class PResult2 : Page
    {
        PFIO2 pFIO2 = new PFIO2();
        PPhoto2 photo2 = new PPhoto2();
        PEdEx pEdEx = new PEdEx();
        PSkPq pSkPq = new PSkPq();
        public PResult2()
        {
            InitializeComponent();


        }

        private byte[] GetImageBytesFromImageControl(System.Windows.Controls.Image imageControl)
        {
            try
            {
                BitmapImage bitmapImage = (BitmapImage)imageControl.Source;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to bytes: {ex.Message}");
                return null;
            }
        }
        private void buttonPrintDocx_Click(object sender, RoutedEventArgs e)
        {
            string surname = pFIO2.Surname;
            string name = pFIO2.Name;
            string pobatkovi = pFIO2.Pobatkovi;
            string adress = pFIO2.Adress;
            string date = pFIO2.Date.ToShortDateString();
            string phone = pFIO2.PhoneNumber;
            string email = pFIO2.Email;

            byte[] imageBytes2 = GetImageBytesFromImageControl(photo2.pictureBox);
            string education = pEdEx.Education;
            string experience = pEdEx.Experience;
            string skills = pSkPq.Skills;
            string prsonal = pSkPq.Personal;


            try
            {
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.Filter = "Word Document (*.docx)|*.docx";
                saveFileDialog.FileName = "resume.docx";

                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
                {
                    string filename = saveFileDialog.FileName;
                    using (DocX doc = DocX.Create(filename))
                    {
                        // Ваш остальной код...

                        Formatting nameFormat = new Formatting { Size = 26, Bold = true };
                        Xceed.Document.NET.Paragraph nameParagraph = doc.InsertParagraph(surname + " " + name + " " + pobatkovi, false, nameFormat);
                        nameParagraph.Alignment = Alignment.left;


                        Xceed.Document.NET.Paragraph infoParagraph = doc.InsertParagraph();
                        infoParagraph.AppendLine("Дата народження: " + date);
                        infoParagraph.AppendLine("Адреса: " + adress);
                        infoParagraph.AppendLine("Телефон: " + phone);
                        infoParagraph.AppendLine("Email: " + email);


                        Formatting educationFormat = new Formatting { Size = 18, Bold = true };
                        Xceed.Document.NET.Paragraph educationHeaderParagraph = doc.InsertParagraph("Освіта", false, educationFormat);
                        Xceed.Document.NET.Paragraph educationParagraph = doc.InsertParagraph();
                        educationParagraph.Append(education);
                        educationParagraph.SpacingAfter(10);


                        Formatting experienceFormat = new Formatting { Size = 18, Bold = true };
                        Xceed.Document.NET.Paragraph experienceHeaderParagraph = doc.InsertParagraph("Досвід роботи", false, experienceFormat);
                        Xceed.Document.NET.Paragraph experienceParagraph = doc.InsertParagraph();
                        experienceParagraph.Append(experience);
                        experienceParagraph.SpacingAfter(10);


                        Formatting skillsFormat = new Formatting { Size = 18, Bold = true };
                        Xceed.Document.NET.Paragraph skillsHeaderParagraph = doc.InsertParagraph("Навички", false, skillsFormat);
                        Xceed.Document.NET.Paragraph skillsParagraph = doc.InsertParagraph();
                        skillsParagraph.Append(skills);
                        skillsParagraph.SpacingAfter(10);

                        Formatting personalFormat = new Formatting { Size = 18, Bold = true };
                        Xceed.Document.NET.Paragraph spersonalHeaderParagraph = doc.InsertParagraph("Навички", false, skillsFormat);
                        Xceed.Document.NET.Paragraph personalParagraph = doc.InsertParagraph();
                        personalParagraph.Append(prsonal);
                        personalParagraph.SpacingAfter(10);


                        if (photo2.pictureBox.Source is BitmapImage bitmapImage)
                        {
                            byte[] imageBytes = GetImageBytesFromBitmapImage(bitmapImage);
                            string imagePath = "image.png";

                            File.WriteAllBytes(imagePath, imageBytes);

                            Xceed.Document.NET.Image image = doc.AddImage(imagePath);
                            Picture picture = image.CreatePicture();
                            picture.Width = 200;
                            picture.Height = 200;

                            Xceed.Document.NET.Paragraph imageParagraph = doc.InsertParagraph();
                            imageParagraph.InsertPicture(picture);
                            imageParagraph.Alignment = Alignment.right;
                        }

                        doc.Save();
                    }

                    System.Windows.MessageBox.Show("Документ успішно створено.", "Успіх");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Помилка при створення документа: " + ex.Message, "Помилка");
            }
        }

        private byte[] GetImageBytesFromBitmapImage(BitmapImage bitmapImage)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    encoder.Save(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to bytes: {ex.Message}");
                return null;
            }
        }
    }
}
