using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Text.Json;
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
                    PrinterName = this.PrinterName
                },
                DefaultPageSettings = {
                    PaperSize = new PaperSize("Thermal 7cm/10cm", 275, 393),
                    Landscape = false,
                    Margins = new Margins(0,0,0,0)
                }
            };
            
            pd.PrintPage += Pd_PrintPage;

            pd.Print();
        }


        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(
                bc.GetImage(), 
                new System.Drawing.Point(50, 300)
                );
            e.Graphics.DrawImage(
                bc.GetRotatedImage(), 
                new System.Drawing.Point(200, 100)
                );
        }

        
        private void GetThermalPrinter()
        {
            ReadSortmasterJsonConfig();

            if (PrinterName.Length is 0)
            {
                PrintDialog pd = new PrintDialog();
                
                pd.ShowDialog();
                PrinterName = pd.PrinterSettings.PrinterName;
            }
        }


        private void ReadSortmasterJsonConfig()
        {
            string pathToConfig = @"C:\Program Files (x86)\SortMaster Agent\config\printersSettings.json";
            
            if (File.Exists(pathToConfig))
            {
                string jsonString = File.ReadAllText(pathToConfig);
                SortmasterConfig sm = JsonSerializer.Deserialize<SortmasterConfig>(jsonString);
                PrinterName = sm.labelPrinter.name;
            }
      
        }
    }
}
