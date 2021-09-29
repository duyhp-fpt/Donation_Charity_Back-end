using System;
using System.Collections.Generic;

#nullable disable

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

        public virtual Campaign Campaign { get; set; }
        public virtual Donator Donator { get; set; }
    }
}
