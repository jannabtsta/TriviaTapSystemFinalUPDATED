using DLTriviaTap;
using MODELSTriviaTap;


namespace BLTriviaTapFinal
{
    public class TriviaServices
    {
        public List<Trivia> GetAllTrivia()
        {
            UserData userData = new UserData();

            return userData.GetTrivia();

        }

        public Trivia GetTrivia(string questions, string answers)
        {
            Trivia foundtrivia = new Trivia();

            foreach (var trivia in GetAllTrivia())
            {
                if (trivia.questions == questions && trivia.answers == answers)
                {
                    foundtrivia = trivia;
                }
            }

            return foundtrivia;
        }

        public Trivia GetTrivia(string questions)
        {
            Trivia foundtrivia = new Trivia();

            foreach (var trivia in GetAllTrivia())
            {
                if (trivia.questions == questions)
                {
                    foundtrivia = trivia;
                }
            }

            return foundtrivia;
        }
    }
}

