using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Bean.Login
{
    public class LoginBean
    {
        [DisplayAttribute(Name = "E-mail")]
        [Required]
        public string email { set; get; }

        [DisplayAttribute(Name = "Password")]
        [Required]
        public string password { set; get; }
    }
}