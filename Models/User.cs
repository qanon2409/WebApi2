﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginTime { get; set; }
    }
}
