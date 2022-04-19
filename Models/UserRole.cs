using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi2.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
