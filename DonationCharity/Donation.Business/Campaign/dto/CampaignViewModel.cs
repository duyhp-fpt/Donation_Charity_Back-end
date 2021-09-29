using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Campaign.dto
{
    public class CampaignViewModel
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int OrganizationId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }
        public string Image { get; set; }
        public int DonationCaseId { get; set; }
        public string CardNumber { get; set; }
        public int PaymentId { get; set; }
    }
}
