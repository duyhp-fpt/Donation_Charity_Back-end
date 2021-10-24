using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Campaign
    {
        public Campaign()
        {
            Payments = new HashSet<Payment>();
            Transactions = new HashSet<Transaction>();
        }

        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int? OrganizationId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Image { get; set; }
        public int? DonationCaseId { get; set; }
        public string CardNumber { get; set; }
        public bool? Status { get; set; }
        public double? Goal { get; set; }

        public virtual DonationCase DonationCase { get; set; }
        public virtual User Organization { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
