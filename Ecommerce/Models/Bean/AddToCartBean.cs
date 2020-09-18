using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Bean
{
    public class AddToCartBean
    {
        public string pid { set; get; }
        public string ProductName { set; get; }
        public string ProductImage { set; get; }
        public int ProductQty { set; get; }
        public float ProductPrice { set; get; }
        public float TotalPrice { set; get; }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            AddToCartBean card = (AddToCartBean)obj;
            if ((object)card == null)
            {
                return false;
            }

            //return (int.Parse(pid) == int.Parse(card.pid));
            return (pid == card.pid);

        }

        public override int GetHashCode()
        {
            //prime no for unique record hashtable table banavya kare searching fast table wise
            return 31 * int.Parse(pid);
        }
    }
}