using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.DonationCase.dto
{
    public class DonationCaseUpdateRequest
    {
        public int DonationCaseId { get; set; }
        public string DonationCaseName { get; set; }
        public string Description { get; set; }
    }
}
