using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
using System.Xml.Linq;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Xceed.Document.NET;
using Xceed.Words.NET;
//using PdfSharp.Drawing;
using Image = iText.Layout.Element.Image;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;


namespace WPF_Resume.Pages_Simple
{
    /// <summary>
    /// Interaction logic for PResult.xaml
    /// </summary>
    public partial class PResult : Page
    {
        AplicationContext db = new AplicationContext();

        UserResume userResume;

        PFIO pFIO = new PFIO();
        PPhoto pPhoto = new PPhoto();
        PEducation pEducation = new PEducation();
        public PResult()
        {
            InitializeComponent();

            //userResume = new UserResume();

            //userResume = db.UserResume.FirstOrDefault();

            //if (userResume != null)
            //{
            //    textBlolckSurname.Text = userResume.Surname;
            //    textBlockName.Text = userResume.UserName;
            //    textBlockPobatkovi.Text = userResume.Pobatkovi;
            //    textBlockDate.Text = userResume.Date.ToShortDateString();
            //    textBlockAdress.Text = userResume.Adress;
            //    textBlockEmail.Text = userResume.Email;
            //    textBlockEducation.Text = userResume.Education;

            //    if (userResume.Picture != null)
            //    {
            //        using (MemoryStream stream = new MemoryStream(userResume.Picture))
            //        {
            //            BitmapImage bitmapImage = new BitmapImage();
            //            bitmapImage.BeginInit();
            //            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            //            bitmapImage.StreamSource = stream;
            //            bitmapImage.EndInit();

            //            pictureBox2.Source = bitmapImage;
            //        }
            //    }
            //}
        }

      
        private void buttonPrintToPdf_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "resume.pdf";
            PdfWriter writer = new PdfWriter(filePath);
            PdfDocument pdf = new PdfDocument(writer);
            iText.Layout.Document document = new iText.Layout.Document(pdf);


            float[] columnWidths = { 150, 350 };
            Table table = new Table(columnWidths);


            string surname = textBlolckSurname.Text;
            string name = textBlockName.Text;
            string patronymic = textBlockPobatkovi.Text;
            string dateOfBirth = textBlockDate.Text;
            string address = textBlockAdress.Text;
            string phoneNumber = textBlockPhone.Text;
            string email = textBlockEmail.Text;
            string education = textBlockEducation.Text;


            byte[] imageBytes = GetImageBytesFromImageControl(pictureBox2);
            if (imageBytes != null)
            {
                iText.Layout.Element.Image image = new iText.Layout.Element.Image(ImageDataFactory.Create(imageBytes))
                    .SetWidth(150)
                    .SetHeight(150);
                table.AddCell(new iText.Layout.Element.Cell().Add(image).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            }


            Paragraph personalInfoParagraph = new Paragraph()
                .Add(new Text($"{surname}\n").SetFontSize(28).SetBold())
                .Add(new Text($"{name}\n").SetFontSize(28).SetBold())
                .Add(new Text($"{patronymic}\n").SetFontSize(28).SetBold())
                .Add(new Text($"Date of Birth: {dateOfBirth}\n"))
                .Add(new Text($"Address: {address}\n"))
                .Add(new Text($"Phone: {phoneNumber}\n"))
                .Add(new Text($"Email: {email}\n"));
            table.AddCell(new iText.Layout.Element.Cell().Add(personalInfoParagraph).SetBorder(iText.Layout.Borders.Border.NO_BORDER));


            Paragraph educationHeader = new Paragraph("Education")
                .SetFontSize(18)
                .SetBold();
            Paragraph educationText = new Paragraph(education);
            table.AddCell(new iText.Layout.Element.Cell(1, 2).Add(educationHeader).Add(educationText).SetBorder(iText.Layout.Borders.Border.NO_BORDER));


            document.Add(table);
            document.Close();
            System.Diagnostics.Process.Start(filePath);
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
    }
}
