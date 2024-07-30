using DLTriviaTap;
using MODELSTriviaTap;
using System.Collections.Generic;

namespace BLTriviaTap
{
    public class UserGetServices
    {
        public List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();

        }



        public User GetUser(string username, string password)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username && user.password == password)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public User GetUser(string username)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }
}