using Dapper;
using Npgsql;

namespace UsersAndRoles.Repositories
{
    class UserRepository
    {
        string connectionString = "Host=localhost;Port=10000;Username=postgres;Password=12345;Database=UsersAndRoles";
        public List<User> GetUsers()
        {
            var users = new List<User>();

            using (NpgsqlConnection db = new NpgsqlConnection(connectionString))
            {
                users = db.Query<User>("Select * from users").ToList();
            }
            return users;
        }
    }
}
