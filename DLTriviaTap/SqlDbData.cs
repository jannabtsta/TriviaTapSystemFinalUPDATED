using MODELSTriviaTap;
using System.Data.SqlClient;

namespace DLTriviaTap
{
    public class SqlDbData
    {
        string connectionString
     //  = "Data Source =DESKTOP-HVA24H8\\SQLEXPRESS; Initial Catalog = TriviaTapSYSTEM; Integrated Security = True;";
          = "Server=tcp:20.2.146.243,1433;Database= TriviaTapSYSTEM;User Id=sa;Password=@capusi03";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }



        public List<User> GetUsers()
        {
            string selectStatement = "SELECT username, password FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();  //'users' is the db table name

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();

                User readUser = new User();
                readUser.username = username;
                readUser.password = password;


                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string username, string password)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@username, @password)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string username, string password)
        {
            int success;

            string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Password", password);
            updateCommand.Parameters.AddWithValue("@username", username);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string username)
        {
            int success;

            string deleteStatement = $"DELETE FROM users WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@username", username);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}
