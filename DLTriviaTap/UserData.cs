using System.Collections.Generic;
using MODELSTriviaTap; 

namespace DLTriviaTap
{
    public class UserData
    {
        List<User> users;
        SqlDbData sqlData;

        List<Trivia> trivia;
        SqlDbTrivia sqltrivia;

        public UserData()
        {
            users = new List<User>();
            sqlData = new SqlDbData();

            trivia = new List<Trivia>();
            sqltrivia = new SqlDbTrivia();
        }

        public List<User> GetUsers()
        {
            return sqlData.GetUsers();
        }

        public List<Trivia> GetTrivia()
        {
            trivia = sqltrivia.GetTrivia();
            return trivia;
        }

        public int AddUser(User user)
        {
            return sqlData.AddUser(user.username, user.password);
        }

        public int UpdateUser(User user)
        {
            return sqlData.UpdateUser(user.username, user.password);
        }

        public int DeleteUser(User user)
        {
            return sqlData.DeleteUser(user.username);
        }

        public int AddTrivia(Trivia trivia)
        {
            return sqltrivia.AddTrivia(trivia.questions, trivia.answers);
        }

        public int UpdateTrivia(Trivia trivia)
        {
            return sqltrivia.UpdateTrivia(trivia.questions, trivia.answers);
        }

        public int DeleteTrivia(Trivia trivia)
        {
            return sqltrivia.DeleteTrivia(trivia.questions);
        }
    }
}
