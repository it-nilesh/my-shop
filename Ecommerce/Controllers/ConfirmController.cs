using Ecommerce.Areas.admin.Models.Order;
using Ecommerce.Models.Bean;
using Ecommerce.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ConfirmController : Controller
    {
        //
        // GET: /Confirm/

        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            Ecommerce.Models.Register.RegisterPro shippingdetails = null;
            try
            {
                shippingdetails =
                    ((Ecommerce.Models.Register.RegisterPro)Session["userId"]);
            }
            catch { }
            return View(shippingdetails);
        }


        public ActionResult PaymentMethod()
        {
            Ecommerce.Models.Register.RegisterPro shippingdetails = null;
            try
            {
                shippingdetails =
                    ((Ecommerce.Models.Register.RegisterPro)Session["userId"]);
            }
            catch { }
            ViewBag.shippingDetails = shippingdetails;
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
                return RedirectToAction("Index", "Home");
            }
            Session["AddList"] = cartList;
            ViewBag.cartAddItem = cartList;
            return View();

        }

        [HttpPost]
        [ActionName("PaymentMethod")]
        public ActionResult PaymentMethod_Post()
        {
            Ecommerce.Areas.admin.Models.ShopingContext shpoing =
                new Ecommerce.Areas.admin.Models.ShopingContext();
            int c_id = ((Ecommerce.Models.Register.RegisterPro)Session["userId"]).Id;
            List<AddToCartBean> cartList = AddToCart.getData();
            if (cartList != null)
            {
                int qty = 0;
                float tprice=0;
                foreach (AddToCartBean bean in cartList)
                {
                    qty = 1 + qty;
                    tprice = tprice + bean.ProductPrice;
                }
                OrderDetails OD = new OrderDetails();
                OD.c_id = c_id;
                OD.datetime = DateTime.Now;
                OD.status = 1;
                OD.totalPrice = tprice;
                OD.totalQty = qty;
                shpoing.OrderDetails.Add(OD);
                shpoing.SaveChanges();
                Order ord;
                foreach (AddToCartBean bean in cartList)
                {
                    int id = Convert.ToInt32(bean.pid);
                    Ecommerce.Areas.admin.Models.Product.Product prod = shpoing.product.Where(x => x.Id == id).FirstOrDefault();
                    ord = new Order();
                    ord.c_id = c_id;
                    ord.OrderDetailsID = OD.Id;
                    ord.date = DateTime.Now;
                    ord.order_status = 1;
                    ord.p_id =Convert.ToInt32(bean.pid);
                    ord.price= bean.ProductPrice * 1;
                    ord.qty = 1;
                    shpoing.Order.Add(ord);
                    shpoing.SaveChanges();
                }
               // Session.Remove("AddList");
            }
            Ecommerce.Models.Register.RegisterPro shippingdetails = null;
            try
            {
                shippingdetails =
                    ((Ecommerce.Models.Register.RegisterPro)Session["userId"]);
            }
            catch { }
            ViewBag.shippingDetails = shippingdetails;
            ViewBag.cartAddItem = (List<AddToCartBean>)Session["AddList"] ;
            return RedirectToAction("ThankYou", "Confirm");
        }

        public ActionResult ThankYou()
        {
            Session.Remove("AddList");
            return View();
        }

    }
}
