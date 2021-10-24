using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Payment.dto
{
    public class PaymentUpdateRequest
    {
        public int PaymentId { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentEvidenceId { get; set; }
    }
}
