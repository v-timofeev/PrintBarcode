using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrintBarcode
{
    interface IBarcode
    {
        public Bitmap GetBitmap();
        public Image GetImage();
        public Image GetRotatedImage();
    }
}
