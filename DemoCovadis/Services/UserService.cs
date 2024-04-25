﻿using CovadisAPI.Context;
using CovadisAPI.Entities;
using DemoCovadis.Shared;

namespace CovadisAPI.Services
{
    public class UserService
    {
        private readonly LeenAutoDbContext dbContext;
        public UserService(LeenAutoDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            return dbContext.Users.Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });

        }
        public UserDto CreateUser(User user) 
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return new UserDto
            { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

        }
    }
}
