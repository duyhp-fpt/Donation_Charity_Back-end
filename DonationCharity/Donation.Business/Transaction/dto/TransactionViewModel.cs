using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Transaction.dto
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public int DonatorId { get; set; }
        public int CampaignId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime DonateDate { get; set; }
        public string DonatorCardNumber { get; set; }
    }
}
