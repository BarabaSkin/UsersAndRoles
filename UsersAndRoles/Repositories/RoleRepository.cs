using Npgsql;
using Dapper;

namespace UsersAndRoles.Repositories
{
    public class RoleRepository
    {
        public List<Role> GetRoles()
        {
            string connectionString = "Host=localhost;Port=10000;Username=postgres;Password=12345;Database=UsersAndRoles";
            var roles = new List<Role>();

            using (NpgsqlConnection db = new NpgsqlConnection(connectionString))
            {
                roles = db.Query<Role>("Select * from roles").ToList();
            }
            return roles;
        }
    }
}
