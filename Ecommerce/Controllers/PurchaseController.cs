using Ecommerce.Models.Bean;
using Ecommerce.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class PurchaseController : Controller
    {
        //
        // GET: /Purchace/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CartItem()
        {
            Ecommerce.Areas.admin.Models.ShopingContext shpoing = new Ecommerce.Areas.admin.Models.ShopingContext();
            List<AddToCartBean> cartList = AddToCart.getData();
            if (cartList != null)
            {
                foreach (AddToCartBean bean in cartList)
                {
                    int id = Convert.ToInt32(bean.pid);
                    Ecommerce.Areas.admin.Models.Product.Product prod = shpoing.product.Where(x => x.Id == id).FirstOrDefault();
                    bean.ProductName = prod.p_name;
                    bean.ProductPrice = float.Parse(prod.p_price.ToString());
                    bean.ProductQty = 1;
                    bean.TotalPrice = 1 * bean.ProductPrice;
                    bean.ProductImage = shpoing.uploadImage.Where(x => x.p_id == id).FirstOrDefault().imageURL;
                }
            }
            else 
            {
                return RedirectToAction("Index","Home");
            }
            Session["AddList"] = cartList;
            return View(cartList);
        }

        [HttpPost]
        [ActionName("CartItem")]
        public ActionResult CartItem_Post(List<Ecommerce.Models.Bean.AddToCartBean> CARTBEANS) 
        {

            return CartItem();
        }


        public ActionResult Delete(string id) 
        {
            AddToCart.removeToCart(id);
            return RedirectToAction("CartItem", "Purchase");
        }

    }
}
