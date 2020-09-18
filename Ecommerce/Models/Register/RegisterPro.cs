using Ecommerce.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Register
{
    [Table("Users")]
    public class RegisterPro
    {
        [Required]
        public int Id { set; get; }
        [Required]
        [DisplayAttribute(Name = "Full Name")]
        public string fullname { set; get; }
        [Required]
        [DisplayAttribute(Name = "Full Address")]
        public string address { set; get; }
        [Required]
        [DisplayAttribute(Name = "E-Mail")]
        public string email { set; get; }
       
        [Required]
        public string password { set; get; }

        [DisplayAttribute(Name = "Select Country ")]
        [Required]
        public int countryId { set; get; }
        [DisplayAttribute(Name = "Select State ")]
        public int statesId { set; get; }
        [Required]
        public string pincode { set; get; }
        [Required]
        [DisplayAttribute(Name = "Phone No.")]
        public string phoneno { set; get; }

        public string UserType { set; get; }

    }
}