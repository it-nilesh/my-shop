using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class ProductController : Controller
    {

        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get(string id)
        {
            getBrand();
            getCategory();
            if (!string.IsNullOrEmpty(id))
            {
                Product pr = new Product();
                ShopingContext shpContext = new ShopingContext();
                int Id = Convert.ToInt32(id);
                pr = shpContext.product.Where(x => x.Id == Id).FirstOrDefault();
                return View(pr);
            }
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        [ValidateInput(false)]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Post(string id)
        {
            Product product = new Product();
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                product.p_IsActive = 1;
                ShopingContext shpContext = new ShopingContext();
                if (string.IsNullOrEmpty(id))
                {
                    shpContext.product.Add(product);
                }
                else
                {
                    product.Id = Convert.ToInt32(id);
                    shpContext.Entry(product).State = System.Data.EntityState.Modified;
                }
                shpContext.SaveChanges();
            }
            getBrand();
            getCategory();
            if (product.Id > 0)
            {
                return RedirectToAction("Index", "Image", new { Id = product.Id });
            }
            return View();
        }

        public void getBrand()
        {
            ShopingContext shpContext = new ShopingContext();
            ViewBag.brandList = new SelectList(shpContext.brand, "Id", "b_name");
        }
        public void getCategory()
        {
            ShopingContext shpContext = new ShopingContext();
            ViewBag.categoryList = new SelectList(shpContext.category, "Id", "c_name");
        }
        [UserAuthorizeAttribute()]
        public ActionResult List()
        {
            ShopingContext shpContext = new ShopingContext();
            List<Product> pdct = shpContext.product.ToList();
            return View(pdct);
        }
        [UserAuthorizeAttribute()]
        public ActionResult SideMenu()
        {

            return View();
        }

        public ActionResult Delete(string id)
        {

            return RedirectToAction("CartItem","Purchase");
        }

    }
}
