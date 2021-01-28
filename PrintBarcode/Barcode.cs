using System;
using System.Collections.Generic;
using System.Text;
using BarcodeLib;
using System.Drawing;
namespace PrintBarcode
{
    class Barcode : IBarcode
    {
        private readonly BarcodeLib.Barcode bc;

        public Barcode(string barcode)
        {
            bc = new BarcodeLib.Barcode
            {
                IncludeLabel = true
            };
            bc.Encode(BarcodeLib.TYPE.CODE128, barcode, 200, 50);
        }
        public Bitmap GetBitmap()
        {
            return null;
        }

        public Image GetImage()
        {
            
            return bc.EncodedImage;
        }

        public Image GetRotatedImage()
        {
            Image rotated = bc.EncodedImage;
            rotated.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return rotated;
        }
    }
}
