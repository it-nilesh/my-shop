using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Order
{
    [Table("tblOrder")]
    public class Order
    {
        public int OrderId { set; get; }
        public int p_id { set; get; }
        [DisplayName("QTY")]
        public int qty { set; get; }
        public int c_id { set; get; }
        [DisplayName("Price")]
        public double price { set; get; }
        [DisplayName("Order Date")]
        public DateTime date { set; get; }
        [DisplayName("Order Status")]
        public int order_status { set; get; }
        public int OrderDetailsID { set; get; }
    }

    [NotMapped]
    public class OrderView : Order
    {
         [DisplayName("Product Name")]
        public string productname { set; get; }
        public string status { set; get; }
        public string imageurl { set; get; }
    }
}