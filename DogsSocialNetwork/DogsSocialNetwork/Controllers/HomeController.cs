using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DogsSocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        AccountContext db;
        public HomeController()
        {
            db = new AccountContext();
        }

        [Authorize]
        public ActionResult Index(int? userId)
        {
            if (userId == null)
                return RedirectToAction("Login", "Account");
            var user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            return View(user);
        }

        [Authorize]
        public ActionResult Pets(int userId)
        {
            var pets = db.Pets.Where(x => x.UserId == userId).Select(x=>x).ToList();
            foreach (var pet in pets)
            {
                pet.Breed = db.Breeds.Where(x => x.BreedId == pet.BreedId).Select(x => x).FirstOrDefault();
                pet.User = db.Users.Where(x => x.Id == pet.UserId).Select(x => x).FirstOrDefault();
            }
            ViewBag.UserId = userId;
            return View(pets);
        }

        [Authorize]
        public ActionResult Create(int userId)
        {
            var breeds = db.Breeds.Select(x => x).ToList();
            ViewBag.breeds = GetBreedsList();
            ViewBag.UserId = userId;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();

            return RedirectToAction("Pets", "Home", new { userId = pet.UserId });
        }

        [Authorize]
        public ActionResult Delete(int petId)
        {
            var petToDelete = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();
            db.Pets.Remove(petToDelete);
            db.SaveChanges();
            return RedirectToAction("Pets", "Home", new { userId = petToDelete.UserId });
        }

        [Authorize]
        public ActionResult Edit(int petId)
        {
            var petToEdit = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();
            ViewBag.breeds = GetBreedsList();
            ViewBag.UserId = petToEdit.UserId;

            return View(petToEdit);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Pet pet)
        {
            var res = db.Pets.SingleOrDefault(p => p.Id == pet.Id);
            if (res != null)
            {
                res.Name = pet.Name;
                res.Gender = pet.Gender;
                res.BreedId = pet.BreedId;
                res.Age = pet.Age;

                db.SaveChanges();
            }
            return RedirectToAction("Pets", "Home", new { userId = res.UserId });
        }

        private List<SelectListItem> GetBreedsList()
        {
            var res = new List<SelectListItem>();
            foreach (var breed in db.Breeds.Select(x=>x).ToList())
            {
                res.Add(new SelectListItem()
                {
                    Text = breed.Name,
                    Value = breed.BreedId.ToString()
                });
            }
            return res;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}