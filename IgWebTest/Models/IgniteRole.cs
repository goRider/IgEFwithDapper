using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteRole
    {
        public IgniteRole()
        {
            IgniteRoleClaim = new HashSet<IgniteRoleClaim>();
            IgniteUserRole = new HashSet<IgniteUserRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<IgniteRoleClaim> IgniteRoleClaim { get; set; }
        public virtual ICollection<IgniteUserRole> IgniteUserRole { get; set; }
    }
}
