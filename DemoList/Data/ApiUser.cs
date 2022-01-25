﻿using Microsoft.AspNetCore.Identity;

namespace DemoList.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
