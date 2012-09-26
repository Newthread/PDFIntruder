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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WpfApp_PDF_one
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            Console.WriteLine("Chapter 1 example 1: Hello World");

            // step 1: creation of a document-object
            Document document = new Document();

            // step 2:
            // we create a writer that listens to the document
            // and directs a PDF-stream to a file
            PdfWriter.GetInstance(document, new FileStream("Chap0101.pdf", FileMode.Create));

            // step 3: we open the document
            document.Open();

            // step 4: we add a paragraph to the document
            document.Add(new iTextSharp.text.Paragraph("W la figa!!!"));

            // step 5: we close the document
            document.Close();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Build();
        }


        // Set up the fonts to be used on the pages 
        private Font _largeFont = new Font(Font.FontFamily.HELVETICA, 36, Font.BOLD, BaseColor.RED);
        private Font _standardFont = new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.BLACK);
        private Font _smallFont = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL, BaseColor.BLACK);





        public void Build()
        {
            iTextSharp.text.Document doc = null;

            try
            {
                // Initialize the PDF document
                doc = new Document();
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc,
                    new System.IO.FileStream(System.IO.Directory.GetCurrentDirectory() + "\\test_newthread.pdf",
                        System.IO.FileMode.Create));

                // Set margins and page size for the document
                doc.SetMargins(0, 0, 0, 0);
                // There are a huge number of possible page sizes, including such sizes as
                // EXECUTIVE, POSTCARD, LEDGER, LEGAL, LETTER_LANDSCAPE, and NOTE

                // A4_landscape NON funziona... e' necessario usare il metodo Rotate() ... BOH!!
                //doc.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());

                doc.SetPageSize(new iTextSharp.text.Rectangle(802, 595));
                //doc.SetPageSize(iTextSharp.text.Rectangle.(802, 595));

                // Add metadata to the document.  This information is visible when viewing the 
                // document properities within Adobe Reader.
                doc.AddTitle("AERRE pdf demo");
                doc.AddCreator("iText");
                doc.AddKeywords("keywords");

                // Add Xmp metadata to the document.
                this.CreateXmpMetadata(writer);

                // Open the document for writing content
                doc.Open();

                // Add pages to the document

                this.AddPageWithBackgroundSX(doc);

                //this.AddPageWithInternalLinks(doc);
                //this.AddPageWithBulletList(doc);
                //this.AddPageWithExternalLinks(doc);
                //this.AddPageWithImage(doc, System.IO.Directory.GetCurrentDirectory() + "\\FinalGraph.jpg");

                // Add page labels to the document
                //iTextSharp.text.pdf.PdfPageLabels pdfPageLabels = new iTextSharp.text.pdf.PdfPageLabels();
                //pdfPageLabels.AddPageLabel(1, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Basic Formatting");
                //pdfPageLabels.AddPageLabel(2, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Internal Links");
                //pdfPageLabels.AddPageLabel(3, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Bullet List");
                //pdfPageLabels.AddPageLabel(4, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "External Links");
                //pdfPageLabels.AddPageLabel(5, iTextSharp.text.pdf.PdfPageLabels.EMPTY, "Image");
                //writer.PageLabels = pdfPageLabels;
            }
            catch (iTextSharp.text.DocumentException dex)
            {
                // Handle iTextSharp errors
            }
            finally
            {
                // Clean up
                doc.Close();
                doc = null;

                System.Diagnostics.Process.Start("IExplore.exe", System.IO.Directory.GetCurrentDirectory() + "\\test_newthread.pdf");
            }
        }


        private void AddPageWithBackgroundSX(iTextSharp.text.Document doc)
        {
          
            // Add a logo
            String appPath = System.IO.Directory.GetCurrentDirectory();
            //iTextSharp.text.Image bg_sx = iTextSharp.text.Image.GetInstance(appPath + "\\sfondi\\pag12_72dpi.jpg");
            iTextSharp.text.Image bg_sx = iTextSharp.text.Image.GetInstance(appPath + "\\sfondi\\pag12.jpg");
            //bg_sx.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);
            bg_sx.ScaleToFit(802, 595);
            bg_sx.Alignment = iTextSharp.text.Image.UNDERLYING;
            doc.Add(bg_sx);
            bg_sx = null;

            // Write page content.  Note the use of fonts and alignment attributes.
            //this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("\n\nMY SCIENCE PROJECT\n\n"));
            //this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _standardFont, new Chunk("by M. Lichtenberg\n\n\n\n"));

            // Write additional page content
            //this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("\n\n\nWhat kind of paper is the best for making paper airplanes?\n\n\n\n\n"));
            //this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _smallFont, new Chunk("Generated " +
            //    DateTime.Now.Day.ToString() + " " +
            //    System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " +
            //    DateTime.Now.Year.ToString() + " " +
            //    DateTime.Now.ToShortTimeString()));



            //PdfPTable table = new PdfPTable(3);
            //table.WidthPercentage = 100;
            //table.AddCell("Cell 1");
            //PdfPCell cell = new PdfPCell(new Phrase("Cell 2", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL)));
            //cell.BorderWidthBottom = 3f;
            //cell.BorderWidthTop = 3f;
            //cell.PaddingBottom = 10f;
            //cell.PaddingLeft = 20f;
            //cell.PaddingTop = 4f;
            //table.AddCell(cell);
            //table.AddCell("Cell 3");
            //doc.Add(table);

                    // Set up the fonts to be used on the pages 

            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            Font times = new Font(bfTimes, 12, Font.ITALIC, BaseColor.RED);


            Font pippo = new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD, BaseColor.WHITE);


            // Generate external links to be embedded in the page
            iTextSharp.text.Anchor bibliographyAnchor1 = new Anchor("TDS", _standardFont);
            bibliographyAnchor1.Reference = "link.pdf";

            // Add the links to the page
            //this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, bibliographyAnchor1);


            iTextSharp.text.Paragraph paragraphTable1 = new iTextSharp.text.Paragraph();
            paragraphTable1.SpacingBefore = 100f;
            paragraphTable1.SpacingAfter = 15f;  

            PdfPTable table = new PdfPTable(7);
            table.TotalWidth = 792f;
            table.LockedWidth = true;
                   
            float[] colWidths = { 105, 87, 85, 67, 67, 228, 73 };
            table.SetWidths(colWidths);
            
            table.DefaultCell.Phrase = new Phrase("", pippo);
            table.DefaultCell.BorderWidth=8;
            table.DefaultCell.HorizontalAlignment = 1;
            table.DefaultCell.VerticalAlignment = 1;
            table.DefaultCell.BackgroundColor = new BaseColor(219, 220, 222);
            table.DefaultCell.BorderColor = new BaseColor(255, 255, 255);
            table.DefaultCell.MinimumHeight = 35f;
            
            table.AddCell("Nome Commerciale");
            table.AddCell("INCI USA");
            table.AddCell("INCI EU");
            table.AddCell("CAS");
            table.AddCell("EINECS");
            table.AddCell("Descrizione funzione");
            table.AddCell("Categorie di utilizzo");
            table.Rows[0].GetCells()[0].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[1].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[2].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[3].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[4].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[5].BackgroundColor = new BaseColor(0, 159, 238);
            table.Rows[0].GetCells()[6].BackgroundColor = new BaseColor(0, 159, 238);

            table.AddCell("Nome Commerciale");
            table.AddCell("INCI USA");
            table.AddCell("INCI EU");
            table.AddCell("CAS");
            table.AddCell("EINECS");
            table.AddCell("Descrizione funzione");
            table.AddCell("Categorie di utilizzo");

            Phrase ph = new Phrase();

            ph.Add("testo \n");
            ph.Add(bibliographyAnchor1);
            Chunk ch = new Chunk();
            ch.Font.SetStyle(1);
            ch.Append("\n boldissssimo");

            ph.Add(ch);


            table.AddCell(ph);
            table.AddCell("INCI USA");
            table.AddCell("INCI EU");
            table.AddCell("CAS");
            table.AddCell("EINECS");
            table.AddCell("Descrizione funzione");
            table.AddCell("Categorie di utilizzo");

 

            paragraphTable1.Add(table);
            doc.Add(paragraphTable1);














        }


        /// <summary>
        /// Add the header page to the document.  This shows an example of a page containing
        /// both text and images.  The contents of the page are centered and the text is of
        /// various sizes.
        /// </summary>
        /// <param name="doc"></param>
        /// 

        private void AddPageWithBasicFormatting(iTextSharp.text.Document doc)
        {
            // Write page content.  Note the use of fonts and alignment attributes.
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("\n\nMY SCIENCE PROJECT\n\n"));
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _standardFont, new Chunk("by M. Lichtenberg\n\n\n\n"));

            // Add a logo
            String appPath = System.IO.Directory.GetCurrentDirectory();
            iTextSharp.text.Image logoImage = iTextSharp.text.Image.GetInstance(appPath + "\\PaperAirplane.jpg");
            logoImage.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            doc.Add(logoImage);
            logoImage = null;

            // Write additional page content
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("\n\n\nWhat kind of paper is the best for making paper airplanes?\n\n\n\n\n"));
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _smallFont, new Chunk("Generated " +
                DateTime.Now.Day.ToString() + " " +
                System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + " " +
                DateTime.Now.Year.ToString() + " " +
                DateTime.Now.ToShortTimeString()));
        }

        /// <summary>
        /// Add a paragraph object containing the specified element to the PDF document.
        /// </summary>
        /// <param name="doc">Document to which to add the paragraph.</param>
        /// <param name="alignment">Alignment of the paragraph.</param>
        /// <param name="font">Font to assign to the paragraph.</param>
        /// <param name="content">Object that is the content of the paragraph.</param>
        private void AddParagraph(Document doc, int alignment, iTextSharp.text.Font font, iTextSharp.text.IElement content)
        {
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
            paragraph.SetLeading(0f, 1.2f);
            paragraph.Alignment = alignment;
            paragraph.Font = font;
            paragraph.Add(content);
            doc.Add(paragraph);
        }

        /// <summary>
        /// Add a blank page to the document.
        /// </summary>
        /// <param name="doc"></param>
        private void AddPageWithInternalLinks(iTextSharp.text.Document doc)
        {
            // Generate links to be embedded in the page
            Anchor researchAnchor = new Anchor("Research & Hypothesis\n\n", _standardFont);
            researchAnchor.Reference = "#research"; // this link references a named anchor within the document
            Anchor graphAnchor = new Anchor("Graph\n\n", _standardFont);
            graphAnchor.Reference = "#graph";
            Anchor resultsAnchor = new Anchor("Results & Bibliography", _standardFont);
            resultsAnchor.Reference = "#results";

            // Add a new page to the document
            doc.NewPage();

            // Add heading text to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new iTextSharp.text.Chunk("TABLE OF CONTENTS\n\n\n\n\n"));

            // Add the links to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _standardFont, researchAnchor);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _standardFont, graphAnchor);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _standardFont, resultsAnchor);
        }

        /// <summary>
        /// Add a page that includes a bullet list.
        /// </summary>
        /// <param name="doc"></param>
        private void AddPageWithBulletList(iTextSharp.text.Document doc)
        {
            // Add a new page to the document
            doc.NewPage();

            // The header at the top of the page is an anchor linked to by the table of contents.
            iTextSharp.text.Anchor contentsAnchor = new iTextSharp.text.Anchor("RESEARCH\n\n", _largeFont);
            contentsAnchor.Name = "research";

            // Add the header anchor to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, contentsAnchor);

            // Create an unordered bullet list.  The 10f argument separates the bullet from the text by 10 points
            iTextSharp.text.List list = new iTextSharp.text.List(iTextSharp.text.List.UNORDERED, 10f);
            list.SetListSymbol("\u2022");   // Set the bullet symbol (without this a hypen starts each list item)
            list.IndentationLeft = 20f;     // Indent the list 20 points
            list.Add(new iTextSharp.text.ListItem("Lift, thrust, drag, and gravity are the four forces that act on a plane.", _standardFont));
            list.Add(new iTextSharp.text.ListItem("A plane should be light to help fight against gravity's pull to the ground.", _standardFont));
            list.Add(new iTextSharp.text.ListItem("Gravity will have less effect on a plane built from the lightest materials available.", _standardFont));
            list.Add(new iTextSharp.text.ListItem("In order to fly well, airplanes must be stable.", _standardFont));
            list.Add(new iTextSharp.text.ListItem("A plane that is unstable will either pitch up into a stall, or nose-dive.", _standardFont));
            doc.Add(list);  // Add the list to the page

            // Add some white space and another heading
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("\n\n\nHYPOTHESIS\n\n"));

            // Add some final text to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk("Given five paper airplanes made out of newspaper, printer paper, construction paper, paper towel, and posterboard, the airplane made out of printer paper will fly the furthest."));
        }

        /// <summary>
        /// Add a page containing a single image.  Set the page size to match the image size.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="imagePath"></param>
        private void AddPageWithImage(iTextSharp.text.Document doc, String imagePath)
        {
            // Read the image file
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(new Uri(imagePath));

            // Set the page size to the dimensions of the image BEFORE adding a new page to the document.
            // Pad the height a bit to leave room for the page header.
            float imageWidth = image.Width;
            float imageHeight = image.Height;
            doc.SetMargins(0, 0, 0, 0);
            doc.SetPageSize(new iTextSharp.text.Rectangle(imageWidth, imageHeight + 100));

            // Add a new page
            doc.NewPage();

            // The header at the top of the page is an anchor linked to by the table of contents.
            iTextSharp.text.Anchor contentsAnchor = new iTextSharp.text.Anchor("\nGRAPH\n\n", _largeFont);
            contentsAnchor.Name = "graph";

            // Add the anchor and image to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, contentsAnchor);
            doc.Add(image);
            image = null;
        }

        /// <summary>
        /// Add a page that contains embedded hyperlinks to external resources
        /// </summary>
        /// <param name="doc"></param>
        private void AddPageWithExternalLinks(Document doc)
        {
            // Generate external links to be embedded in the page
            iTextSharp.text.Anchor bibliographyAnchor1 = new Anchor("http://teacher.scholastic.com/paperairplane/airplane.htm", _standardFont);
            bibliographyAnchor1.Reference = "http://teacher.scholastic.com/paperairplane/airplane.htm";
            Anchor bibliographyAnchor2 = new Anchor("http://www.eecs.berkeley.edu/Programs/doublex/spring02/paperairplane.html", _standardFont);
            bibliographyAnchor1.Reference = "http://www.eecs.berkeley.edu/Programs/doublex/spring02/paperairplane.html";
            Anchor bibliographyAnchor3 = new Anchor("http://www.exo.net/~pauld/activities/flying/PaperAirplaneScience.html", _standardFont);
            bibliographyAnchor1.Reference = "http://www.exo.net/~pauld/activities/flying/PaperAirplaneScience.html";
            Anchor bibliographyAnchor4 = new Anchor("http://www.littletoyairplanes.com/theoryofflight/02whyplanes.html", _standardFont);
            bibliographyAnchor4.Reference = "http://www.littletoyairplanes.com/theoryofflight/02whyplanes.html";

            // The header at the top of the page is an anchor linked to by the table of contents.
            iTextSharp.text.Anchor contentsAnchor = new iTextSharp.text.Anchor("RESULTS\n\n", _largeFont);
            contentsAnchor.Name = "results";

            // Add a new page to the document
            doc.NewPage();

            // Add text to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, contentsAnchor);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, new Chunk("My hypothesis was incorrect.  The paper airplane made out of construction paper flew the furthest.\n\n\n"));
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_CENTER, _largeFont, new Chunk("BIBLIOGRAPHY\n\n"));

            // Add the links to the page
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, bibliographyAnchor1);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, bibliographyAnchor2);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, bibliographyAnchor3);
            this.AddParagraph(doc, iTextSharp.text.Element.ALIGN_LEFT, _standardFont, bibliographyAnchor4);
        }

        /// <summary>
        /// Use this method to write XMP data to a new PDF
        /// </summary>
        /// <param name="writer"></param>
        private void CreateXmpMetadata(iTextSharp.text.pdf.PdfWriter writer)
        {
            // Set up the buffer to hold the XMP metadata
            byte[] buffer = new byte[65536];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(buffer, true);

            try
            {
                // XMP supports a number of different schemas, which are made available by iTextSharp.
                // Here, the Dublin Core schema is chosen.
                iTextSharp.text.xml.xmp.XmpSchema dc = new iTextSharp.text.xml.xmp.DublinCoreSchema();

                // Add Dublin Core attributes
                iTextSharp.text.xml.xmp.LangAlt title = new iTextSharp.text.xml.xmp.LangAlt();
                title.Add("x-default", "My Science Project");
                dc.SetProperty(iTextSharp.text.xml.xmp.DublinCoreSchema.TITLE, title);

                // Dublin Core allows multiple authors, so we create an XmpArray to hold the values
                iTextSharp.text.xml.xmp.XmpArray author = new iTextSharp.text.xml.xmp.XmpArray(iTextSharp.text.xml.xmp.XmpArray.ORDERED);
                author.Add("M. Lichtenberg");
                dc.SetProperty(iTextSharp.text.xml.xmp.DublinCoreSchema.CREATOR, author);

                // Multiple subjects are also possible, so another XmpArray is used
                iTextSharp.text.xml.xmp.XmpArray subject = new iTextSharp.text.xml.xmp.XmpArray(iTextSharp.text.xml.xmp.XmpArray.UNORDERED);
                subject.Add("paper airplanes");
                subject.Add("science project");
                dc.SetProperty(iTextSharp.text.xml.xmp.DublinCoreSchema.SUBJECT, subject);

                // Create an XmpWriter using the MemoryStream defined earlier
                iTextSharp.text.xml.xmp.XmpWriter xmp = new iTextSharp.text.xml.xmp.XmpWriter(ms);
                xmp.AddRdfDescription(dc);  // Add the completed metadata definition to the XmpWriter
                xmp.Close();    // This flushes the XMP metadata into the buffer

                //---------------------------------------------------------------------------------
                // Shrink the buffer to the correct size (discard empty elements of the byte array)
                int bufsize = buffer.Length;
                int bufcount = 0;
                foreach (byte b in buffer)
                {
                    if (b == 0) break;
                    bufcount++;
                }
                System.IO.MemoryStream ms2 = new System.IO.MemoryStream(buffer, 0, bufcount);
                buffer = ms2.ToArray();
                //---------------------------------------------------------------------------------

                // Add all of the XMP metadata to the PDF doc that we're building
                writer.XmpMetadata = buffer;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
                ms.Dispose();
            }
        }
        

    }
}
