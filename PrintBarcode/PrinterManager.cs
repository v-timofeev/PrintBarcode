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
                    Color = false,
                    PaperSize = new PaperSize("Thermal 7cm/10cm", 404, 276),
                    Landscape = false,
                    Margins = new Margins(100, 100, 100, 100),
                    PrinterResolution =
                    {
                        X = 203,
                        Y = 203
                    }
                }
                
            };


            pd.PrintPage += Pd_PrintPage;

            pd.Print();
        }


        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(
                bc.GetImage(), 
                new System.Drawing.Point(80, 200)
                );
            e.Graphics.DrawImage(
                bc.GetRotatedImage(), 
                new System.Drawing.Point(320, 0)
                );
        }

        
        private void GetThermalPrinter()
        {
            ReadSortmasterJsonConfig();

            if (String.IsNullOrEmpty(PrinterName))
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
