using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogsSocialNetwork.Helpers
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("PetooDb")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Ancestry> Ancestries { get; set; }

    }
}