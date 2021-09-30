using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Payment.dto
{
    public class PaymentCreateRequest
    {
        public DateTime? PaymentDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentEvidenceId { get; set; }
    }
}
