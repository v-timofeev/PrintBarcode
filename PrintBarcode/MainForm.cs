using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintBarcode
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Print(string barcode)
        {
            PrinterManager printerManager = new PrinterManager();
            printerManager.Print();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Print(BarcodeTextBox.Text);
        }
    }
}
