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
    public class ProjectsController : Controller
    {
        ProjectsManager projectsManager = new ProjectsManager();
        ServicesManager servicesManager = new ServicesManager();

        [Auth]
        public ActionResult Index()
        {
            return View(projectsManager.List());
        }

        [Auth]
        [HttpGet]
        public ActionResult Add()
        {
            //List<SelectListItem> servicesList = (from x in servicesManager.List()
            //                                     select new SelectListItem
            //                                     {
            //                                         Text = x.Title,
            //                                         Value = x.Id.ToString()
            //                                     }).ToList();
            //ViewBag.ListServices = servicesList;

            ViewBag.ListServices = new SelectList(servicesManager.List(), "Id", "Title");

            return View();
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add(Projects projects, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                string filename1 = $"Image1_{projects.ProjectName}.{Image1.ContentType.Split('/')[1]}";
                string filename2 = $"Image2_{projects.ProjectName}.{Image2.ContentType.Split('/')[1]}";
                string filename3 = $"Image3_{projects.ProjectName}.{Image3.ContentType.Split('/')[1]}";
                Image1.SaveAs(Server.MapPath($"~/Content/images/projects/{filename1}"));
                Image2.SaveAs(Server.MapPath($"~/Content/images/projects/{filename2}"));
                Image3.SaveAs(Server.MapPath($"~/Content/images/projects/{filename3}"));
                projects.Image1 = filename1;
                projects.Image2 = filename2;
                projects.Image3 = filename3;
                if (projectsManager.Insert(projects) > 0)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(projects);
        }

        [Auth]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = projectsManager.Find(x => x.Id == id.Value);
            if (projects == null)
            {
                return HttpNotFound();
            }
            ViewBag.ListServices = new SelectList(servicesManager.List(), "Id", "Title", projects.ServicesId);

            return View(projects);
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Projects projects, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                Projects p = projectsManager.Find(x => x.Id == projects.Id);

                if (Image1 != null)
                {
                    string filename1 = $"Image1_{projects.ProjectName}.{Image1.ContentType.Split('/')[1]}";
                    Image1.SaveAs(Server.MapPath($"~/Content/images/projects/{filename1}"));
                    p.Image1 = projects.Image1;
                }

                if (Image2 != null)
                {
                    string filename2 = $"Image2_{projects.ProjectName}.{Image2.ContentType.Split('/')[1]}";
                    Image2.SaveAs(Server.MapPath($"~/Content/images/projects/{filename2}"));
                    p.Image2 = projects.Image2;
                }

                if (Image3 != null)
                {
                    string filename3 = $"Image2_{projects.ProjectName}.{Image2.ContentType.Split('/')[1]}";
                    Image3.SaveAs(Server.MapPath($"~/Content/images/projects/{filename3}"));
                    p.Image3 = projects.Image3;
                }


                p.Customer = projects.Customer;
                p.ProjectName = projects.ProjectName;
                p.ProjectDate = projects.ProjectDate;
                p.ServicesId = projects.ServicesId;
                p.UsedTeknologies = projects.UsedTeknologies;
                p.Description = projects.Description;

                if (projectsManager.Update(p) > 0)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(projects);
        }

        [Auth]
        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = projectsManager.Find(x => x.Id == id.Value);
            if (projects == null)
            {
                return HttpNotFound();
            }

            return View(projects);
        }

        [Auth]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projects projects = projectsManager.Find(x => x.Id == id.Value);
            if (projects == null)
            {
                return HttpNotFound();
            }
            if (projectsManager.Delete(projects) > 0)
                return RedirectToAction("Index");
            else
                return View(projects);
        }

        public PartialViewResult GetAllProjects()
        {
            return PartialView(projectsManager.List());
        }

        public ActionResult ProjectDetails(int? id)
        {
            Projects project = projectsManager.Find(x => x.Id == id.Value);
            if (project == null)
            {
                return HttpNotFound();
            }
            return PartialView("PartialProjectDetails", project);
        }
    }
}