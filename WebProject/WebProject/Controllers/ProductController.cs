using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.dbEntities;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Product_ManagermentEntities obj = new Product_ManagermentEntities();

        public ActionResult Detail(string BARCODE)
        {
            if(BARCODE == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var pro = obj.Products.Where(x => x.BARCODE == BARCODE).FirstOrDefault();
                return View(pro);
         
        }

        public ActionResult ListGridLarge()
        {
            return View();
        }
        public ActionResult ListGridGrid()
        {
            return View();
        }
    }
}