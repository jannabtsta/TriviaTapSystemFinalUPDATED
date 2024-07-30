
using BLTriviaTapFinal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using MODELSTriviaTap;

namespace TriviaTapAPI.Controllers
{
    [ApiController]
    [Route("api/User/Trivia")]
    public class UserController : Controller
    {
        UserGetServices usergetServ;
        UserTransactionServices usertransacServ;
        TriviaServices triviaServices;
        TriviaTransactionServices triviatransacServ;


        public UserController()
        {
            usergetServ = new UserGetServices();
            usertransacServ = new UserTransactionServices();
            triviaServices = new TriviaServices();
            triviatransacServ = new TriviaTransactionServices();
        }

        [HttpGet("Show all Users")]
        public IEnumerable<TriviaTapAPI.User> GetUsers()
        {
            var usersacc = usergetServ.GetAllUsers();

            List<TriviaTapAPI.User> users = new List<User>();

            foreach (var item in usersacc)
            {
                users.Add(new TriviaTapAPI.User { username = item.username, password = item.password });
            }

            return users;
        }

        [HttpGet("Show all Trivia")]
        public IEnumerable<TriviaTapAPI.Trivia> GetTrivia()
        {
            var triviaacc = triviaServices.GetAllTrivia();

            List<TriviaTapAPI.Trivia> trivia = new List<Trivia>();

            foreach (var trivs in triviaacc)
            {
                trivia.Add(new TriviaTapAPI.Trivia { questions = trivs.questions, answers = trivs.answers });
            }

            return trivia;
        }

        [HttpPost("Add a User")]
        public JsonResult AddUser(User request)
        {
            var result = usertransacServ.CreateUser(request.username, request.password);

            return new JsonResult(result);
        }

        [HttpPost("Add a Trivia")]
        public JsonResult AddTrivia(Trivia request)
        {
            var result = triviatransacServ.CreateTrivia(request.questions, request.answers);

            return new JsonResult(result);
        }



        [HttpPut("Update Password of a Username")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            bool isUpdated = usertransacServ.UpdateUser(user.username, user.password);

            if (isUpdated)
            {
                return Ok("User updated successfully.");
            }
            else
            {
                return StatusCode(500, "A problem happened while updating the user.");
            }
        }



        [HttpPut("Update the answer of a Trivia question")]
        public IActionResult UpdateTrivia([FromBody] Trivia trivia)
        {
            if (trivia == null)
            {
                return BadRequest("Invalid trivia data.");
            }

            bool isUpdated = triviatransacServ.UpdateTrivia(trivia.questions, trivia.answers);

            if (isUpdated)
            {
                return Ok("Trivia updated successfully.");
            }
            else
            {
                return StatusCode(500, "A problem happened while updating the trivia.");
            }
        }

        [HttpDelete("Delete a User")]
        public JsonResult DeleteUser(string username)
        {
            var result = usertransacServ.DeleteUser(username);

            return new JsonResult(result);
        }

        [HttpDelete("Delete a Trivia")]
        public JsonResult DeleteTrivia(string questions)
        {
            var result = triviatransacServ.DeleteTrivia(questions);

            return new JsonResult(result);
        }
    }
}
