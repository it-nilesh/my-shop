using Ecommerce.Areas.admin.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            int c_id;
            List<OrderView> orderList = new List<OrderView>();
            try
            {
                OrderView Ov;
                c_id = ((Ecommerce.Models.Register.RegisterPro)Session["userId"]).Id;
                Ecommerce.Areas.admin.Models.ShopingContext shpoing = new Ecommerce.Areas.admin.Models.ShopingContext();
                foreach (Order ord in shpoing.Order.Where(x => x.c_id == c_id).ToList())
                {
                    Ov = new OrderView();
                    Ov.c_id = ord.c_id;
                    Ov.date = ord.date;
                    Ov.imageurl = shpoing.uploadImage.Where(x => x.p_id == ord.p_id).FirstOrDefault().imageURL;
                    Ov.order_status = ord.order_status;
                    Ov.OrderDetailsID = ord.OrderDetailsID;
                    Ov.OrderId = ord.OrderId;
                    Ov.p_id = ord.p_id;
                    Ov.price = ord.price;
                    Ov.productname = shpoing.product.Where(x => x.Id == ord.p_id).FirstOrDefault().p_name;
                    Ov.qty = ord.qty;
                    Ov.status = getStatus(ord.order_status);
                    orderList.Add(Ov);
                }
            }
            catch (Exception ex)
            {
            }
            return View(orderList);
        }

        public string getStatus(int i)
        {
            if (i == 1)
                return "Peinding";
            else if (i == 2)
                return "Dispatch";
            else if (i == 3)
                return "Deleverd";
            else if (i == 4)
                return "Complete";
            else
                return "Process In Completed";
        }
    }
}
