using Ecommerce.Models;
using Ecommerce.Models.Location;
using Ecommerce.Models.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        [AcceptVerbs(HttpVerbs.Get)]
        [ActionName("Index")]

        public ActionResult Index_Get()
        {
            ShopingContext shopingContext = new ShopingContext();
            int c_id = 0;
            try
            {
                 c_id = ((Ecommerce.Models.Register.RegisterPro)Session["userId"]).Id;
                getCountry();
            }
            catch {
                Response.Redirect("~/Home/");
            }

            RegisterPro regpro = shopingContext.registerPro.Where(x => x.Id == c_id).FirstOrDefault();
            GetState(regpro.countryId);
            return View(regpro);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("Index")]
        public ActionResult Index_Post(string statesId)
        {
            if (statesId == null)
            {
                getCountry();
                return View();
            }
            ShopingContext shopingContext = new ShopingContext();
            RegisterPro reg = new RegisterPro();
            reg.statesId = int.Parse(statesId);
            reg.UserType = "user";
            TryUpdateModel(reg);
            if (ModelState.IsValid)
            {
                //Add or Inser Data In DataBase
                shopingContext.Entry(reg).State = System.Data.EntityState.Modified;
                shopingContext.SaveChanges();
            }
            getCountry();
            GetState(reg.countryId);
            return View();
        }
        private void getCountry()
        {
            ShopingContext shopingContext = new ShopingContext();
            List<Country> countryList = shopingContext.country.ToList();
            ViewBag.CountryList = new SelectList(countryList, "CountryId", "CountryName");
        }
        public JsonResult GetState(int country)
        {
            ShopingContext shopingContext = new ShopingContext();
            List<states> statesList = shopingContext.states.Where(x => x.countryId == country).ToList();
            ViewBag.States = new SelectList(statesList, "Id", "StateName");
            return Json(statesList);
        }
    }
}
