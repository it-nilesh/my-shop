using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.Image.slider
{
    [Table("tblSlider")]
    public class Slider
    {
        public int Id { set; get; }
        public string Image_URl { set; get; }
        public string Decription { set; get; }
        public int IsActive { set; get; }
    }
}