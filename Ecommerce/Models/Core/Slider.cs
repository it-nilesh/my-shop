using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Core
{
    public class Slider
    {
        public static List<Areas.admin.Models.Image.slider.Slider> GetSlider()
        {
            Areas.admin.Models.ShopingContext spContext = new Areas.admin.Models.ShopingContext();
            return spContext.HomeSlider.OrderByDescending(x=>x.Id).ToList();
        }
    }
}