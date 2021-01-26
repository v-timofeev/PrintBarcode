using System;
using System.Collections.Generic;
using System.Text;
using IronBarCode;
using System.Drawing;
namespace PrintBarcode
{
    class Barcode
    {
        private GeneratedBarcode gb;
        public Barcode(string barcode)
        {
            gb = BarcodeWriter.CreateBarcode(barcode, BarcodeWriterEncoding.Code128);
        }
        public Bitmap GetBitmap()
        {
            return gb.ToBitmap();
        }

        public Image GetImage()
        {
            gb.ResizeTo(300, 90).AddBarcodeValueTextBelowBarcode();
            return gb.ToImage();
        }
    }
}
