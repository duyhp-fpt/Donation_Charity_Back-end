using System;
using System.Collections.Generic;

#nullable disable

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

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}
