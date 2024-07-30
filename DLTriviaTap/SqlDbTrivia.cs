using MODELSTriviaTap;
using System.Data.SqlClient;

namespace DLTriviaTap
{
    public class SqlDbTrivia
    {

        string connectionString
       // = "Data Source =DESKTOP-HVA24H8\\SQLEXPRESS; Initial Catalog = TriviaTapSYSTEM; Integrated Security = True;";
      = "Server=tcp:20.2.146.243,1433;Database=TriviaTapSYSTEM;User Id=sa;Password=@capusi03;";

        SqlConnection sqlConnection;

        public SqlDbTrivia()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Trivia> GetTrivia()
        {
            string selectStatement = "SELECT questions, answers FROM trivia";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Trivia> trivia = new List<Trivia>();  //'trivia' is the db table name

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string questions = reader["questions"].ToString();
                string answers = reader["answers"].ToString();

                Trivia readUser = new Trivia();
                readUser.questions = questions;
                readUser.answers = answers;


                trivia.Add(readUser);
            }

            sqlConnection.Close();

            return trivia;
        }

        public int AddTrivia(string question, string answer)
        {
            int success;
            string insertStatement = "INSERT INTO trivia VALUES (@question, @answer)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@question", question);
            insertCommand.Parameters.AddWithValue("@answer", answer);

            sqlConnection.Open();
            success = insertCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return success;
        }

        public int UpdateTrivia(string questions, string answers)
        {
          
                int success;

                string updateStatement = "UPDATE trivia SET questions = @questions, answers = @answers WHERE questions = @questions";

                SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
                updateCommand.Parameters.AddWithValue("@questions", questions);
                updateCommand.Parameters.AddWithValue("@answers", answers);

                sqlConnection.Open();
                success = updateCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return success;
            }



        public int DeleteTrivia(string questions)
        {
            int success;

            string deleteStatement = $"DELETE FROM trivia WHERE questions = @questions";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@questions", questions);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
    }
