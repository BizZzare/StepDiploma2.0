using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DogsSocialNetwork.Controllers
{
    public class HomeController : Controller
    {

        #region Common

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

            UserHelper.CurrentUserID = user.Id;

            return View(user);
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
        #endregion

        #region PetStuff

        [Authorize]
        public ActionResult Pets(int userId)
        {
            UserHelper.disliked.Clear();
            var pets = db.Pets.Where(x => x.UserId == userId).Select(x => x).ToList();
            foreach (var pet in pets)
            {
                pet.Breed = db.Breeds.Where(x => x.BreedId == pet.BreedId).Select(x => x).FirstOrDefault();
                pet.User = db.Users.Where(x => x.Id == pet.UserId).Select(x => x).FirstOrDefault();
                pet.Gender = db.Genders.Where(x => x.Id == pet.GenderId).Select(x => x).FirstOrDefault();
            }
            ViewBag.UserId = userId;
            return View(pets);
        }

        public ActionResult PetInfo(int petId)
        {
            var pet = db.Pets.Where(p => p.Id == petId).FirstOrDefault();
            if (pet != null)
            {
                pet.Ancestry = db.Ancestries.Where(a => a.Id == pet.AncestryId).FirstOrDefault();
                pet.Breed = db.Breeds.Where(b => b.BreedId == pet.BreedId).FirstOrDefault();
                pet.Gender = db.Genders.Where(g => g.Id == pet.GenderId).FirstOrDefault();
                pet.User = db.Users.Where(u => u.Id == pet.UserId).FirstOrDefault();
            }

            return View(pet);
        }

        #region Ancestry

        public ActionResult Ancestry(int petId)
        {
            var pet = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();
            var ancestry = db.Ancestries.Where(x => x.Id == pet.AncestryId).FirstOrDefault();

            ViewBag.males = GetPetMaleList(petId);
            ViewBag.females = GetPetFemaleList(petId);
            ViewBag.UserId = pet.UserId;

            UserHelper.CurrentPetID = pet.Id;
            if (ancestry == null)
            {
                var list = db.Ancestries.Select(x => x.Id).ToList();
                list.Sort();
                ancestry = new Ancestry() { Id = 1 + list.LastOrDefault() };
            }

            return View(ancestry);
        }

        [HttpPost]
        public ActionResult Ancestry(Ancestry ancestry)
        {
            var pet = db.Pets.Where(x => x.AncestryId == ancestry.Id).Select(x => x).FirstOrDefault();
            if (pet == null)
                pet = db.Pets.Where(x => x.Id == UserHelper.CurrentPetID).Select(x => x).FirstOrDefault();
            var res = db.Ancestries.SingleOrDefault(p => p.Id == ancestry.Id);

            string filePath = null;

            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];

                filePath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName);

                postedFile.SaveAs(filePath);

                ancestry.DocumentPath = filePath ?? "";
            }

            if (res != null)
            {
                res.MotherId = ancestry.MotherId;
                res.FatherId = ancestry.FatherId;
                res.DocumentPath = ancestry.DocumentPath;

                db.SaveChanges();
            }
            else
            {

                db.Ancestries.Add(ancestry);
                pet.AncestryId = ancestry.Id;
                db.SaveChanges();
            }
            return RedirectToAction("Pets", "Home", new { userId = pet.UserId });
        }

        public ActionResult AncestryDetails(int petId)
        {
            ViewBag.PetId = petId;

            var pet = db.Pets.Where(x => x.Id == petId).FirstOrDefault();
            var ancestry = db.Ancestries.Where(a => a.Id == pet.AncestryId).FirstOrDefault();

            if (ancestry.FatherId != null)
                ancestry.Father = db.Pets.Where(p => p.Id == ancestry.FatherId).First();

            if (ancestry.MotherId != null)
                ancestry.Mother = db.Pets.Where(p => p.Id == ancestry.MotherId).First();

            return View(ancestry);
        }

        #endregion

        #region PairSearch

        public ActionResult PairSearch(int petId)
        {
            UserHelper.CurrentPetID = petId;
            var pet = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();
            var supposedPet = db.Pets
                .Where(x => x.GenderId != pet.GenderId)
                .Where(x => x.BreedId == pet.BreedId)
                .Where(x => !UserHelper.disliked.Contains(x.Id))
                .Where(x => x.UserId != pet.UserId)
                .Select(x => x).FirstOrDefault();

            supposedPet.Breed = db.Breeds.Where(x => x.BreedId == pet.BreedId).Select(x => x).FirstOrDefault();
            return View(supposedPet);
        }

        public ActionResult Like(int petId)
        {
            var pet = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();
            var user = db.Users.Where(x => x.Id == pet.UserId).Select(x => x).FirstOrDefault();

            return View(user);
        }
        public ActionResult Dislike(int petId)
        {
            UserHelper.disliked.Add(petId);
            return RedirectToAction("PairSearch", "Home", new { petId = UserHelper.CurrentPetID });
        }

        #endregion

        #region PetEdit

        [Authorize]
        public ActionResult Create(int userId)
        {
            var breeds = db.Breeds.Select(x => x).ToList();
            ViewBag.breeds = GetBreedsList();
            ViewBag.UserId = userId;
            ViewBag.genders = GetGendersList();
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
            var userID = petToDelete.UserId;
            db.Pets.Remove(petToDelete);
            db.SaveChanges();
            return RedirectToAction("Pets", "Home", new { userId = userID });
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


        #endregion

        #endregion

        #region FileWork

        public ActionResult Upload(int petId)
        {
            UserHelper.CurrentPetID = petId;
            var pet = db.Pets.Where(x => x.Id == petId).Select(x => x).FirstOrDefault();

            return View(pet);
        }

        [HttpPost]
        public ActionResult Upload()  //Here just store 'Image' in a folder in Project Directory 
                                      //  name 'UplodedFiles'
        {
            Pet curPet = db.Pets.Where(x => x.Id == UserHelper.CurrentPetID).FirstOrDefault();
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];

                var filePath = Server.MapPath("~/UploadedFiles/") + Path.GetFileName(postedFile.FileName);

                postedFile.SaveAs(filePath);

                var res = db.Pets.Where(x => x.Id == curPet.Id).FirstOrDefault();

                if (res != null)
                {
                    res.ImagePath = filePath;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Pets", "Home", new { userId = curPet.UserId });
        }
        
        public ActionResult GetImage(string path)
        {
            return File(path, "image/jpg");
        }

        public ActionResult GetDocument(string path)
        {
            return File(path, "application/pdf");
        }

        #endregion

        #region Helpers
        private List<SelectListItem> GetBreedsList()
        {
            var res = new List<SelectListItem>();
            foreach (var breed in db.Breeds.Select(x => x).ToList())
            {
                res.Add(new SelectListItem()
                {
                    Text = breed.Name,
                    Value = breed.BreedId.ToString()
                });
            }
            return res;
        }

        private List<SelectListItem> GetGendersList()
        {
            var res = new List<SelectListItem>();
            foreach (var gender in db.Genders.Select(x => x).ToList())
            {
                res.Add(new SelectListItem()
                {
                    Text = gender.Name,
                    Value = gender.Id.ToString()
                });
            }
            return res;
        }

        private List<SelectListItem> GetPetMaleList(int petId)
        {
            var res = new List<SelectListItem>();
            res.Add(new SelectListItem());
            foreach (var pet in db.Pets.Where(x=>x.GenderId == 1).Where(x=>x.Id != petId).ToList())
            {
                var owner = db.Users.Where(x => x.Id == pet.UserId).FirstOrDefault();
                res.Add(new SelectListItem()
                {
                    Text = $"{pet.Name} ({owner.FirstName} {owner.LastName})" ,
                    Value = pet.Id.ToString()
                });
            }
            return res;
        }

        private List<SelectListItem> GetPetFemaleList(int petId)
        {
            var res = new List<SelectListItem>();
            res.Add(new SelectListItem());
            foreach (var pet in db.Pets.Where(x => x.GenderId == 2).Where(x => x.Id != petId).ToList())
            {
                var owner = db.Users.Where(x => x.Id == pet.UserId).FirstOrDefault();
                res.Add(new SelectListItem()
                {
                    Text = $"{pet.Name} ({owner.FirstName} {owner.LastName})",
                    Value = pet.Id.ToString()
                });
            }
            return res;
        }
        #endregion
    }
}