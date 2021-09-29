using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            Campaigns = new HashSet<Campaign>();
            Fanpages = new HashSet<Fanpage>();
            RecordActions = new HashSet<RecordAction>();
        }

        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Fanpage> Fanpages { get; set; }
        public virtual ICollection<RecordAction> RecordActions { get; set; }
    }
}
