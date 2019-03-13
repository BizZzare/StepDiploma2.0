using DogsSocialNetwork.Helpers;
using DogsSocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DogsSocialNetwork.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;
            using (var db = new AccountContext())
            {
                try
                {
                    //User user = (from u in _db.Users
                    //             where u.Email == username
                    //             select u).FirstOrDefault();

                    var user = (from u in db.Users
                                     from l in db.Logins
                                     where l.UserLogin == username && l.Password == password && u.LoginId == l.Id
                                     //where u.Login == username && u.Password == password
                                     select u).FirstOrDefault();

                    if (user != null /*&& Crypto.VerifyHashedPassword(user.Password, password)*/) // сделать шифрование/дешифрование паролей
                    {
                        isValid = true;
                    }
                }
                catch (Exception e)
                {
                    isValid = false;
                }
            }
            return isValid;
        }
        public MembershipUser CreateUser(string lastName, string firstName, string userName, string password, int roleId)
        {
            MembershipUser membershipUser = GetUser(userName, false);

            if (membershipUser == null)
            {
                try
                {
                    using (var db = new AccountContext())
                    {
                        //user.Password = Crypto.HashPassword(password);

                        db.Logins.Add(new Login { UserLogin = userName, Password = password });
                        db.SaveChanges();

                        var user = new User { LastName = lastName, FirstName = firstName, LoginId = db.Logins.AsEnumerable().Last().Id, RoleId = roleId };

                        //if (db.Roles.Find(2) != null)
                        //{
                        //    user.RoleId = 2;
                        //}

                        db.Users.Add(user);
                        db.SaveChanges();

                        return GetUser(userName, false); // получаю MembershipUser
                    }
                }
                catch 
                {
                    return null;
                }
            }
            return null;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                using (var db = new AccountContext())
                {
                    var user = (from u in db.Users
                                 where u.Login.UserLogin == username
                                 select u).FirstOrDefault();

                    Login login = (from l in db.Logins
                                   where l.UserLogin == username
                                   select l).FirstOrDefault();



                    if (login != null)
                    {
                        return new MembershipUser("CustomMembershipProvider", login.UserLogin, null, null, null, null, false, false, DateTime.Now, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        #region NotImplemented
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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}