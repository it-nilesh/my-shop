using Ecommerce.Models;
using Ecommerce.Models.Bean.Login;
using Ecommerce.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post()
        {

            LoginBean loginBean = new LoginBean();
            TryUpdateModel(loginBean);
            if (ModelState.IsValid)
            {
                ShopingContext shopingContext = new ShopingContext();
                RegisterPro loginsuccess = shopingContext.registerPro.Single(x => x.email == loginBean.email && x.password == loginBean.password && x.UserType == "user");
                loginsuccess = loginsuccess == null ? null : loginsuccess;
                Session["userId"] = loginsuccess;
            }
            if (Session["userId"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}
