using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserType
    {
        public int IgniteUserTypeId { get; set; }
        public string IgniteUserTypeName { get; set; }

        public virtual IgniteUser IgniteUser { get; set; }
    }
}
