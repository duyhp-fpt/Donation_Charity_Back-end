using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Campaigns = new HashSet<Campaign>();
            Fanpages = new HashSet<Fanpage>();
            RecordActions = new HashSet<RecordAction>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public int? RoleId { get; set; }
        public string Uid { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Campaign> Campaigns { get; set; }
        public virtual ICollection<Fanpage> Fanpages { get; set; }
        public virtual ICollection<RecordAction> RecordActions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
