using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class PaymentEvidence
    {
        public PaymentEvidence()
        {
            Payments = new HashSet<Payment>();
        }

        public int PaymentEvidenceId { get; set; }
        public string PaymentEvidenceImage { get; set; }
        public DateTime? PaymentEvidenceDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
