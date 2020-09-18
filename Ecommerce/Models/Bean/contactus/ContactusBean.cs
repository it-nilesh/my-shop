using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ecommerce.Models.Bean.contactus
{
    public class ContactusBean
    {
        [DisplayAttribute(Name = "Name")]
        [Required]
        public string name { set; get; }
        [DisplayAttribute(Name = "Subject")]
        [Required]
        public string subject { set; get; }
        [DisplayAttribute(Name = "E-mail")]
        [Required]
        public string email { set; get; }
        [DisplayAttribute(Name = "Comment")]
        [Required]
        public string commnet { set; get; }
    }
}