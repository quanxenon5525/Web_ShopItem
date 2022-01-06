using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.dbEntities;

namespace WebProject.Models
{
    public class HomeModel
    {
        public List<Product> ListProduct { get; set; }
        public List<GroupProduct> ListGroupProduct { get; set; }
        public List<Source> ListSource { get; set; }
    }
}