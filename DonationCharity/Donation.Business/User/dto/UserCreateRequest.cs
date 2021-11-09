using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Organizations.dto
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public string Uid { get; set; }
    }
}
