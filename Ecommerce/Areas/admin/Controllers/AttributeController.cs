using Ecommerce.Areas.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class AttributeController : Controller
    {
        //
        // GET: /admin/Attribute/

        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get()
        {


            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Post()
        {
            Ecommerce.Areas.admin.Models.Attribute.Attribute attribute = new Ecommerce.Areas.admin.Models.Attribute.Attribute();
            TryUpdateModel(attribute);
            if (ModelState.IsValid)
            {
                attribute.a_isActive = 1;
                ShopingContext shpContext = new ShopingContext();
                shpContext.attribute.Add(attribute);
                shpContext.SaveChanges();
            }
            return View();
        }
    }
}
