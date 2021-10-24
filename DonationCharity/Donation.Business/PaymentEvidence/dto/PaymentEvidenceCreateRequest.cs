using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.PaymentEvidence.dto
{
    public class PaymentEvidenceCreateRequest
    {
        public IFormFile PaymentEvidenceImage { get; set; }
        public int? ProductId { get; set; }
    }
}
