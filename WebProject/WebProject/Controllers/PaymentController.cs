using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.dbEntities;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        Product_ManagermentEntities objproduct = new Product_ManagermentEntities();
        public ActionResult Index()
        {
            if(Session["idCustom"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCar = (List < CartModel >) Session["cart"];
                Order obj = new Order();
                obj.NameProduct = "Đon hàng" + DateTime.Now.ToString("yyyyMMddmmss");
                obj.idCus = Session["idCustom"].ToString();

                obj.pay = "Tiền Mặt";
                obj.CreateOrder = DateTime.Now;
               
                obj.Status = true;
                objproduct.Orders.Add(obj);

                objproduct.SaveChanges();

                int id = obj.idOrder;
                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach(var item in lstCar)
                {
                    OrderDetail objdetail = new OrderDetail();
                    objdetail.Quantity = item.Quantity;
                    objdetail.OrderId = id;
                    objdetail.ProductId = item.Product.BARCODE;

                    lstOrderDetail.Add(objdetail);
                }
                objproduct.OrderDetails.AddRange(lstOrderDetail);
                objproduct.SaveChanges();
                Session["count"] = 0;
            }
            return View();
        }
       
    }
}