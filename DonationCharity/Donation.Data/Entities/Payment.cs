using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Campaigns = new HashSet<Campaign>();
            Products = new HashSet<Product>();
        }

        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? TotalPrice { get; set; }
        public int? PaymentEvidenceId { get; set; }

        public virtual PaymentEvidence PaymentEvidence { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
