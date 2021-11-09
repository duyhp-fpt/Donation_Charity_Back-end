using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Campaign.dto
{
    public class CampaignUpdateRequest
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int DonationCaseId { get; set; }
        public string CardNumber { get; set; }
        public double Goal { get;set;}
        public IFormFile ThumbnailImage { get; set; }
    }
}
