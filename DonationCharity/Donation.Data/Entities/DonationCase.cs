using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Donation.Data.Entities
{
    public partial class DonationCase
    {
        public DonationCase()
        {
            Campaigns = new HashSet<Campaign>();
        }

        public int DonationCaseId { get; set; }
        public string DonationCaseName { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
