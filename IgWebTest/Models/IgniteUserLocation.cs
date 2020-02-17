using System;
using System.Collections.Generic;

namespace IgWebTest.Models
{
    public partial class IgniteUserLocation
    {
        public int LocationId { get; set; }
        public string CityLocationName { get; set; }
        public string StateLocationName { get; set; }
        public string CountryLocationName { get; set; }

        public virtual IgniteUser IgniteUser { get; set; }
    }
}
