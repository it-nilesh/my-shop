using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Attribute
{
    [Table("Attribute")]
    public class Attribute
    {

        public int Id { set; get; }
        [DisplayAttribute(Name = "Enter Attribute Name")]
        [Required]
        public string a_name { set; get; }
        public int a_isActive { set; get; }

    }
}