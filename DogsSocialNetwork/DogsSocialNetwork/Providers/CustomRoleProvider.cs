using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DogsSocialNetwork.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override void CreateRole(string roleName)
        {
            var newRole = new Role() { Name = roleName };
            var db = new AccountContext();
            db.Roles.Add(newRole);
            db.SaveChanges();
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (var db = new AccountContext())
            {
                try
                {
                    // Получаем пользователя
                    var user = (from u in db.Users
                                     from l in db.Logins
                                     where l.UserLogin == username && u.Login == l
                                     select u).FirstOrDefault();
                    //User user = (from u in db.Users
                    //             where u.Login == username
                    //             select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        Role userRole = db.Roles.Find(user.RoleId);

                        if (userRole != null)
                        {
                            roles = new string[] { userRole.Name };
                        }
                    }
                }

                catch
                {
                    roles = new string[] { };
                }
            }
            return roles;
        }

        public override bool IsUserInRole(string username, string roleName)
        {

            bool outputResult = false;
            // Находим пользователя
            using (var db = new AccountContext())
            {
                try
                {
                    // Получаем пользователя
                    User user = (from u in db.Users
                                     from l in db.Logins
                                     where l.UserLogin == username && u.Login == l
                                     select u).FirstOrDefault();
                    //User user = (from u in db.Users
                    //             where u.Login == username
                    //             select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        Role userRole = db.Roles.Find(user.RoleId);

                        //сравниваем
                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }

        #region NotImplemented

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}