using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class objDeal
    {
        public int Id { get; set; }
        public int idOrder { get; set; }
        public string NameProduct { get; set; }
        public Nullable<int> OrderId { get; set; }
        public string ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
      
        

    }
}
