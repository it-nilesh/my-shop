using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class ImageController : Controller
    {
        
        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get(int id)
        {
            getProduct();
            ProductImages(id);
            ViewBag.id = id;
            return View();
        }
        public string getfileName { set; get; }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(int id,HttpPostedFileBase searchBoxInput)
        {
            ViewBag.id = id;
            UploadImage image = new UploadImage();
            TryUpdateModel(image);
            if (ModelState.IsValid)
            {
                uploadFile(searchBoxInput);
                image.imageURL = getfileName;
                image.isActive = 1;
                image.p_id = id;
                if (!string.IsNullOrEmpty(getfileName))
                {
                    ShopingContext shpContext = new ShopingContext();
                    shpContext.uploadImage.Add(image);
                    shpContext.SaveChanges();
                }
            }
            getProduct();
            ProductImages(id);
            return View();
        }

        public void getProduct()
        {
            ShopingContext shop = new ShopingContext();
            List<SelectListItem> selectItemList = new List<SelectListItem>();
            foreach (Areas.admin.Models.Product.Product pro in shop.product) 
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = "Name : "+pro.p_name + " - Model : " + pro.p_model,
                    Value = pro.Id.ToString()
                };

                selectItemList.Add(selectItem);
            }

            ViewBag.Products = selectItemList;
        }

        public void ProductImages(int id) 
        {
            ShopingContext shop = new ShopingContext();
            ViewBag.Images = shop.uploadImage.Where(x => x.p_id == id).ToList();
        }

        public ActionResult Delete(int id,int Iid) 
        {
            ShopingContext shop = new ShopingContext();
            UploadImage uimp = new UploadImage();
            uimp.Id = Iid;
            shop.Entry(uimp).State = System.Data.EntityState.Deleted;
            shop.SaveChanges();
            return RedirectToAction("Index", new { id=id});
        }


        public int uploadFile(HttpPostedFileBase file)
        {
            int filestatus = 0;
            if (file == null)
            {
                //ModelState.AddModelError("File", "Please Upload Your file");
                filestatus = 0;
            }
            else if (file.ContentLength > 0)
            {
                int MaxContentLength = 1024 * 1024 * 3; //3 MB
                string[] AllowedFileExtensions = new string[] { ".jpg", ".png" };
                string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                if (!AllowedFileExtensions.Contains(ext))
                {
                    //ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    filestatus = 2;
                }

                else if (file.ContentLength > MaxContentLength)
                {
                    //ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    filestatus = 3;
                }
                else
                {
                    //TO:DO
                    var fileName = DateTime.Now.Year + "" + DateTime.Now.Month + "" + DateTime.Now.Day + ""
                        + DateTime.Now.Hour + "" + DateTime.Now.Minute + "" + DateTime.Now.Millisecond + "-" + Path.GetFileName(file.FileName);
                    getfileName = fileName;
                    var path = Path.Combine(Server.MapPath("~/Data/Image"), fileName);
                    file.SaveAs(path);

                    //ViewBag.Message = "File uploaded successfully";
                    filestatus = 1;
                }
            }
            return filestatus;
        }


    }
}