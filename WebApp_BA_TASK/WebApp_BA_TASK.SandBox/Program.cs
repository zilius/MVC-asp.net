using System;

namespace WebApp_BA_TASK.SandBox
{
    //Just for testins
    class Program
    {
        static void Main(string[] args)
        {
            string constring = @"Data Source = LENOVO\SQLEXPRESS; Initial Catalog = UsersDB; Integrated Security = SSPI;";

            var repTEst = new ReposTests(constring);
            repTEst.Do();

            Console.ReadLine();
            
            
            

        }
    }
}
