using Donation.Business.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Campaign.dto
{
    public class GetCampaignPagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
        public int DonationCaseId { get; set; }
    }
}
