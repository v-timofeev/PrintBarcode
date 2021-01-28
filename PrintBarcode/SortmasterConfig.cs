using System;
using System.Collections.Generic;
using System.Text;

namespace PrintBarcode
{
    public class DocPrinter
    {
        public string name { get; set; }
        public string duplex { get; set; }
    }


    public class LabelPrinter
    {
        public string name { get; set; }
        public bool thermalPrinter { get; set; }
        public int countOfLabels { get; set; }
    }


    public class SortmasterConfig
    {
        public DocPrinter docPrinter { get; set; }
        public LabelPrinter labelPrinter { get; set; }
    }
}
