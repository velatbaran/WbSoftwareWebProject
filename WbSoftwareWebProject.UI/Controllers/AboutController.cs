using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WbSoftwareWebProject.BusinessLayer;
using WbSoftwareWebProject.Entities.Entity;
using WbSoftwareWebProject.UI.Filters;

namespace WbSoftwareWebProject.UI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager();

        [Auth]
        [HttpGet]
        public ActionResult Index()
        {
            return View(aboutManager.Find(x => x.Id == 1));
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(About about, HttpPostedFileBase ProfileImage)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");

            if (ModelState.IsValid)
            {
                About a = aboutManager.Find(x => x.Id == about.Id);
                if (ProfileImage != null && (ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{about.Id}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"~/Content/images/{filename}"));
                    if (string.IsNullOrEmpty(filename) == false)
                    {
                        a.ProfileImage = filename;
                    }
                }

                a.ShortText = about.ShortText;
                a.LongText = about.LongText;
                a.Email = about.Email;
                a.Username = about.Username;
                a.Password = about.Password;
                aboutManager.Update(a);
                return RedirectToAction("Index");
            }
            return View(about);
        }

        public PartialViewResult GetAboutInfo()
        {
            return PartialView(aboutManager.List());
        }    
    }
}