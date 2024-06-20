using DemoCovadis.Context;
using DemoCovadis.Entities;
using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Enums;
using DemoCovadis.Shared.Interfaces;
using DemoCovadis.Shared.Requests;
using DemoCovadis.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoCovadis.Services
{
    public class UserService
    {
        private readonly LeenAutoDbContext dbContext;
        private readonly ICurrentUserContext userContext;

        public UserService(LeenAutoDbContext dbContext, ICurrentUserContext userContext)
        {
            this.dbContext = dbContext;
            this.userContext = userContext;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return dbContext.Users.Include(x => x.Roles).Select(x => new UserDto
            {
                Id = x.Id,
                Naam = x.Naam,
                Email = x.Email,
                Roles = x.Roles.Select(r => r.Naam).ToList()
            });
        }

        public UserDto? GetUserById(int id)
        {
            if (userContext.IsInRole(nameof(UserRole.User)))
            {
                id = userContext.User.Id;
            }

            var user = dbContext.Users.Include(x => x.Roles).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Naam = user.Naam,
                Email = user.Email,
                Roles = user.Roles.Select(r => r.Naam).ToList()
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
                Email = user.Email,
                Roles = user.Roles.Select(r => r.Naam).ToList()
            };
        }

        public User? UpdateUser(int id, User user)
        {
            var existingUser = dbContext.Users.Find(id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.Naam = user.Naam;
            existingUser.Email = user.Email;
            dbContext.SaveChanges();
            return existingUser;
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
