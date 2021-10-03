using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Donation.Data.Entities
{
    public partial class Fanpage
    {
        public int FanpageId { get; set; }
        public string Link { get; set; }
        public int? OrganizationId { get; set; }
        public bool? Status { get; set; }

        public virtual User Organization { get; set; }
    }
}
