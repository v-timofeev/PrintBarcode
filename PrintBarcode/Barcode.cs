using System;
using System.Collections.Generic;
using System.Text;
using BarcodeLib;
using System.Drawing;
namespace PrintBarcode
{
    class Barcode : IBarcode
    {
        private BarcodeLib.Barcode bc = new BarcodeLib.Barcode();
        //private GeneratedBarcode gb;
        public Barcode(string barcode)
        {
            bc.IncludeLabel = true;
            bc.Encode(BarcodeLib.TYPE.CODE128, barcode, 200, 50);
            
            //gb = BarcodeWriter.CreateBarcode(barcode, BarcodeWriterEncoding.Code128);
        }
        public Bitmap GetBitmap()
        {
            return null;//gb.ToBitmap();
        }

        public Image GetImage()
        {
            
            return bc.EncodedImage;
        }
    }
}
