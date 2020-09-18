using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Areas.admin.Models.User
{
    [Table("Users")]
    public class User
    {
        public int Id { set; get; }
        [DisplayName("Full Name")]
        public string fullname { set; get; }

        [DisplayName("Address")]
        public string address { set; get; }

        [DisplayName("Email")]
        public string email { set; get; }
        [DisplayName("Phone No")]
        public string phoneno { set; get; }
        [DisplayName("Country ID")]
        public int countryId { set; get; }
        [DisplayName("State ID")]
        public int statesId { set; get; }
        [DisplayName("Pin Code")]
        public string pincode { set; get; }
        [DisplayName("User Type")]
        public string UserType { set; get; }
        [DisplayName("Password")]
        public string password { set; get; }
        
    }
}