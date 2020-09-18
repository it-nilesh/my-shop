using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Bill;
using Ecommerce.Areas.admin.Models.Order;
using Ecommerce.Areas.admin.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        [UserAuthorizeAttribute()]
        public ActionResult Index()
        {
            ShopingContext shpContext = new ShopingContext();
            List<OrderDetails> odlist = shpContext.OrderDetails.ToList();
            List<FullOrderDetails> FullOrderDetailsList = new List<FullOrderDetails>();
            foreach (OrderDetails OD in odlist)
            {
                FullOrderDetails FOD = new FullOrderDetails();
                FOD.c_id = OD.c_id;
                FOD.Id = OD.Id;
                FOD.datetime = OD.datetime;
                FOD.status = OD.status;
                FOD.totalPrice = OD.totalPrice;
                FOD.totalQty = OD.totalQty;
                FOD.username = shpContext.User.Where(x => x.Id == OD.c_id).FirstOrDefault().fullname;
                FullOrderDetailsList.Add(FOD);
            }
            return View(FullOrderDetailsList);
        }
        [UserAuthorizeAttribute()]
        public ActionResult Details(int id)
        {
            //ShopingContext SHC = new ShopingContext();
            //var ordercustdetails = (from OD in SHC.OrderDetails
            //                        join O in SHC.Order
            //                          on OD.Id equals O.OrderDetailsID
            //                        join cust in SHC.User
            //                            on OD.c_id equals cust.Id
            //                        where OD.Id == id
            //                        select new
            //                        {
            //                            custId = "" + cust.Id,
            //                            custname = "" + cust.fullname,
            //                            custaddr = "" + cust.address,
            //                            custemail = "" + cust.email,
            //                            custphone = "" + cust.phoneno,
            //                            custpincode = "" + cust.pincode,
            //                            orderdate = "" + OD.datetime,
            //                            totalpric = "" + OD.totalPrice,
            //                            totalqty = "" + OD.totalQty,
            //                            orderId = "MS000" + OD.Id
            //                        });
            //CustomerBillDetails CBD = new CustomerBillDetails();
            ////CBD.custaddr = ordercustdetails.custaddr;
            ////CBD.custemail = ordercustdetails.custemail;
            ////CBD.custId = ordercustdetails.custId;
            ////CBD.custname = ordercustdetails.custname;
            ////CBD.custphone = ordercustdetails.custphone;
            ////CBD.custpincode = ordercustdetails.custpincode;
            ////CBD.orderdate = ordercustdetails.orderdate;
            ////CBD.totalpric = ordercustdetails.totalpric;
            ////CBD.totalqty = ordercustdetails.totalqty;
            ////CBD.orderId = ordercustdetails.orderId;
            //ViewBag.CustDetails = CBD;
            //var productList = (from OD in SHC.OrderDetails
            //                   join O in SHC.Order
            //                     on OD.Id equals O.OrderDetailsID
            //                   join p in SHC.product
            //                   on O.p_id equals p.Id
            //                   where OD.Id == id
            //                   select new
            //                   {
            //                       productprice = O.price,
            //                       productqty = O.qty,
            //                       productname = p.p_name,
            //                       actualprice = p.p_price
            //                   });
            //List<billproduct> ProductList = new List<billproduct>();
            //billproduct pc;
            ////foreach (var data in productList)
            ////{
            ////    pc = new billproduct();
            ////    pc.actualprice = data.actualprice;
            ////    pc.productname = data.productname;
            ////    pc.productprice = data.productprice;
            ////    pc.productqty = data.productqty;
            ////    ProductList.Add(pc);
            ////}
            //ViewBag.ProductList = ProductList;
            return View();
        }
    }
}
