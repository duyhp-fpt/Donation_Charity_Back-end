using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donation.Data.Entities;
using Donation.Business.Donator;
using Donation.Business.Donator.dto;

namespace Donation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatorsController : ControllerBase
    {
        private readonly IDonatorService _donatorService;

        public DonatorsController(IDonatorService donatorService)
        {
            _donatorService = donatorService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var donator = await _donatorService.GetAll();
            return Ok(donator);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var donator = await _donatorService.GetById(id);
            if (donator == null) return BadRequest("Not found donator");
            return Ok(donator);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] DonatorCreateRequest request)
        {
            var donatorId = await _donatorService.Create(request);
            if (donatorId == 0)
                return BadRequest();
            var donator = await _donatorService.GetById(donatorId);

            return CreatedAtAction(nameof(GetById), new { id = donatorId }, donator);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] DonatorUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.DonatorId = id;
            var affectedResult = await _donatorService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }


    }
}
