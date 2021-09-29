using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class RecordAction
    {
        public int RecordId { get; set; }
        public int? OrganizationId { get; set; }
        public string Action { get; set; }
        public DateTime? Time { get; set; }
        public int? AdminId { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
