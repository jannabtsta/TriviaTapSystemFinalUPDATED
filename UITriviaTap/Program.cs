using DLTriviaTap;
using MODELSTriviaTap;
using BLTriviaTapFinal;
using System.Security.Principal;
using System.Data.SqlTypes;

namespace UITriviaTap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TriviaTap User Management!");

            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Register User");
                Console.WriteLine("2. Login User");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        Delete();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void Trivia()
        {
            TriviaServices triviaServices = new TriviaServices();
            List<Trivia> triviaList = triviaServices.GetAllTrivia();
            int score = 0;

            foreach (var trivia in triviaList)
            {
                Console.WriteLine("Question: " + trivia.questions);
                Console.Write("Your Answer: ");
                string userAnswer = Console.ReadLine();

                if (userAnswer.Equals(trivia.answers, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect! The correct answer is: " + trivia.answers);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Quiz finished! Your score is: " + score + "/" + triviaList.Count);
        }

        public static void Login()
        {
            Console.Write("LOGIN");
            Console.Write("");
            Console.Write("Input your Username: ");
            string username = Console.ReadLine();
            Console.Write("Input your Password: ");
            string password = Console.ReadLine();

            VerificationServices user = new VerificationServices();
            var result = user.CheckIfUserExists(username, password);


            if (result)
            {
                Trivia();
            }
            else
            {
                Console.WriteLine("User not found, would you like to register?(y/n)");
                string input = Console.ReadLine();
                if (input == "y")
                {
                    Register();
                }
                else if (input == "n")
                {
                    Login();
                }

            }
        }

        public static void Register()
        {
            Console.Write("REGISTER");
            Console.Write("");
            Console.Write("Create your Username: ");
            string username = Console.ReadLine();
            Console.Write("Create your Password: ");
            string password = Console.ReadLine();

            UserTransactionServices usercreate = new UserTransactionServices();
            bool userCreated = usercreate.CreateUser(username, password);

            VerificationServices userexists = new VerificationServices();
            var result = userexists.CheckIfUserExists(username, password);

            if (userCreated)
            {
                Console.WriteLine("Registered Successfully!");
                Console.WriteLine("--------------------------------");
                Trivia();
            }
            else if (result)
            {
                Console.WriteLine("Account already exists, would you like to proceed to login or register again?(type register/login)");
                string input = Console.ReadLine().ToLower();
                if (input == "login")
                {
                    Login();
                }
                else if (input == "register")
                {
                    Register();
                }

            }
        }

        public static void Delete()
        {
            Console.Write("DELETE AN ACCOUNT");
            Console.Write("");
            Console.Write("Please input the username of the account you desired to delete: ");
            string username = Console.ReadLine();


            UserTransactionServices deleteuser = new UserTransactionServices();
            bool result = deleteuser.DeleteUser(username);

            if (result)
            {
                Console.WriteLine("User deleted successfully!");

            }
            else
            {
                Console.WriteLine("Deletion failed. Username may not exist.");
            }
        }
    }
}

