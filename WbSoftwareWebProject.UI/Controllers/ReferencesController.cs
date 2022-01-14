using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WbSoftwareWebProject.BusinessLayer;
using WbSoftwareWebProject.Entities.Entity;
using WbSoftwareWebProject.UI.Filters;

namespace WbSoftwareWebProject.UI.Controllers
{
    public class ReferencesController : Controller
    {
        private ReferencesManager referencesManager = new ReferencesManager();

        [Auth]
        public ActionResult Index()
        {
            return View(referencesManager.List());
        }

        public ActionResult ReferencesModalShow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ProjectId = id.Value;
            return PartialView("PartialAddReferences");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddReferences(References references)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                if (referencesManager.Insert(references) > 0)
                    return Json(new { hasError = false, Message = "Referans bilgisi başarılı bir şekilde kaydedilmiştir.Gerekli kontroller yapıldıktan sonra yayınlanacaktır." });
                else
                    return Json(new { hasError = true, Message = "Kayıt yapılırken hata meydana geldi." });
            }

            return View(references);
        }

        public ActionResult GetAllReferences()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            References references = referencesManager.Find(x => x.Id == id.Value);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        [HttpPost]
        public ActionResult Edit(References references)
        {
            References r = referencesManager.Find(x => x.Id == references.Id);
            r.CommentStatus = references.CommentStatus;
            if (referencesManager.Update(r) > 0)
                return RedirectToAction("Index");
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            References references = referencesManager.Find(x => x.Id == id.Value);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }
    }
}