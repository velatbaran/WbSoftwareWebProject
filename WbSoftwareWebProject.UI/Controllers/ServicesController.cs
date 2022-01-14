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
    public class ServicesController : Controller
    {
        ServicesManager servicesManager = new ServicesManager();

        [Auth]
        public ActionResult Index()
        {
            return View(servicesManager.IQueryableList().ToList());
        }

        public ActionResult GetAllServices()
        {
            return PartialView(servicesManager.IQueryableList().ToList());
        }

        [Auth]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Auth]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(Services services)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");

            if (ModelState.IsValid)
            {
                servicesManager.Insert(services);
                return RedirectToAction("Index");
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
            Services services = servicesManager.Find(x => x.Id == id.Value);
            if (services == null)
            {
                return HttpNotFound();
            }

            return View(services);
        }

        [Auth]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(Services services)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");

            if (ModelState.IsValid)
            {
                Services s = servicesManager.Find(x => x.Id == services.Id);
                s.Title = services.Title;
                s.Description = services.Description;
                servicesManager.Update(s);
                return RedirectToAction("Index");
            }

            return View(services);
        }

        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Services services = servicesManager.Find(x => x.Id == id.Value);
            if (services == null)
            {
                return HttpNotFound();
            }
            servicesManager.Delete(services);
            return RedirectToAction("Index");
        }
    }
}