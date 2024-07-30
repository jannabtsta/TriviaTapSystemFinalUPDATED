namespace BLTriviaTap
{
    public class VerificationServices
    {

        UserGetServices getservices = new UserGetServices();
        TriviaServices gettrivia = new TriviaServices();

        public bool CheckIfUserNameExists(string username)
        {
            bool result = getservices.GetUser(username) != null;
            return result;
        }

        public bool CheckIfUserExists(string username, string password)
        {
            bool result = getservices.GetUser(username, password) != null;
            return result;
        }

        public bool CheckIfTriviaExists(string questions)
        {
            bool result = gettrivia.GetTrivia(questions) != null;
            return result;
        }

        public bool CheckIfTriviaExists(string questions, string answers)
        {
            bool result = gettrivia.GetTrivia(questions, answers) != null;
            return result;
        }
    }
}
