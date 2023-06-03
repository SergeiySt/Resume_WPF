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
        //PFIO2 pFIO2 = new PFIO2();
        //PPhoto2 photo2 = new PPhoto2();
        //PEdEx pEdEx = new PEdEx();
        //PSkPq pSkPq = new PSkPq();
        //PResult2 pResult2 = new PResult2();
        public PResult2()
        {
            InitializeComponent();
        }

        private void buttonPrintDocx_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = "output.docx";
                using (DocX doc = DocX.Create(filename))
                {

                    Formatting nameFormat = new Formatting { Size = 26, Bold = true };
                    Xceed.Document.NET.Paragraph nameParagraph = doc.InsertParagraph(pFIO2.textBoxSurname.Text + " " + pFIO2.textBoxName.Text + " " + pFIO2.textBoxPobatkovi.Text, false, nameFormat);
                    nameParagraph.Alignment = Alignment.left;


                    Xceed.Document.NET.Paragraph infoParagraph = doc.InsertParagraph();
                    infoParagraph.AppendLine("Дата рождения: " + pFIO2.datePicker.SelectedDate?.ToShortDateString());
                    infoParagraph.AppendLine("Адрес: " + pFIO2.textBoxAdress.Text);
                    infoParagraph.AppendLine("Телефон: " + pFIO2.textBoxPhone.Text);
                    infoParagraph.AppendLine("Email: " + pFIO2.textBoxEmail.Text);


                    Formatting educationFormat = new Formatting { Size = 18, Bold = true };
                    Xceed.Document.NET.Paragraph educationHeaderParagraph = doc.InsertParagraph("Образование", false, educationFormat);
                    Xceed.Document.NET.Paragraph educationParagraph = doc.InsertParagraph();
                    educationParagraph.Append(new TextRange(pEdEx.richTextBoxEducation.Document.ContentStart, pEdEx.richTextBoxEducation.Document.ContentEnd).Text);
                    educationParagraph.SpacingAfter(10);


                    Formatting experienceFormat = new Formatting { Size = 18, Bold = true };
                    Xceed.Document.NET.Paragraph experienceHeaderParagraph = doc.InsertParagraph("Опыт работы", false, experienceFormat);
                    Xceed.Document.NET.Paragraph experienceParagraph = doc.InsertParagraph();
                    experienceParagraph.Append(new TextRange(pEdEx.richTextBoxExperience.Document.ContentStart, pEdEx.richTextBoxExperience.Document.ContentEnd).Text);
                    experienceParagraph.SpacingAfter(10);


                    Formatting skillsFormat = new Formatting { Size = 18, Bold = true };
                    Xceed.Document.NET.Paragraph skillsHeaderParagraph = doc.InsertParagraph("Навыки", false, skillsFormat);
                    Xceed.Document.NET.Paragraph skillsParagraph = doc.InsertParagraph();
                    skillsParagraph.Append(new TextRange(pSkPq.richTextBoxSkills.Document.ContentStart, pSkPq.richTextBoxSkills.Document.ContentEnd).Text);
                    skillsParagraph.SpacingAfter(10);


                    Formatting personalFormat = new Formatting { Size = 18, Bold = true };
                    Xceed.Document.NET.Paragraph personalHeaderParagraph = doc.InsertParagraph("Личные качества", false, personalFormat);
                    Xceed.Document.NET.Paragraph personalParagraph = doc.InsertParagraph();

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

                System.Windows.MessageBox.Show("Документ успешно создан.", "Успех");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка при создании документа: " + ex.Message, "Ошибка");
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
