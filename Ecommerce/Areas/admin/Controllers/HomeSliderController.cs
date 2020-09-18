using Ecommerce.Areas.admin.Models;
using Ecommerce.Areas.admin.Models.Image.slider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.admin.Controllers
{
    public class HomeSliderController : Controller
    {
        public string getfileName { set; get; }

        [HttpPost]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Post(HttpPostedFileBase Image_URl, string Decription)
        {
            Slider slider = new Slider();

            uploadFile(Image_URl);
            slider.Image_URl = getfileName;
            slider.Decription = Decription;
            slider.IsActive = 1;
            if (!string.IsNullOrEmpty(getfileName))
            {
                ShopingContext shpContext = new ShopingContext();
                shpContext.HomeSlider.Add(slider);
                shpContext.SaveChanges();
            }
            return View(slider);
        }
        [HttpGet]
        [ActionName("Index")]
        [UserAuthorizeAttribute()]
        public ActionResult Index_Get()
        {
            Slider slider = new Slider();
            return View(slider);
        }

        [UserAuthorizeAttribute()]
        public ActionResult SideMenu()
        {

            return View();
        }
        [UserAuthorizeAttribute()]
        public ActionResult Delete(int id)
        {
            ShopingContext shpContext = new ShopingContext();
            Slider slider = shpContext.HomeSlider.Where(x => x.Id == id).FirstOrDefault();
            shpContext.Entry(slider).State = System.Data.EntityState.Deleted;
            shpContext.SaveChanges();
            return RedirectToAction("List");
        }
        [UserAuthorizeAttribute()]
        public ActionResult List()
        {
            ShopingContext shpContext = new ShopingContext();
            List<Slider> slider = shpContext.HomeSlider.ToList();
            return View(slider);
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
                if (!AllowedFileExtensions.Contains(ext.ToLower()))
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
                    var path = Path.Combine(Server.MapPath("~/Data/Slider"), fileName);
                    file.SaveAs(path);

                    //ViewBag.Message = "File uploaded successfully";
                    filestatus = 1;
                }
            }
            return filestatus;
        }

    }
}
