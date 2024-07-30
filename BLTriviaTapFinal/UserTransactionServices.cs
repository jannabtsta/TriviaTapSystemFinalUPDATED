using DLTriviaTap;
using MODELSTriviaTap;

namespace BLTriviaTapFinal
{
    public class UserTransactionServices
    {
        VerificationServices validationServices = new VerificationServices();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string username, string password)
        {
            User user = new User { username = username, password = password };

            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string username, string password)
        {
            User user = new User { username = username, password = password };

            return UpdateUser(user);
        }



        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }

        public bool DeleteUser(string username)
        {
            User user = new User { username = username };
            return DeleteUser(user);
        }


    }
}
