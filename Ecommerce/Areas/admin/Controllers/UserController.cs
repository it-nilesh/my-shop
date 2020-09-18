using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class UserController : Controller
    {
        [UserAuthorizeAttribute()]
        public ActionResult Index()
        {
            ShopingContext SHC = new ShopingContext();
            List<User> UserList = SHC.User.ToList();
            return View(UserList);
        }

    }
}
