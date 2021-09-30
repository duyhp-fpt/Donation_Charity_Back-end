using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.DonationCase.dto
{
    public class DonationCaseCreateRequest
    {
        public string DonationCaseName { get; set; }
        public string Description { get; set; }
    }
}
