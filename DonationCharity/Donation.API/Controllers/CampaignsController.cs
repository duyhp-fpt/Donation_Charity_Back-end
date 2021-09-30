using Donation.Business.Campaign;
using Donation.Business.Campaign.dto;
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
    public class CampaginsController : ControllerBase
    {
        private readonly ICampaignService _campaignService;
        public CampaginsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var campaign = await _campaignService.GetAll();
            return Ok(campaign);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var campaign = await _campaignService.GetById(id);
            if (campaign == null) return BadRequest("Not found organization");
            return Ok(campaign);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] CampaignCreateRequest request)
        {
            var campaignId = await _campaignService.Create(request);
            if (campaignId == 0)
                return BadRequest();
            var organization = await _campaignService.GetById(campaignId);

            return CreatedAtAction(nameof(GetById), new { id = campaignId }, organization);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] CampaignUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.CampaignId = id;
            var affectedResult = await _campaignService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpGet("paging")]
        public async Task<ActionResult> GetAllPaging([FromQuery] GetCampaignPagingRequest request)
        {
            var campaign = await _campaignService.GetAllPaging(request);
            return Ok(campaign);
        }
    }
}
