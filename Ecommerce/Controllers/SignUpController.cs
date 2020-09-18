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
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/
        [AcceptVerbs(HttpVerbs.Get)]
        [ActionName("Index")]
        public ActionResult Index_Get()
        {

            getCountry();
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ActionName("Index")]
        public ActionResult Index_Post(string StateID)
        {

            if (StateID == null) 
            {
                getCountry();
                return View();
            }

            ShopingContext shopingContext = new ShopingContext();
            RegisterPro reg = new RegisterPro();
            reg.statesId = int.Parse(StateID);
            reg.UserType = "user";
            TryUpdateModel(reg);
            if (ModelState.IsValid)
            {
                //Add or Inser Data In DataBase
                shopingContext.registerPro.Add(reg);
                shopingContext.SaveChanges();
            }
            getCountry();
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
            
            return Json(statesList);
        }

    }
}
