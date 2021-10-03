using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Donation.Data.Entities
{
    public partial class PaymentEvidence
    {
        public int PaymentEvidenceId { get; set; }
        public string PaymentEvidenceImage { get; set; }
        public DateTime? PaymentEvidenceDate { get; set; }
        public int? ProductId { get; set; }
        public bool? Status { get; set; }

        public virtual Product Product { get; set; }
    }
}
