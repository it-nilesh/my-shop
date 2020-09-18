using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (httpContext.Session["UserID"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("~/Admin/Home/Login");
                return false;
            }
        }
    }
}