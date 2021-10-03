using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.PaymentEvidence.dto
{
    public class PaymentEvidenceCreateRequest
    {
        public string PaymentEvidenceImage { get; set; }
        public DateTime PaymentEvidenceDate { get; set; }
        public int? ProductId { get; set; }
    }
}
