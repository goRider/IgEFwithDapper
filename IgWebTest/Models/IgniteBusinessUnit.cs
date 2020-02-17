using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteBusinessUnit
    {
        public int Buid { get; set; }
        public string BusinessUnitName { get; set; }

        public virtual IgniteUser IgniteUser { get; set; }
    }
}
