using UsersAndRoles;
using UsersAndRoles.Repositories;

List<UserAndRole> usersAndRoles = new List<UserAndRole>();
var userRoleFromDb = new UserRoleRepository();

usersAndRoles = userRoleFromDb.GetUserRole();


for (int i = 0; i < usersAndRoles.Count; i++)
{
    var user = usersAndRoles[i].User;
    Console.WriteLine(user + " has roles: ");
    foreach (var users in usersAndRoles)
    {
        if(users.User == user)
        {
            Console.Write(users.Role + " ");
        }
    }
    Console.WriteLine("\n");
}


for (int i = 0; i < usersAndRoles.Count; i++)
{
    var role = usersAndRoles[i].Role;
    var count = 0;
    foreach (var users in usersAndRoles)
    {
        if (users.Role == role)
        {
            count ++;
        }
    }
    Console.WriteLine(count + " users has role " + role);
}

