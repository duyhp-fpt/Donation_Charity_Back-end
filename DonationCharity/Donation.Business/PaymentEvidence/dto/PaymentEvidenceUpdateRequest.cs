using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.PaymentEvidence.dto
{
    public class PaymentEvidenceUpdateRequest
    {
        public int PaymentEvidenceId { get; set; }
        public string PaymentEvidenceImage { get; set; }
        public DateTime PaymentEvidenceDate { get; set; }
    }
}
