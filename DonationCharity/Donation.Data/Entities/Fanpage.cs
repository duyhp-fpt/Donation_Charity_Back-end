using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Fanpage
    {
        public int FanpageId { get; set; }
        public string Link { get; set; }
        public int? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
