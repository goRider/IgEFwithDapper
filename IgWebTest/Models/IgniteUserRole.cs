using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserRole
    {
        public int IgniteUserRoleId { get; set; }
        public int RoleId { get; set; }

        public virtual IgniteUser IgniteUserRoleNavigation { get; set; }
        public virtual IgniteRole Role { get; set; }
    }
}
