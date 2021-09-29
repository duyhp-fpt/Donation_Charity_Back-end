using Donation.Business.Organizations;
using Donation.Business.Organizations.dto;
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
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationsController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var organization = await _organizationService.GetAll();
            return Ok(organization);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var organization = await _organizationService.GetById(id);
            if (organization == null) return BadRequest("Not found organization");
            return Ok(organization);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] OrganizationCreateRequest request)
        {
            var organizationId = await _organizationService.Create(request);
            if (organizationId == 0)
                return BadRequest();
            var organization = await _organizationService.GetById(organizationId);

            return CreatedAtAction(nameof(GetById), new { id = organizationId }, organization);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] OrganizationUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.OrganizationId = id;
            var affectedResult = await _organizationService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }
    }
}
