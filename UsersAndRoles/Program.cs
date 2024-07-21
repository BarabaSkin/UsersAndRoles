using System.Data;
using UsersAndRoles;
using UsersAndRoles.Repositories;

var userRoleFromDb = new UserRoleRepository();
userRoleFromDb.UsersAndHisRoles();
userRoleFromDb.CountUsersWithRoles();

