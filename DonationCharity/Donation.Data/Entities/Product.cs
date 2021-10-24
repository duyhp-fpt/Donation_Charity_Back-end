using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            PaymentEvidences = new HashSet<PaymentEvidence>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public double? Amount { get; set; }
        public int? PaymentId { get; set; }
        public bool? Status { get; set; }

        public virtual Payment Payment { get; set; }
        public virtual ICollection<PaymentEvidence> PaymentEvidences { get; set; }
    }
}
