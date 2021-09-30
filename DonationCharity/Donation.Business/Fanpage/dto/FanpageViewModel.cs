using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Fanpage.dto
{
    public class FanpageViewModel
    {
        public int FanpageId { get; set; }
        public string Link { get; set; }
        public int OrganizationId { get; set; }
    }
}
