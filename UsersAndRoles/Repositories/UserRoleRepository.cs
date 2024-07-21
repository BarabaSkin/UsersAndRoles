using Npgsql;
using Dapper;

namespace UsersAndRoles.Repositories
{
    public class UserRoleRepository
    {
        public List<UserAndRole> GetUserRole()
        {
            string connectionString = "Host=localhost;Port=10000;Username=postgres;Password=12345;Database=UsersAndRoles";
            var userrole = new List<UserAndRole>();

            using (NpgsqlConnection db = new NpgsqlConnection(connectionString))
            {
                userrole = db.Query<UserAndRole>("Select * from usersandroles").ToList();
            }
            return userrole;
        }
    }
}
