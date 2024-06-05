using CovadisAPI.Context;
using CovadisAPI.Entities;
using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Enums;
using DemoCovadis.Shared.Interfaces;
using DemoCovadis.Shared.Requests;
using DemoCovadis.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace CovadisAPI.Services
{
    public class UserService(LeenAutoDbContext dbContext, ICurrentUserContext userContext)
    {
        private readonly LeenAutoDbContext dbContext = dbContext;

        public IEnumerable<UserDto> GetUsers()
        {
            return dbContext.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Naam = x.Naam,
                Email = x.Email
            });
        }

        public UserDto? GetUserById(int id)
        {
            if (userContext.IsInRole(nameof(UserRole.User)))
            {
                id = userContext.User.Id;
            }

            var user = dbContext.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Naam = user.Naam,
                Email = user.Email
            };
        }

        public UserDto CreateUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                Naam = user.Naam,
                Email = user.Email
            };
        }

        public UserDto? UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }

        public AssignRoleResponse? AssignRole(AssignRoleRequest request)
        {
            var user = dbContext.Users
                .Include(x => x.Roles)
                .FirstOrDefault(x => x.Id == request.UserId);
            var role = dbContext.Roles.Find(request.RoleId);

            if (user == null || role == null)
            {
                return null;
            }

            if (user.Roles.Contains(role))
            {
                throw new ArgumentException("User already assigned to role");
            }

            user.Roles.Add(role);
            dbContext.SaveChanges();

            return new AssignRoleResponse
            {
                UserName = user.Naam,
                RoleName = role.Naam,
            };
        }
    }
}