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
    public class ResumeController : Controller
    {
        ResumeManager resumeManager = new ResumeManager();

        [Auth]
        public ActionResult Index()
        {
            return View(resumeManager.List());
        }

        public PartialViewResult GetResumeInfo()
        {
            return PartialView(resumeManager.IQueryableList().ToList());
        }

        [Auth]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Resume resume)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                if (resumeManager.Insert(resume) > 0)
                {
                    return RedirectToAction("Index");
                }
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        [Auth]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = resumeManager.Find(x => x.Id == id.Value);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Resume resume)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                Resume r = resumeManager.Find(x => x.Id == resume.Id);
                r.Corporation = resume.Corporation;
                r.Task = resume.Task;
                r.Task = resume.Task;
                r.Description = resume.Description;
                r.StartDate = resume.StartDate;
                r.EndDate = resume.EndDate;
                r.IsActive = resume.IsActive;
                r.Address = resume.Address;
                if (resumeManager.Update(r) > 0)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(resume);
        }

        [Auth]
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = resumeManager.Find(x => x.Id == id.Value);
            if (resume == null)
            {
                return HttpNotFound();
            }
            return View(resume);
        }

        [Auth]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resume resume = resumeManager.Find(x => x.Id == id.Value);
            if (resume == null)
            {
                return HttpNotFound();
            }
            resumeManager.Delete(resume);
            return RedirectToAction("Index");
        }
    }
}