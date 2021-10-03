using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

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
        public bool? Status { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
