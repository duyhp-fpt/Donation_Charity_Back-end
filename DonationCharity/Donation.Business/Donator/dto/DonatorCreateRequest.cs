using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Donator.dto
{
    public class DonatorCreateRequest
    {
        public string DonatorName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
    }
}
