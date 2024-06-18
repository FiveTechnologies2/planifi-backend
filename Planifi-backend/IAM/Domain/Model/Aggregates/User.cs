﻿using System.Text.Json.Serialization;

namespace Planifi_backend.IAM.Domain.Model.Aggregates;

public class User(string email, string passwordHash)
{
    public User() : this(string.Empty, string.Empty) {}
    
    public int Id { get; }

    public string Email { get; private set; } = email;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    public User UpdateEmail(string email)
    {
        Email = email;
        return this;
    }
    
    public User updatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}