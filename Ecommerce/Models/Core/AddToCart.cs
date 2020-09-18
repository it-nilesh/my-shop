using Ecommerce.Models.Bean;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Ecommerce.Models.Core
{
    public class AddToCart : Controller
    {

        public static List<AddToCartBean> AddCart(AddToCartBean addItem)
        {
            Page page = new Page();
            List<AddToCartBean> aBeanList = null;
            try
            {
                aBeanList = (List<AddToCartBean>)page.Session["AddList"];
                if (aBeanList == null)
                {
                    aBeanList = new List<AddToCartBean>();
                }

                if (!aBeanList.Contains(addItem))
                {
                    if (!aBeanList.Equals(addItem))
                    {
                        addItem.TotalPrice = addItem.ProductQty * addItem.ProductPrice;
                        aBeanList.Add(addItem);
                    }
                }
                page.Session["AddList"] = aBeanList;
            }
            catch
            {
                if (!aBeanList.Contains(addItem))
                {
                    if (!aBeanList.Equals(addItem))
                    {
                        addItem.TotalPrice = addItem.ProductQty * addItem.ProductPrice;
                        aBeanList.Add(addItem);
                    }
                }
                page.Session["AddList"] = aBeanList;
            }
            return aBeanList;
        }

        public void ClearCart()
        {
            Session.Remove("AddList");
        }

        public static List<AddToCartBean> getData()
        {
            Page pg = new Page();
            return ((List<AddToCartBean>)pg.Session["AddList"]);
        }

        public static void Updatqty(string id, int qty)
        {
            Page pg = new Page();
            foreach (AddToCartBean Cart in (List<AddToCartBean>)pg.Session["AddList"])
            {
                if (Cart.pid.Equals(id))
                {
                    Cart.ProductQty = qty;
                    Cart.TotalPrice = Cart.ProductPrice * Cart.ProductQty;
                    break;
                }
            }
        }
        public static void removeToCart(string id)
        {
            Page pg = new Page();
            List<AddToCartBean> CartList = (List<AddToCartBean>)pg.Session["AddList"];
            int index = 0;
            foreach (AddToCartBean Cart in CartList)
            {
                if (Cart.pid.Equals(id.Trim()))
                {
                    break;
                }
                index++;

            }
            CartList.RemoveAt(index);
            pg.Session["AddList"] = CartList;
        }

        public static string getCartNumberofItem()
        {
            try
            {
                Page pg = new Page();

                List<AddToCartBean> CartList = (List<AddToCartBean>)pg.Session["AddList"];
                if (CartList == null)
                {
                    return "0";
                }
                else
                {
                    return CartList.Count.ToString();
                }
            }
            catch
            {
                return "0";
            }
        }

        public static string getTotalAmount()
        {
            float total = 0;

            Page pg = new Page();

            List<AddToCartBean> CartList = (List<AddToCartBean>)pg.Session["AddList"];
            foreach (AddToCartBean cart in CartList)
            {
                total = cart.TotalPrice + total;
            }
            return "" + total;

        }
    }
}