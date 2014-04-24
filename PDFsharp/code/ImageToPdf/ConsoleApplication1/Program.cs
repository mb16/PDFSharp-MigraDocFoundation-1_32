using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static PdfPage PicToPdfPage(
            PdfDocument doc,
            string source)
        {
            var page = new PdfPage();

            doc.AddPage(page);

            XGraphics xgr = XGraphics.FromPdfPage(page);
            XImage img = XImage.FromFile(source);
            xgr.DrawImage(img, 0, 0);

            return page;
        }

        static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument();

            string[] items = new string [] 
            {
                @"D:\Floppy\GC\transcript\page1.jpg",
                @"D:\Floppy\GC\transcript\page2.jpg",
                @"D:\Floppy\GC\transcript\page3.jpg"
            };

            foreach (string s in items)
                PicToPdfPage(doc, s);

            doc.Save(@"c:\temp\x.pdf");
            doc.Close();
        }
    }
}
