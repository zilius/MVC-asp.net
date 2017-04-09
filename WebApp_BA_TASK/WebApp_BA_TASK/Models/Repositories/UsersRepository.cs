using System.Collections.Generic;
using WebApp_BA_TASK.Models.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace WebApp_BA_TASK.Models.Repositories
{
    public class UsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<User> GetUsers()
        {
            string queryString = @"SELECT
                                          Email,
                                          Name,
                                          Password,
                                          BirthDate,
                                          AdditionalInfo
                                  FROM Users";


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>
                (queryString).ToList();

            }

        }
        public void Add(User user)
        {
            string query = $@"INSERT INTO Users
                                (Password,
                                Name,
                                Email,
                                BirthDate, 
                                AdditionalInfo) 
                           VALUES 
                                (@Password,
                                @Name,  
                                @Email,
                                @BirthDate,
                                @AdditionalInfo)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Execute(query, user);
            }
        }
        public bool EmailInUse(string email)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return !(string.IsNullOrEmpty(db.Query<string>("SELECT 1 FROM Users WHERE Users.Email = @email", new { email }).SingleOrDefault()));
            }

    }
    } 
}