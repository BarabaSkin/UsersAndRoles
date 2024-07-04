using Dapper;
using Npgsql;

namespace UsersAndRoles.Repositories
{
    class UserRepository : User
    {
        string connectionString = "Host=localhost;Port=10000;Username=postgres;Password=12345;Database=UsersAnsRoles";
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (Npgsql.NpgsqlConnection db = new NpgsqlConnection(connectionString))
            {
                users = db.Query<User>("Select * from users").ToList();
            }
            Console.WriteLine(users.ToString());
            return users;
        }
    }
}
