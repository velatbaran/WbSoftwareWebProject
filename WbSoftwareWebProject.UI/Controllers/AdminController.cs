using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WbSoftwareWebProject.BusinessLayer;
using WbSoftwareWebProject.Common.Helpers;
using WbSoftwareWebProject.Entities.Entity;
using WbSoftwareWebProject.Entities.ValueObjectModel;
using WbSoftwareWebProject.UI.Filters;
using WbSoftwareWebProject.UI.Models;

namespace WbSoftwareWebProject.UI.Controllers
{
    public class AdminController : Controller
    {
        AboutManager aboutManager = new AboutManager();

        [Auth]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email = "", string password = "")
        {
            string _password = Crypto.Hash(password.ToString(), "MD5");
            var user = aboutManager.Find(x => x.Email == email && x.Password == _password);
            if (user != null)
            {
                CurrentSession.Set<About>("login", user);
                return Json(new { hasError = false, Message = "Giriş işleminiz başarılı bir şekilde gerçekleşmiştir." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { hasError = true, Message = "Giriş yaparken hata meydana geldi." }, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult LogOut()
        {
            CurrentSession.Clear();
            return View("Login");
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordViewModel model)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int yenisayi = rnd.Next();
                string pass = Crypto.Hash(yenisayi.ToString(), "MD5");
                var user = aboutManager.Find(x => x.Email == model.Email);
                user.Password = pass;
                aboutManager.Update(user);
                string body = $"Merhaba {user.Email};<br><br> Yeni Şifreniz : {yenisayi} ";
                MailHelper.SendMail(body, model.Email, "Yeni Şifre Talebi", true);
                ViewBag.Message = "Şifreniz başarılı bir şekilde gönderilmiştir.";
                return View("ForgetPassword");
            }
            return View(model);
        }

        [Auth]
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [Auth]
        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordViewmModel model)
        {
            ModelState.Remove("UpdatedOn");
            ModelState.Remove("SavedUsername");
            if (ModelState.IsValid)
            {
                var user = aboutManager.Find(x => x.Email == CurrentSession.User.Email);
                string newPassword = Crypto.Hash(model.Password.ToString(), "MD5");
                user.Password = newPassword;
                if (aboutManager.Update(user) > 0)
                    ViewBag.Message = true;

                else
                    ViewBag.Message = false;
                return View("ResetPassword");
            }

            return View(model);
        }
    }
}