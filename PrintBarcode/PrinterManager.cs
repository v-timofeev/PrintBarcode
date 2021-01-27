using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace PrintBarcode
{
    class PrinterManager
    {
        private IBarcode bc;
        private string PrinterName;


        public PrinterManager()
        {
            GetThermalPrinter();
        }


        public void PrintBarcode(string barcode)
        {
            bc = new Barcode(barcode);
            PrintDocument pd = new PrintDocument()
            {
                DocumentName = "label",
                PrinterSettings =
                {
                    PrinterName = PrinterName
                },
                DefaultPageSettings = { 
                    PaperSize = new PaperSize("Thermal 7cm/10cm", 275, 393),
                    Landscape = true
                }
            };
            
            pd.PrintPage += Pd_PrintPage;
            pd.Print();
        }


        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(
                bc.GetImage(), 
                new System.Drawing.Point(100, 200)
                );
            e.Graphics.DrawImage(
                bc.GetRotatedImage(), 
                new System.Drawing.Point(300, 100)
                );
        }

        
        private void GetThermalPrinter()
        {
            
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                if (String.Concat(printer).Contains("Datamax"))
                {
                    PrinterName = (string)printer;
                }
            }

            if (PrinterName is null)
            {
                var pd = new PrintDialog();
                
                pd.ShowDialog();
                PrinterName = pd.PrinterSettings.PrinterName;
            }
        }
    }
}
