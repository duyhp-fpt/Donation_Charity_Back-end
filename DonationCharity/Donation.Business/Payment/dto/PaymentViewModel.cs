using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Payment.dto
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentEvidenceId { get; set; }
    }
}
