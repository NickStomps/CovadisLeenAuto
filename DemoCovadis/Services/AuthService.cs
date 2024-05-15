﻿using CovadisAPI.Context;
using CovadisAPI.Entities;
using DemoCovadis.Shared;
using GraafschapLeenAuto.Shared;

namespace GraafschapLeenAuto.Api.Services;

public class AuthService(LeenAutoDbContext dbContext, TokenService tokenService)
{
    public AuthResponse? Login(LoginRequest request)
    {
        var user = dbContext.Users.FirstOrDefault(u => u.Email == request.Email);

        if (user == null || user.Wachtwoord != request.Wachtwoord)
        {
            return null;
        }

        return new AuthResponse
        {
            Id = user.Id,
            Naam = user.Naam,
            Email = user.Email,
            Token = tokenService.CreateToken(user),
        };
    }
}