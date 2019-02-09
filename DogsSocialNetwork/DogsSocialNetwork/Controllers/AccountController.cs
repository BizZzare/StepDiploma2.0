using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using DogsSocialNetwork.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DogsSocialNetwork.Controllers
{
    public class AccountController : Controller
    {
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
                        return RedirectToAction("Index", "Home", currentUser);
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
        public ActionResult Register(User usr)
        {
            var provider = new CustomMembershipProvider();

            var user = provider.CreateUser(usr.LastName, usr.FirstName, usr.Login.UserLogin, usr.Login.Password, 0);

            if (user != null)
            {
                return RedirectToAction("Index", "Home", usr);
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong");
            }
            return View(usr);
        }
    }

}