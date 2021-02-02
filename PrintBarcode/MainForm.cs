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
        PrinterManager printerManager;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Print(string barcode)
        {
            if (barcode.Length is 0)
            {
                MessageBox.Show("Введите штрих-код!");
            }
            else
            { 
                printerManager.PrintBarcode(barcode);
                BarcodeTextBox.Text = null;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Print(BarcodeTextBox.Text);
        }

        private void BarcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar is (char)Keys.Enter)
            {
                Print(BarcodeTextBox.Text);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            printerManager = new PrinterManager();
        }
    }
}
