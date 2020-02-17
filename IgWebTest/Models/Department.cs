using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual IgniteUser IgniteUser { get; set; }
    }
}
