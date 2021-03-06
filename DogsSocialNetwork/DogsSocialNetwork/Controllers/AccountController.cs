﻿using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using DogsSocialNetwork.Providers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DogsSocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        AccountContext db = new AccountContext();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string returnUrl)
        {

            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserLogin, model.Password))
                {
                    // создаем файл Cookie проверки подлинности для полученного имени пользователя
                    FormsAuthentication.SetAuthCookie(model.UserLogin, false); // файл Cookie не сохраняется между сеансами браузера
                    if (Url.IsLocalUrl(returnUrl)) // защита от ложной маршрутизации?
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        var currentUser = GetUser(model.UserLogin);
                        var user = db.Users.Where(x => x.Login.UserLogin == model.UserLogin).FirstOrDefault();
                        return RedirectToAction("Index", "Home", new { userId = user.Id });
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password");
                }
            }
            return View(model);
        }

        private User GetUser(string login)
        {
            User currentUser = null;
            using (var db = new AccountContext())
            {
                currentUser = (from u in db.Users
                               where u.Login.UserLogin == login
                               select u).FirstOrDefault();
            }
            return currentUser;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel regModel)
        {
            try
            {
                foreach (var login in db.Logins)
                {
                    if (login.UserLogin == regModel.Login)
                    {
                        ModelState.AddModelError("", "This nickname was already taken");
                        return View();
                    }
                }

                var log = new Login() { UserLogin = regModel.Login, Password = regModel.Password };

                db.Logins.Add(log);
                var user = new User() { Login = log, Email = regModel.Email, FirstName = regModel.FirstName, LastName = regModel.LastName, RoleId = 2 };
                db.Users.Add(user);

                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { userId = user.Id });
            }
            catch (DbEntityValidationException e)
            {
                ViewBag.Error = "Something went wrong!";
            }
            return View();

            
            
        }
    }

}