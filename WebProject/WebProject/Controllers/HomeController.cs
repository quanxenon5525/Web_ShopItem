using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebProject.dbEntities;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        Product_ManagermentEntities  obj = new Product_ManagermentEntities();
        public ActionResult Index()
        {
            HomeModel homeproduct = new HomeModel();
            homeproduct.ListGroupProduct = obj.GroupProducts.ToList();
            homeproduct.ListProduct = obj.Products.ToList();
            homeproduct.ListSource = obj.Sources.ToList();
            
            return View(homeproduct);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        public string random_syntax()
        {
            const string src = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = 16;
            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Customer _user)
        {
            if (ModelState.IsValid)
            {

                var check = obj.Customers.FirstOrDefault(s => s.Email == _user.Email);
               
                if (check == null)
                {
                    _user.password = GetMD5(_user.password);
                 
                    obj.Configuration.ValidateOnSaveEnabled = false;
                   
                    _user.idCustom = "@" + DateTime.Now.Second + random_syntax();
                  
                 obj.Customers.Add(_user);
                       
                        obj.SaveChanges();
                    
                  
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = obj.Customers.Where(s => s.Email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idCustom"] = data.FirstOrDefault().idCustom;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
    }
}