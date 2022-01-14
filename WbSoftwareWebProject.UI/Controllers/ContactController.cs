using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WbSoftwareWebProject.BusinessLayer;
using WbSoftwareWebProject.Common.Helpers;
using WbSoftwareWebProject.Entities.Entity;
using WbSoftwareWebProject.Entities.ValueObjectModel;
using WbSoftwareWebProject.UI.Filters;

namespace WbSoftwareWebProject.UI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager();
        public ActionResult GetContactInfo()
        {
            return PartialView(contactManager.List());
        }

        [Auth]
        [HttpGet]
        public ActionResult Index()
        {
            return View(contactManager.Find(x => x.Id == 1));
        }

        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Index(Contact contact)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");

            if (ModelState.IsValid)
            {
                Contact c = contactManager.Find(x => x.Id == 1);
                c.Address = contact.Address;
                c.Instagram = contact.Instagram;
                c.Telegram = contact.Telegram;
                c.Twitter = contact.Twitter;
                c.Github = contact.Github;
                c.Email = contact.Email;
                c.Phone = contact.Phone;
                if (contactManager.Update(c) > 0)
                {
                    return RedirectToAction("Index");
                }
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendMessageByMail(string name = "", string email = "", string subject = "", string phone = "", string message = "")
        {
            if (string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(email) == false && string.IsNullOrEmpty(subject) == false && string.IsNullOrEmpty(message) == false)
            {
                string body = $"Ad Soyad: {name};<br> Eposta : {email};<br> İrtibat No : {phone};<br> Mesaj : {message} ";
                MailHelper.SendMail(body, "baranvelat021@gmail.com", subject, true);
                return Json(new { hasError = false, trueMessage = "Mesajınız başarılı bir şekilde gönderilmiştir." });
            }
            return Json(new { hasError = true, errorMessage = "Mesaj gönderilirken hata oluştu" });
        }
    }
}