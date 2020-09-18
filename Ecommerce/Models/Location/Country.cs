using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Location
{

    [Table("tblCountry")]
    public class Country
    {
        public int CountryId { set; get; }
        public string CountryName { set; get; }
    }
}