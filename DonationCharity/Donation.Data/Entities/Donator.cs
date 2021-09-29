using System;
using System.Collections.Generic;

#nullable disable

namespace Donation.Data.Entities
{
    public partial class Donator
    {
        public Donator()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int DonatorId { get; set; }
        public string DonatorName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
