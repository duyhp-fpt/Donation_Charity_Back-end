using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Products = new HashSet<Product>();
        }

        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? TotalPrice { get; set; }
        public bool? Status { get; set; }
        public int? CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
