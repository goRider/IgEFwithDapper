using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserToken
    {
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual IgniteUser User { get; set; }
    }
}
