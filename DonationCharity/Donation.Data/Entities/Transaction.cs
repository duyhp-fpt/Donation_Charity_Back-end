using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Donation.Data.Entities
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int? DonatorId { get; set; }
        public int? CampaignId { get; set; }
        public double? Amount { get; set; }
        public string Description { get; set; }
        public DateTime? DonateDate { get; set; }
        public string DonatorCardNumber { get; set; }
        public bool? Status { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual User Donator { get; set; }
    }
}
