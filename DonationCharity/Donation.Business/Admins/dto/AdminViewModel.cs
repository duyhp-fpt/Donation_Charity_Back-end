using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Admins.dto
{
    public class AdminViewModel
    {
        public int AdminId { get; set; }
        public String UserName { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
    }
}
