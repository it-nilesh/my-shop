using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Category
{
    [Table("tblCategory")]
    public class category
    {
        public int Id { set; get; }
        [DisplayAttribute(Name = "Category Name")]
        [Required]
        public string c_name { set; get; }
        public int c_prent_id { set; get; }
        [DefaultValue(1)]
        public int c_IsActive { set; get; }


    }
}