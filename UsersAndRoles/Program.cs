using UsersAndRoles.Repositories;

var userRep = new UserRepository();
var userList = userRep.GetUsers();
for (int i = 0; i < userList.Count; i++)
{
    Console.WriteLine(userList[i].user);
}



