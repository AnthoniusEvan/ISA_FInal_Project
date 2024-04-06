using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DbSalesPurchasing
{
    public class CustomPrint
    {
        #region Data Members
        private Font fontType;
        private StreamReader printToFile;
        private float marginLeft, marginRight, marginTop, marginBottom;
        private string fileName;
        #endregion

        #region Properties
        public Font FontType { get => fontType; set => fontType = value; }
        public StreamReader PrintToFile { get => printToFile; set => printToFile = value; }
        public float MarginLeft { get => marginLeft; set => marginLeft = value; }
        public float MarginRight { get => marginRight; set => marginRight = value; }
        public float MarginTop { get => marginTop; set => marginTop = value; }
        public float MarginBottom { get => marginBottom; set => marginBottom = value; }
        public string FileName { get => fileName; set => fileName = value; }
        #endregion

        #region Constructors
        public CustomPrint(Font fontType, string pathToFile, float leftMargin, float rightMargin, float topMargin, float bottomMargin)
        {
            FontType = fontType;
            PrintToFile = new StreamReader(pathToFile);
            MarginLeft = leftMargin;
            MarginRight = rightMargin;
            MarginTop = topMargin;
            MarginBottom = bottomMargin;
            FileName = pathToFile;
        }
        #endregion

        #region Methods
        private void PrintText(object sender, PrintPageEventArgs e)
        {
            int maxRow = (int)((e.MarginBounds.Height - MarginTop - MarginBottom) /FontType.GetHeight(e.Graphics));
            float y = MarginTop;
            int rowNum = 0;

            string rowText = PrintToFile.ReadLine();
            while (rowNum<maxRow && rowText != null)
            {
                y = MarginTop + (rowNum * FontType.GetHeight(e.Graphics));
                Font f = new Font(FontType, FontType.Style);
                StringFormat format = new StringFormat(StringFormatFlags.NoClip);
                if (rowText.Contains("<center>"))
                {
                    format.Alignment = StringAlignment.Center;
                    rowText = rowText.Replace("<center>", "");
                }
                if (rowText.Contains("<b>"))
                {
                   f = new Font(FontType.FontFamily, FontType.Size, FontStyle.Bold);
                   rowText = rowText.Replace("<b>", "");
                }
                if (rowText.Contains("<14>"))
                {
                    f = new Font(FontType.FontFamily, 14, f.Style);
                    rowText = rowText.Replace("<14>", "");
                }
                if (rowText.Contains("<16>"))
                {
                    f = new Font(FontType.FontFamily, 16, f.Style);
                    rowText = rowText.Replace("<16>", "");
                }

                if (format.Alignment == StringAlignment.Center)
                {
                    float center = Convert.ToSingle(e.PageBounds.Width / 2 - e.Graphics.MeasureString(rowText, f).Width / 2);
                    e.Graphics.DrawString(rowText, f,
                            Brushes.Black, center, y);
                }
                else
                    e.Graphics.DrawString(rowText, f,
    Brushes.Black, MarginLeft, y, format);
                rowNum++;
                rowText = PrintToFile.ReadLine();
            }
            if (rowText != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            printed = true;
        }
        bool printed = false;
        public bool SendToPrinter()
        {
            string dir = @"C:\Users\Anthonius Evan\Documents\Pet Shipper Reports\";
            FileName = dir + FileName;
            if (Directory.Exists(dir))
            {
                PrintDocument p = new PrintDocument();
                p.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                p.PrinterSettings.PrintFileName = FileName;
                p.PrinterSettings.PrintToFile = true;
                p.PrintPage += new PrintPageEventHandler(PrintText);
                p.Print();
                PrintToFile.Close();
            }
            return printed;
        }
        #endregion
    }
}
