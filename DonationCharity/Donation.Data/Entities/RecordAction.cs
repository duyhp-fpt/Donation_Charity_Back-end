using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Donation.Data.Entities
{
    public partial class RecordAction
    {
        public int RecordId { get; set; }
        public string Action { get; set; }
        public DateTime? Time { get; set; }
        public int? UserId { get; set; }
        public bool? Status { get; set; }

        public virtual User User { get; set; }
    }
}
