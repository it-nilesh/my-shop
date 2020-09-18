using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Brand;
using Ecommerce.Areas.admin.Models.Category;
using Ecommerce.Areas.admin.Models.DAO;
using Ecommerce.Areas.admin.Models.Order;
using Ecommerce.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /admin/Home/
        [UserAuthorizeAttribute()]
        public ActionResult Index()
        {
            ShopingContext shpContext = new ShopingContext();
            List<OrderDetails> odlist = shpContext.OrderDetails.ToList();
            List<FullOrderDetails> FullOrderDetailsList = new List<FullOrderDetails>();
            foreach (OrderDetails OD in odlist)
            {
                FullOrderDetails FOD = new FullOrderDetails();
                FOD.c_id = OD.c_id;
                FOD.Id = OD.Id;
                FOD.datetime = OD.datetime;
                FOD.status = OD.status;
                FOD.totalPrice = OD.totalPrice;
                FOD.totalQty = OD.totalQty;
                FOD.username = shpContext.User.Where(x => x.Id == OD.c_id).FirstOrDefault().fullname;
                FullOrderDetailsList.Add(FOD);
            }
            return View(FullOrderDetailsList);
        }

        [HttpGet]
        [ActionName("Login")]
        public ActionResult Login_Get() 
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_Post(string USERNAME, string password)
        {
            try
            {
                ShopingContext shopingContext = new ShopingContext();
                Ecommerce.Areas.admin.Models.User.User loginsuccess =
                    shopingContext.User.Single(x => x.email == USERNAME && x.password == password
                                                && x.UserType == "admin");
                loginsuccess = loginsuccess == null ? null : loginsuccess;
                if (loginsuccess != null)
                {
                    Session["userId"] = loginsuccess;
                    return RedirectToAction("Index", "Home");
                }
            

            }
            catch { }
            return View();
        }
        public ActionResult Logout() 
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("/");
            return View();
        }
        [UserAuthorizeAttribute()]
        public ActionResult UploadImage()
        {
            return View();
        }
       
    }
}
