using Npgsql;
using Dapper;

namespace UsersAndRoles.Repositories
{
    public class UserRepository
    {
        public List<User> GetUsers()
        {
            string connectionString = "Host=localhost;Port=10000;Username=postgres;Password=12345;Database=UsersAndRoles";
            var users = new List<User>();

            using (NpgsqlConnection db = new NpgsqlConnection(connectionString))
            {
                users = db.Query<User>("Select * from users").ToList();
            }
            return users;
        }
    }
}
