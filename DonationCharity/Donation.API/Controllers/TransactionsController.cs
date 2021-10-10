using Donation.Business.Transaction;
using Donation.Business.Transaction.dto;
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
    public class TransactionsController : ControllerBase
    {
        private ITransactionService _recordTransactionService;
        public TransactionsController(ITransactionService transactionService)
        {
            _recordTransactionService = transactionService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAll()
        {
            var transaction = await _recordTransactionService.GetAll();
            return Ok(transaction);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetById(int id)
        {
            var transaction = await _recordTransactionService.GetById(id);
            if (transaction == null) return BadRequest("Not found transaction");
            return Ok(transaction);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Create([FromForm] TransactionCreateRequest request)
        {
            var transactionId = await _recordTransactionService.Create(request);
            if (transactionId == 0)
                return BadRequest();
            var transaction = await _recordTransactionService.GetById(transactionId);

            return CreatedAtAction(nameof(GetById), new { id = transactionId }, transaction);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] TransactionUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.TransactionId = id;
            var affectedResult = await _recordTransactionService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _recordTransactionService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
