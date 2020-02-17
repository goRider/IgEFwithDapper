using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteApplicationStatus
    {
        public IgniteApplicationStatus()
        {
            IgniteUserApplication = new HashSet<IgniteUserApplication>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<IgniteUserApplication> IgniteUserApplication { get; set; }
    }
}
