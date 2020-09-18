using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Product
{
    [Table("tblProduct")]
    public class Product
    {

        public int Id { set; get; }
        [DisplayAttribute(Name = "Enter Product Name")]
        [Required]
        public string p_name { set; get; }
        [DisplayAttribute(Name = "Model Name")]
        [Required]
        public string p_model { set; get; }
        [DisplayAttribute(Name = "Description")]
        [Required]
        public string p_short_description { set; get; }
        [DisplayAttribute(Name = "Select Category")]
        public int c_id { set; get; }
        [DisplayAttribute(Name = "Select Brand")]
        public int b_id { set; get; }
        [DisplayAttribute(Name = "Product Price")]
        public double p_price { set; get; }

        [DisplayAttribute(Name = "Long Description")]
        public string p_Log_desc { set; get; }        

        public int p_IsActive { set; get; }
    }
}