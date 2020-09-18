using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class BrandController : Controller
    {
        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                Brand brand = new Brand();
                ShopingContext shpContext = new ShopingContext();
                int Id = Convert.ToInt32(id);
                brand = shpContext.brand.Where(x => x.Id == Id).FirstOrDefault();
                return View(brand);
            }
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Post(string id)
        {
            Brand brand = new Brand();
            TryUpdateModel(brand);
            if (ModelState.IsValid)
            {
                brand.b_IsActive = 1;
                ShopingContext shpContext = new ShopingContext();
                if (string.IsNullOrEmpty(id))
                {
                    shpContext.brand.Add(brand);
                }
                else 
                {
                    brand.Id = Convert.ToInt32(id);
                    shpContext.Entry(brand).State = System.Data.EntityState.Modified;
                }
             int i =   shpContext.SaveChanges();
             if (i == 1) 
             {
                 return RedirectToAction("List");
             }
            }
            return View();
        }
        [UserAuthorizeAttribute()]
        public ActionResult List()
        {
            ShopingContext shpContext = new ShopingContext();
            IEnumerable<Brand> Brandist = shpContext.brand.ToList();
            return View(Brandist);
        }
        [UserAuthorizeAttribute()]
        public ActionResult SideMenu()
        {

            return View();
        }
        [UserAuthorizeAttribute()]
        public ActionResult Delete(string id)
        {
            Brand brand = new Brand();
            ShopingContext shpContext = new ShopingContext();
            brand.Id = Convert.ToInt32(id);
            shpContext.Entry(brand).State = System.Data.EntityState.Deleted;
            int i = shpContext.SaveChanges();
            if (i == 1)
            {
                return RedirectToAction("List");
            }
            else 
            {
                return RedirectToAction("List");
            }
        }
    }
}
