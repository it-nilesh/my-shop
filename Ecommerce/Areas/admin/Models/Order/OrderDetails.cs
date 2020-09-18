using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Order
{
    [Table("tblOrderDetails")]
    public class OrderDetails
    {
        
        public int Id { set; get; }
        public int c_id { set; get; }
        [DisplayAttribute(Name = "Order Price")]
        public double totalPrice { set; get; }
        [DisplayAttribute(Name = "Total Qty")]
        public int totalQty { set; get; }
        [DisplayAttribute(Name = "Order Status")]
        public int status { set; get; }
        [DisplayAttribute(Name = "Order Date")]
        public DateTime datetime { set; get; }
    }
    [NotMapped]
    public class FullOrderDetails : OrderDetails
    {
        [DisplayAttribute(Name = "Customer Name")]
        public string username { set; get; }
    }



}