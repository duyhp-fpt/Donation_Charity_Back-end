using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Fanpage.dto
{
    public class FanpageCreateRequest
    {
        public string Link { get; set; }
        public int OrganizationId { get; set; }
    }
}
