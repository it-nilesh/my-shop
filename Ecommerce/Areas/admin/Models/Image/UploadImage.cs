using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Image
{
    [Table("ProductImage")]
    public class UploadImage
    {
        public int Id { set; get; }

        [DisplayAttribute(Name = "Select Product")]
        [Required]
        public int p_id { set; get; }

       
        public string imageURL { set; get; }
        public int isActive { set; get; }
    }
}