using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.RecordAction.dto
{
    public class RecordActionCreateRequest
    {
        public int OrganizationId { get; set; }
        public string Action { get; set; }
        public DateTime Time { get; set; }
        public int AdminId { get; set; }
    }
}
