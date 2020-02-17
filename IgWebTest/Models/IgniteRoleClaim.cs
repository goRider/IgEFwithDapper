using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteRoleClaim
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual IgniteRole Role { get; set; }
    }
}
