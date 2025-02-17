﻿using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}
