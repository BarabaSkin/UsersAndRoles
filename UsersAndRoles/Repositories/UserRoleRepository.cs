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

        public void UsersAndHisRoles()
        {
            List<UserAndRole> usersAndRoles = new List<UserAndRole>();
            var userRoleFromDb = new UserRoleRepository();
            usersAndRoles = userRoleFromDb.GetUserRole();
            List<User> users = new List<User>();
            var usersFromDb = new UserRepository();
            users = usersFromDb.GetUsers();
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i].user;
                Console.WriteLine(user + " has roles: ");
                foreach (var userS in usersAndRoles)
                {
                    if (userS.User == user)
                    {
                        Console.Write(userS.Role + " ");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public void CountUsersWithRoles()
        {
            List<UserAndRole> usersAndRoles = new List<UserAndRole>();
            var userRoleFromDb = new UserRoleRepository();
            usersAndRoles = userRoleFromDb.GetUserRole();
            List<Role> roles = new List<Role>();
            var rolesFromDb = new RoleRepository();
            roles = rolesFromDb.GetRoles();
            for (int i = 0; i < roles.Count; i++)
            {
                var role = roles[i].role;
                var count = 0;
                foreach (var userS in usersAndRoles)
                {
                    if (userS.Role == role)
                    {
                        count++;
                    }
                }
                Console.WriteLine(count + " users has role " + role);
            }
        }
    }
}
