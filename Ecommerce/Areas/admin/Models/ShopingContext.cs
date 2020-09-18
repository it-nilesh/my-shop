using Ecommerce.Areas.admin.Models.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models
{
    public class ShopingContext : DbContext
    {
        public DbSet<Attribute.Attribute> attribute { get; set; }
        public DbSet<Brand.Brand> brand { get; set; }
        public DbSet<Category.category> category { get; set; }
        public DbSet<Product.Product> product { get; set; }
        public DbSet<Image.UploadImage> uploadImage { get; set; }
        public DbSet<Image.slider.Slider> HomeSlider { get; set; }
        public DbSet<Order.Order> Order { get; set; }
        public DbSet<User.User> User { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}