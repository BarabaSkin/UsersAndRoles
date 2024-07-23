using Npgsql;
using Dapper;

namespace UsersAndRoles.Repositories
{
    public class UserRoleRepository
    {
        public List<UserAndRole> GetUserRole()
        {
            // TODO:
            // 1) если у меня нет локально бд, то как мне проверить ваше приложение? ответ - никак
            // 2) строки подключения лучше держать в конфигах 
            // 3) по код стайлу, лучше придерживаться одного стиля во всем проекте,
            // т.е вы либо объявляете все переменные неявно (через var), либо явно (пример: string connectionString)
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
            // TODO: какова сложность данного алгоритма? 
            // Что если мы будем иметь админку, где будут 150 различных ролей
            // и миллионы пользователей?
            for (int i = 0; i < roles.Count; i++)
            {
                var role = roles[i].role;
                var count = 0;
                // TODO: userS - довольно странный код стайл
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
