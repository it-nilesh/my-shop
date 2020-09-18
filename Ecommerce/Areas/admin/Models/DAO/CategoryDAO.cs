using Ecommerce.Areas.admin.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Models.DAO
{
    public class CategoryDAO
    {


        public List<SelectListItem> ddCategoryList()
        {
            ShopingContext shpContext = new ShopingContext();
            List<SelectListItem> selectItemList = new List<SelectListItem>();
            foreach (category cgt in shpContext.category) 
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = cgt.c_name,
                    Value = cgt.Id.ToString(),
                };
                selectItemList.Add(selectListItem);
            }
            return selectItemList;
        }
    }
}