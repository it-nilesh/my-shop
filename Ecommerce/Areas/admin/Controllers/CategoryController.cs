using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Category;
using Ecommerce.Areas.admin.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {

        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get(string id)
        {
            _CategoryList();
            if (!string.IsNullOrEmpty(id))
            {
                category cgt = new category();
                ShopingContext shpContext = new ShopingContext();
                int Id = Convert.ToInt32(id);
                cgt = shpContext.category.Where(x => x.Id == Id).FirstOrDefault();
                ViewBag.addChildCategory = cgt.c_prent_id > 0 ? true : false;
                foreach (SelectListItem selectListItem in ViewBag.CategoryList)
                {
                    if (selectListItem.Value == Convert.ToString(cgt.c_prent_id))
                    {
                        selectListItem.Selected = true;
                    }
                }
                return View(cgt);
            }
            return View();
        }



        [HttpPost]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Post(string id, string CategoryList, bool addChildCategory)
        {

            category cgt = new category();
            TryUpdateModel(cgt);
            if (ModelState.IsValid)
            {
                ShopingContext shpContext = new ShopingContext();
                if (string.IsNullOrEmpty(id))
                {
                    cgt.c_IsActive = 1;

                    if (addChildCategory)
                    {
                        cgt.c_prent_id = int.Parse(CategoryList);
                        shpContext.category.Add(cgt);
                    }
                    else
                    {
                        shpContext.category.Add(cgt);
                    }
                }
                else
                {
                    if (addChildCategory)
                    {
                        cgt.c_prent_id = int.Parse(CategoryList);
                        shpContext.Entry(cgt).State = System.Data.EntityState.Modified;
                    }
                    else
                    {
                        shpContext.Entry(cgt).State = System.Data.EntityState.Modified;
                    }
                }
                int i = shpContext.SaveChanges();
                if (i == 1)
                {
                    return RedirectToAction("List");
                }
            }
            _CategoryList();

            return View();
        }

        private void _CategoryList()
        {
            ViewBag.CategoryList = new CategoryDAO().ddCategoryList();
        }

        [UserAuthorizeAttribute()]
        public ActionResult List()
        {
            ShopingContext spContext = new ShopingContext();
            IEnumerable<category> categoryList = spContext.category.ToList();
            return View(categoryList);
        }
        [UserAuthorizeAttribute()]
        public ActionResult SideMenu()
        {

            return View();
        }
        [UserAuthorizeAttribute()]
        public ActionResult Delete(string id)
        {
            category cgt = new category();
            ShopingContext shpContext = new ShopingContext();
            cgt.Id = Convert.ToInt32(id);
            shpContext.Entry(cgt).State = System.Data.EntityState.Deleted;
            shpContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
