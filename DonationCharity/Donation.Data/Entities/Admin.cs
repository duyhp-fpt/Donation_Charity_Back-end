using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Data.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
    }
}
