using System;
using WebApp_BA_TASK.Models.Models;
using WebApp_BA_TASK.Models.Repositories;

namespace WebApp_BA_TASK.SandBox
{
    public class ReposTests
    {
        UsersRepository repo;

        public ReposTests(string connString)
        {
            repo = new UsersRepository(connString);
        }
        public void Do()
        {
            TestAdd();
            TestGet();
        }
        private void TestGet()
        {
            foreach (var user in repo.GetUsers())
            {
                Console.WriteLine($"{user.Email} {user.BirthDate} {user.Password} {user.AdditionalInfo}");
            }
        }
        private void TestAdd()
        {
            var userToadd = new User
            {
                Password = "Testpsw",
                Email = "testEmail",
                BirthDate = DateTime.Now,
                Name = "testName"
            };
            repo.Add(userToadd);
            
        }
        

        
    }
}
