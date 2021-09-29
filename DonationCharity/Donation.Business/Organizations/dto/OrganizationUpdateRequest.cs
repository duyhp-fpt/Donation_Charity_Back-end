using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Organizations.dto
{
    public class OrganizationUpdateRequest
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
