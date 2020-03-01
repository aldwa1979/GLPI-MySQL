using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
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
        //Handover Report
        public PdfDocument PdfDocsSchemaHandover(IEnumerable<Computer> comp)
        {
            double x = 0, y = 0;
            //string filename = "ProtokolPrzekazania.pdf";

            //anonimous type to get name and surname of user
            var dane = comp.Select(p => new { Name = p.Firstname, Surname = p.Realname }).FirstOrDefault();

            //encoding for polish letter 1252
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //implementation of pdfsharp
            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument.Info.Title = ("Protokół Przekazania");
            
            PdfPage page = pdfDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 10, XFontStyle.Regular);
            XFont fontBold = new XFont("Arial", 10, XFontStyle.Bold);

            gfx.DrawString("Grecos Holiday Sp z.o.o.", font, XBrushes.Black, new XPoint(30, 30));
            gfx.DrawString("Ul. Grunwaldzka 76A", font, XBrushes.Black, new XPoint(30, 50));
            gfx.DrawString($"Poznań {DateTime.Now.ToShortDateString().ToString()}", font, XBrushes.Black, new XPoint(450, 30));
            gfx.DrawString("60-311 Poznań", font, XBrushes.Black, new XPoint(30, 70));
            gfx.DrawString("PROTOKÓŁ ZDAWCZO-ODBIORCZY", fontBold, XBrushes.Black, new XPoint(200, 130));
            gfx.DrawString("PRZEKAZUJĄCY: Tomasz Fąs", font, XBrushes.Black, new XPoint(30, 160));
            gfx.DrawString($"PRZYJMUJĄCY: {dane.Name} {dane.Surname}", font, XBrushes.Black, new XPoint(30, 190));
            gfx.DrawString("W dniu dziesiejszym firma", font, XBrushes.Black, new XPoint(60, 220));
            gfx.DrawString("Grecos Holiday Sp. z o.o. z siedzibą przy ul. Grunwaldzkiej 76A w Poznaniu,", fontBold, XBrushes.Black, new XPoint(180, 220));
            gfx.DrawString("przekazuje przyjmującemu:", font, XBrushes.Black, new XPoint(30, y = 235));

            foreach (var item in comp)
            {
                y += 30;
                x = 60;

                switch (item.Type)
                {
                    case "Notebook":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "LapTop":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "Portable":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "Smartphone":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze seryjnym {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        y += 15;
                        x = 80;
                        gfx.DrawString(($"wraz z kartą telefoniczną o numerze {item.ContactNumber}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    default:
                        y -= 30;
                        break;
                }
            }

            gfx.DrawString("Przyjmujący oświadcza, że zobowiązuje się do należytej eksploatacji powierzonego sprzętu, zgodnie z ", font, XBrushes.Black, new XPoint(60, y += 30));
            gfx.DrawString("warunkami udzielonej gwarancji.", font, XBrushes.Black, new XPoint(30, y += 15));

            gfx.DrawString("W przypadku utraty lub uszkodzenia sprzętu wymienionego w protokole z powodu zaniedbania przez", font, XBrushes.Black, new XPoint(60, y += 30));
            gfx.DrawString("pracownika, przyjmujący ponosi odpowiedzialność finansową, chyba że pracodawca postanowi inaczej", font, XBrushes.Black, new XPoint(30, y += 15));

            gfx.DrawString("Jednocześnie zobowiązuje się do zwrotu ww. sprzętu w terminie wskazanym przez Grecos Holiday Sp.", font, XBrushes.Black, new XPoint(60, y += 30));
            gfx.DrawString("z o.o. bezpośrednio do siedziby firmy, kiedy taka informacja zostanie przekazana przyjmującemu lub z", font, XBrushes.Black, new XPoint(30, y += 15));
            gfx.DrawString("ostatnim dniem pracy w firmie Grecos Holiday Sp. z o.o.", font, XBrushes.Black, new XPoint(30, y += 15));

            gfx.DrawString("Protokół sporządzono w dwóch jednobrzmiących egzemplarzach, po jednym dla każdej ze stron.", font, XBrushes.Black, new XPoint(30, y += 30));


            gfx.DrawString("....................................................", fontBold, XBrushes.Black, new XPoint(30, y += 60));
            gfx.DrawString("....................................................", fontBold, XBrushes.Black, new XPoint(350, y));

            gfx.DrawString("Tomasz Fąs", fontBold, XBrushes.Black, new XPoint(30, y += 15));
            gfx.DrawString($"{dane.Name} {dane.Surname}", fontBold, XBrushes.Black, new XPoint(350, y));

            try
            {
                return pdfDocument;
            }

            catch (IOException ex)
            {
                throw ex;
            }

        }

        //Return Protocol
        public PdfDocument PdfDocsSchemaReturn(IEnumerable<Computer> comp)
        {
            double x = 0, y = 0;
            //string filename = "ProtokolZdania.pdf";

            //anonimous type to get name and surname of user
            var dane = comp.Select(p => new { Name = p.Firstname, Surname = p.Realname }).FirstOrDefault();

            //encoding for polish letter 1252
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            //implementation of pdfsharp
            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument.Info.Title = ("Protokół Zdania");

            PdfPage page = pdfDocument.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Arial", 10, XFontStyle.Regular);
            XFont fontBold = new XFont("Arial", 10, XFontStyle.Bold);

            gfx.DrawString("Grecos Holiday Sp z.o.o.", font, XBrushes.Black, new XPoint(30, 30));
            gfx.DrawString("Ul. Grunwaldzka 76A", font, XBrushes.Black, new XPoint(30, 50));
            gfx.DrawString($"Poznań {DateTime.Now.ToShortDateString().ToString()}", font, XBrushes.Black, new XPoint(450, 30));
            gfx.DrawString("60-311 Poznań", font, XBrushes.Black, new XPoint(30, 70));
            gfx.DrawString("PROTOKÓŁ ZDAWCZO-ODBIORCZY", fontBold, XBrushes.Black, new XPoint(200, 130));
            gfx.DrawString("PRZEKAZUJĄCY: Tomasz Fąs", font, XBrushes.Black, new XPoint(30, 160));
            gfx.DrawString($"PRZYJMUJĄCY: {dane.Name} {dane.Surname}", font, XBrushes.Black, new XPoint(30, 190));
            gfx.DrawString("W dniu dziesiejszym przekazujący zwraca firmie", font, XBrushes.Black, new XPoint(30, 220));
            gfx.DrawString("Grecos Holiday Sp. z o.o. z siedzibą przy ul. Grunwaldzkiej 76A", fontBold, XBrushes.Black, new XPoint(250, 220));
            gfx.DrawString("w Poznaniu,", fontBold, XBrushes.Black, new XPoint(30, y = 235));

            foreach (var item in comp)
            {
                y += 30;
                x = 60;

                switch (item.Type)
                {
                    case "Notebook":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "LapTop":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "Portable":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze service tag {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    case "Smartphone":
                        gfx.DrawString(($"{item.Type} {item.Producer} {item.Model} o numerze seryjnym {item.Serial}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        y += 15;
                        x = 80;
                        gfx.DrawString(($"wraz z kartą telefoniczną o numerze {item.ContactNumber}").ToString(), fontBold, XBrushes.Black, new XPoint(x, y));
                        break;

                    default:
                        y -= 30;
                        break;
                }
            }

            gfx.DrawString("Protokół sporządzono w dwóch jednobrzmiących egzemplarzach, po jednym dla każdej ze stron.", font, XBrushes.Black, new XPoint(30, y += 30));


            gfx.DrawString("....................................................", fontBold, XBrushes.Black, new XPoint(30, y += 60));
            gfx.DrawString("....................................................", fontBold, XBrushes.Black, new XPoint(350, y));

            gfx.DrawString("Tomasz Fąs", fontBold, XBrushes.Black, new XPoint(30, y += 15));
            gfx.DrawString($"{dane.Name} {dane.Surname}", fontBold, XBrushes.Black, new XPoint(350, y));

            try
            {
                return pdfDocument;
            }

            catch (IOException ex)
            {
                throw ex;
            }

        }
    }
}
