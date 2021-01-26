using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PrintBarcode
{
    class PrinterManager
    {
        public Barcode bc = new Barcode("UB516551044HK");
        public void Print()
        {
            
            PrintDocument pd = new PrintDocument();


            pd.PrinterSettings.PrinterName = GetThermalPrinter();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Thermal 7cm/10cm", 275, 393);
            pd.DefaultPageSettings.Landscape = true; 
            pd.PrintPage += Pd_PrintPage;
            pd.Print();

        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            int xp = e.PageSettings.PaperSize.Width;
            int yp = e.PageSettings.PaperSize.Height;

            int xi = bc.GetImage().Width;
            int yi = bc.GetImage().Height;

            
            e.Graphics.DrawImage(bc.GetImage(), new System.Drawing.Point((xi-xp)/2, (yp-yi)/2));
        }

        private string GetThermalPrinter()
        {

            return "Foxit PhantomPDF Printer";

        }
    }
}
