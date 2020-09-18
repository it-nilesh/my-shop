using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class SettingController : Controller
    {
        //
        // GET: /admin/Setting/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PromoImage()
        {
            return View();
        }

        public ActionResult HomeSlider()
        {
            return View();
        }
    }
}
