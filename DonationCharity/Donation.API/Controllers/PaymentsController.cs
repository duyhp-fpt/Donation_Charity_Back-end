using Donation.Business.Payment;
using Donation.Business.Payment.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donation.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAll()
        {
            var payment = await _paymentService.GetAll();
            return Ok(payment);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetById(int id)
        {
            var payment = await _paymentService.GetById(id);
            if (payment == null) return BadRequest("Not found payment");
            return Ok(payment);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Create([FromForm] PaymentCreateRequest request)
        {
            var paymentId = await _paymentService.Create(request);
            if (paymentId == 0)
                return BadRequest();
            var payment = await _paymentService.GetById(paymentId);

            return CreatedAtAction(nameof(GetById), new { id = paymentId }, payment);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] PaymentUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.PaymentId = id;
            var affectedResult = await _paymentService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _paymentService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
