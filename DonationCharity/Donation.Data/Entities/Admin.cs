using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Admin
    {
        public Admin()
        {
            RecordActions = new HashSet<RecordAction>();
        }

        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<RecordAction> RecordActions { get; set; }
    }
}
