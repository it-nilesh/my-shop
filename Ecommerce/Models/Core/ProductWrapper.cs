using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Core
{
    public class ProductWrapper
    {

        public int id { set; get; }
        public string categoryname { set; get; }

        public List<Ecommerce.Areas.admin.Models.Product.Product> productList { set; get; }
    }

    [NotMapped]
    public class productWrapperBrand : Ecommerce.Areas.admin.Models.Product.Product 
    {
        public string brandName { set; get; }
        public int Brand_Id { set; get; }
        public string ImageURL { set; get; }

    }

}