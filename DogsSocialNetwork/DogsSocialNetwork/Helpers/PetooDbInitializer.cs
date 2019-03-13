using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Helpers
{
    public class PetooDbInitializer : DropCreateDatabaseAlways<AccountContext> //TODO create if not exists
    {
        protected override void Seed(AccountContext context)
        {
            var admin = new Role { Id = 1, Name = "Admin" };
            var user = new Role { Id = 2, Name = "User" };
            context.Roles.AddRange(new List<Role> { admin, user });

            var regLogin = new Login { Password = "regular", UserLogin = "regular" };
            var admLogin = new Login { Password = "admin", UserLogin = "admin" };
            context.Logins.AddRange(new List<Login> { regLogin, admLogin });
            
            var regularUser = new User() { FirstName = "Reqular", LastName = "User", Login = regLogin, Role = user, Email = "reg@reg.com" };
            var adminUser = new User() { FirstName = "Admin", LastName = "Administrator", Login = admLogin, Role = admin };
            context.Users.AddRange(new List<User> { regularUser, adminUser });

            var golden = new Breed { Name = "Golden Retriever" };
            var shitsu = new Breed { Name = "Shih Tzu" };
            var spaniel = new Breed { Name = "Cocker Spaniel" };
            var bigl = new Breed { Name = "Bigl" };
            context.Breeds.AddRange(new List<Breed>() { golden, shitsu, spaniel, bigl });

            var pet = new Pet { Breed = golden, Name = "Archie", User = regularUser, Age = 3, Gender = true };
            var pet1 = new Pet { Breed = shitsu, Name = "Kora", User = regularUser, Age = 5, Gender = false };
            var pet2 = new Pet { Breed = spaniel, Name = "Bonya", User = regularUser, Age = 11, Gender = true };
            var pet3 = new Pet { Breed = bigl, Name = "Sherlock", User = regularUser, Age = 6, Gender = true };
            context.Pets.AddRange(new List<Pet>() { pet, pet1, pet2, pet3 });
            
            base.Seed(context);
        }
    }
}