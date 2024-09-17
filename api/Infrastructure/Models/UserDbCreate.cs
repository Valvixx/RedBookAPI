﻿using Domain.Entities;

namespace Application.DTO;

public class UserDbCreate
{
    public UserType Type { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}