using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserTitle
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public virtual IgniteUser IgniteUser { get; set; }
    }
}
