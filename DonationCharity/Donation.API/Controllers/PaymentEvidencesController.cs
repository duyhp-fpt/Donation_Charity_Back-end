using Donation.Business.PaymentEvidence;
using Donation.Business.PaymentEvidence.dto;
using Donation.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentEvidencesController : ControllerBase
    {
        private readonly IPaymentEvidenceService _paymentEvidenceService;
        public PaymentEvidencesController(IPaymentEvidenceService paymentEvidenceService)
        {
            _paymentEvidenceService = paymentEvidenceService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var paymentEvidence = await _paymentEvidenceService.GetAll();
            return Ok(paymentEvidence);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var paymentEvidence = await _paymentEvidenceService.GetById(id);
            if (paymentEvidence == null) return BadRequest("Not found payment evidence");
            return Ok(paymentEvidence);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] PaymentEvidenceCreateRequest request)
        {
            var paymentEvidenceId = await _paymentEvidenceService.Create(request);
            if (paymentEvidenceId == 0)
                return BadRequest();
            var paymentEvidence = await _paymentEvidenceService.GetById(paymentEvidenceId);

            return CreatedAtAction(nameof(GetById), new { id = paymentEvidenceId }, paymentEvidence);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] PaymentEvidenceUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.PaymentEvidenceId = id;
            var affectedResult = await _paymentEvidenceService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _paymentEvidenceService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
