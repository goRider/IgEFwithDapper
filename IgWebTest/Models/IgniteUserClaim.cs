using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserClaim
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual IgniteUser User { get; set; }
    }
}
