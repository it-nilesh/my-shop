using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Location
{
    [Table("tblStates")]
    public class states
    {
        public int Id { set; get; }
        public string StateName { set; get; }
        public int countryId { set; get; }
    }
}