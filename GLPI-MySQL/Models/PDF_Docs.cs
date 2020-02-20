using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Diagnostics;
using System.IO;
using PdfSharp;
using PdfSharp.Pdf.IO;
using System.Text;
using System.Collections;

namespace GLPI_MySQL.Models
{
    public class PDF_Docs
    {
        public void PdfDocsSchema( IEnumerable<Computer> comp)
        {
            double x = 10;
            double y = 20;

            string filename = "HelloWorld.pdf";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument.Info.Title = ("Mój pierwszy pdf");

            PdfPage page = pdfDocument.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);


            foreach (var item in comp)
            {
                //Console.WriteLine($"{item.Id} | {item.Id_User}| {item.Firstname} | {item.Realname} | {item.Type} | {item.Model} | {item.Producer} | {item.Code}");

                gfx.DrawString(($"{item.Firstname} | {item.Realname} | {item.Type} | {item.Model} ").ToString(), font, XBrushes.Black, new XPoint(x, y));

                y = y + 20;

            }


            //gfx.DrawString((comp.. , font, XBrushes.Black, new XPoint(x, y));

            pdfDocument.Save(filename);

        }

    }
}
