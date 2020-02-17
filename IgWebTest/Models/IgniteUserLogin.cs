using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual IgniteUser User { get; set; }
    }
}
