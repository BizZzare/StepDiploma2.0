using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Helpers
{
    public class PetooDbInitializer : CreateDatabaseIfNotExists<AccountContext>
    {
        protected override void Seed(AccountContext context)
        {
            var admin = new Role { Id = 1, Name = "Admin" };
            var user = new Role { Id = 2, Name = "User" };
            context.Roles.AddRange(new List<Role> { admin, user });

            var regLogin = new Login { Password = "regular", UserLogin = "regular" };
            var admLogin = new Login { Password = "admin", UserLogin = "admin" };
            context.Logins.AddRange(new List<Login> { regLogin, admLogin });

            var regularUser = new User() { FirstName = "Reqular", LastName = "User", Login = regLogin, Role = user };
            var adminUser = new User() { FirstName = "Admin", LastName = "Administrator", Login = admLogin, Role = admin };
            context.Users.AddRange(new List<User> { regularUser, adminUser });

            base.Seed(context);
        }
    }
}