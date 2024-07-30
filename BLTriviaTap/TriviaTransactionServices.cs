using DLTriviaTap;
using MODELSTriviaTap;

namespace BLTriviaTap
{
    public class TriviaTransactionServices
    {
        VerificationServices validationServices = new VerificationServices();
        UserData userData = new UserData();

        //ADD A TRIVIA
        public bool CreateTrivia(Trivia trivia)
        {
            bool result = false;

            if (validationServices.CheckIfTriviaExists(trivia.questions))
            {
              
                result = userData.AddTrivia(trivia) > 0;
            }

            return result;
        }

        public bool CreateTrivia(string questions, string answers)
        {
            Trivia trivias = new Trivia { questions = questions, answers = answers };

            return CreateTrivia(trivias);
        }

        


        //UPDATE THE ANSWER OF A TRIVIA
        public bool UpdateTrivia(string questions, string answers)
        {
            Trivia trivs = new Trivia { questions = questions, answers = answers };

            return UpdateTrivia(trivs);
        }

        public bool UpdateTrivia(Trivia trivia)
        {
            bool result = false;

            if (validationServices.CheckIfTriviaExists(trivia.questions))
            {
                result = userData.UpdateTrivia(trivia) > 0;
            }

            return result;
        }


        //DELETE AS TRIVIA
        public bool DeleteTrivia(Trivia trivia)
        {
            bool result = false;

            if (validationServices.CheckIfTriviaExists(trivia.questions))
            {
                result = userData.DeleteTrivia(trivia) > 0;
            }

            return result;
        }

        public bool DeleteTrivia(string questions)
        {
            Trivia trivia = new Trivia { questions = questions };
            return DeleteTrivia(trivia);
        }



    }
}