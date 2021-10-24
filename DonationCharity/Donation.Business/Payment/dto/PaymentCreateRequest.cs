using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Payment.dto
{
    public class PaymentCreateRequest
    {
        public double? TotalPrice { get; set; }
        public int? CampaignId { get; set; }
    }
}
