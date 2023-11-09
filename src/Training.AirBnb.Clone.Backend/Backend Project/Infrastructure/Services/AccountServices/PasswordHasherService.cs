﻿using Backend_Project.Application.Identity.Service;

namespace Backend_Project.Infrastructure.Services.AccountServices;

public  class PasswordHasherService : IPasswordHasher
{
    public string Hash(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}