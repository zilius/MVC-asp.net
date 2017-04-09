using System.Configuration;
using System.Web.Mvc;
using WebApp_BA_TASK.Helpers;
using WebApp_BA_TASK.Models.Models;
using WebApp_BA_TASK.Models.Repositories;

namespace WebApp_BA_TASK.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        [HttpGet]
        public ActionResult GetUsers()
        {
            var usersRep = new UsersRepository(_connectionString);
            var users = usersRep.GetUsers();
            ViewData["users"] = users;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var userRepo = new UsersRepository(_connectionString);

                if (userRepo.EmailInUse(user.Email))
                {
                    ModelState.Clear();
                    ViewBag.Message = "Email is in use";
                    return View(user);
                }
                else
                {
                    var password = PasswordHelper.HashSha(user.Password);
                    user.Password = password;
                    userRepo.Add(user);
                    ModelState.Clear();
                    ViewBag.Message = "Registration succeeded";
                    return View();
                } 
            }
            return View(user);
            
        }
                
    }
}