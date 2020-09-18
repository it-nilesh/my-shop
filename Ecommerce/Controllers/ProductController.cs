using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Areas.admin.Models.Product;
using Ecommerce.Models.Core;
namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            List<productWrapperBrand> product = new List<productWrapperBrand>();
            int id = 0;
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"].ToString());
            }
            productWrapperBrand productBean;
            ProductWrapper proWrap = new ProductWrapper();
            Ecommerce.Areas.admin.Models.ShopingContext shpoing = new Ecommerce.Areas.admin.Models.ShopingContext();
            var ProductList = shpoing.product.Where(x => x.b_id == id).ToList();
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
                //   proWrap.productList.Add(productBean);
                product.Add(productBean);
            }
            // product.Add(proWrap);
            return View(product);
        }

        [HttpGet]
        [ActionName("Details")]
        public ActionResult Details_GET(int id)
        {
            
            int Id = id;
            if (Request.QueryString["id"] != null)
            {
                Id = int.Parse(Request.QueryString["id"].ToString());
            }
            Ecommerce.Areas.admin.Models.ShopingContext shpoing = new Ecommerce.Areas.admin.Models.ShopingContext();
            Product prod = shpoing.product.Where(x => x.Id == Id).FirstOrDefault();
            ViewBag.imageList = shpoing.uploadImage.Where(x => x.p_id == Id).ToList();
            return View(prod);
        }

        [HttpPost]
        [ActionName("Details")]
        public ActionResult Details_POST()
        {
            string id = Convert.ToString(Request.QueryString["id"]);
            if (new HomeController().AddProduct(id) != null) 
            {
                return RedirectToAction("CartItem", "Purchase");
            }
            return View();
        }

    }
}
