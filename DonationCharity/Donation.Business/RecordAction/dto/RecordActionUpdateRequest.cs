using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.RecordAction.dto
{
    public class RecordActionUpdateRequest
    {
        public int RecordId { get; set; }
        public string Action { get; set; }
        public DateTime? Time { get; set; }
        public int? UserId { get; set; }
    }
}
