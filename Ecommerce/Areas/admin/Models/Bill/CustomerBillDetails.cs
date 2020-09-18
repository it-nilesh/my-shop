using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Bill
{
    public class CustomerBillDetails
    {
        public string custId { set; get; }
        public string custname { set; get; }
        public string custaddr { set; get; }
        public string custemail { set; get; }
        public string custphone { set; get; }
        public string custpincode { set; get; }
        public string orderdate { set; get; }
        public string totalpric { set; get; }
        public string totalqty { set; get; }
        public string orderId { set; get; }
    }
    public class billproduct
    {
        public float productprice { set; get; }
        public int productqty { set; get; }
        public string productname { set; get; }
        public double actualprice { set; get; }
    }
}