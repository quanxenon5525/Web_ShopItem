using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class objProduct
    {
        public string BARCODE { get; set; }
        public string NameProduct { get; set; }
        public string NameAT { get; set; }
        public string Unit { get; set; }
        public string NameSupplier { get; set; }
        public string NameSource { get; set; }
        public string NameGProduct { get; set; }
        public Nullable<double> Price { get; set; }
        public string IdSupplier { get; set; }
        public Nullable<int> IdSource { get; set; }
        public Nullable<int> IdGroupProduct { get; set; }
        public string Note { get; set; }
        
    }
}
