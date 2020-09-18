using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Areas.admin.Models;

namespace Ecommerce.Models.Core
{
    public class GenerateMenu
    {

        public static string getMenu()
        {
            Areas.admin.Models.ShopingContext spContext = new Areas.admin.Models.ShopingContext();
            List<Ecommerce.Areas.admin.Models.Category.category> categoryList =
                           spContext.category.Where(x => x.c_prent_id == 0).ToList();
            string menuString = "<ul>";
            foreach (Ecommerce.Areas.admin.Models.Category.category
                                    cat in categoryList)
            {
                var data = (from product in spContext.product
                            join brand in spContext.brand on product.b_id equals brand.Id
                            where product.c_id == cat.Id
                            select brand).Distinct();

                menuString += "<li><a title='Mobile' href='#'>" + cat.c_name + "</a>";
                if (data.Count() != 0)
                {
                    if (data != null)
                    {
                        menuString += "<div class='dd'><ul>";
                        foreach (Ecommerce.Areas.admin.Models.Brand.Brand brand in data)
                        {
                            menuString += "<li><a title='" + brand.b_name + "' href='/Product?id=" + brand.Id + "'>" + brand.b_name + "</a></li>";
                        }
                        menuString += "</ul></div>";
                    }
                }
                menuString += "</li>";
            }
            menuString += "</ul>";
            return menuString;
        }









    }
}