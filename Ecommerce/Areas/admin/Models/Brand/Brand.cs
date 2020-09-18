using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Brand
{
    [Table("tblBrand")]
    public class Brand
    {
        public int Id { set; get; }
        [DisplayAttribute(Name = "Product Brand Name")]
        [Required]
        public string b_name { set; get; }
        public int b_IsActive { set; get; }
    }
}