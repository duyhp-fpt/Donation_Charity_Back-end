using Donation.Business.DonationCase;
using Donation.Business.DonationCase.dto;
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
    public class DonationCasesController : ControllerBase
    {
        private readonly IDonationCaseService _donationCaseService;

        public DonationCasesController(IDonationCaseService donationCaseService)
        {
            _donationCaseService = donationCaseService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAll()
        {
            var donationCase = await _donationCaseService.GetAll();
            return Ok(donationCase);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetById(int id)
        {
            var donationCase = await _donationCaseService.GetById(id);
            if (donationCase == null) return BadRequest("Not found donation case");
            return Ok(donationCase);
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] DonationCaseCreateRequest request)
        {
            var donationCaseId = await _donationCaseService.Create(request);
            if (donationCaseId == 0)
                return BadRequest();
            var donationCase = await _donationCaseService.GetById(donationCaseId);

            return CreatedAtAction(nameof(GetById), new { id = donationCaseId }, donationCase);
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] DonationCaseUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.DonationCaseId = id;
            var affectedResult = await _donationCaseService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _donationCaseService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
