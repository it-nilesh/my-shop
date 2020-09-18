using Ecommerce.Models.Location;
using Ecommerce.Models.Register;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ShopingContext : DbContext
    {
        public DbSet<Country> country { get; set; }
        public DbSet<states> states { get; set; }
        public DbSet<RegisterPro> registerPro { get; set; }
    }
}