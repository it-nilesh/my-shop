using Ecommerce.Areas.admin.Models.Product;
using Ecommerce.Models;
using Ecommerce.Models.Bean;
using Ecommerce.Models.Bean.contactus;
using Ecommerce.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : AddToCart
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           // ProductView();
            return View();
        }

        

        public JsonResult ProductView()
        {
            Ecommerce.Areas.admin.Models.ShopingContext shpoing = new Ecommerce.Areas.admin.Models.ShopingContext();
            List<ProductWrapper> product = new List<ProductWrapper>();
            ProductWrapper proWrap;
            productWrapperBrand productBean;
            foreach (Ecommerce.Areas.admin.Models.Category.category cat in shpoing.category)
            {
                proWrap = new ProductWrapper();
                proWrap.id = cat.Id;
                proWrap.categoryname = cat.c_name;

                var ProductList = shpoing.product.Where(x => x.c_id == cat.Id).OrderByDescending(x=>x.Id).Take(5).ToList();
                proWrap.productList = new List<Product>();
                foreach (Ecommerce.Areas.admin.Models.Product.Product produt in ProductList)
                {
                    productBean = new productWrapperBrand();
                    productBean.p_name = produt.p_name;
                    productBean.p_model = produt.p_model;
                    productBean.p_price = produt.p_price;
                    productBean.Id = produt.Id;
                    productBean.c_id = produt.c_id;
                    productBean.brandName = shpoing.brand.Where(x => x.Id == produt.b_id).Single().b_name;
                    try
                    {
                        productBean.ImageURL = shpoing.uploadImage.Where(x => x.p_id == produt.Id).FirstOrDefault().imageURL;
                    }
                    catch 
                    {
                        productBean.ImageURL = "";
                    }
                    productBean.p_short_description = produt.p_short_description;
                    proWrap.productList.Add(productBean);
                }
                product.Add(proWrap);
            }
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddProduct(string pid) 
        {

            AddToCartBean aBean = new AddToCartBean();
            aBean.pid = pid;
            AddToCart.AddCart(aBean);
           return Json(AddToCart.getCartNumberofItem(),JsonRequestBehavior.AllowGet);
        }


        public JsonResult showItem() 
        {

           return Json(AddToCart.getCartNumberofItem(),JsonRequestBehavior.AllowGet);
        }

        

        [HttpGet]
        [ActionName("ContactUs")]
        public ActionResult ContactUs_Get()
        {
            return View();
        }


        [HttpPost]
        [ActionName("ContactUs")]
        public ActionResult ContactUs_Post()
        {
            ContactusBean contactBean = new ContactusBean();
            TryUpdateModel(contactBean);
            if (ModelState.IsValid)
            {
            }
            return View();
        }
    }
}
