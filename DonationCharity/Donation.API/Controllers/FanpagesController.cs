using Donation.Business.Fanpage;
using Donation.Business.Fanpage.dto;
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
    public class FanpagesController : ControllerBase
    {
        private readonly IFanpageService _fanpageService;
        public FanpagesController(IFanpageService fanpageService)
        {
            _fanpageService = fanpageService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var fanpage = await _fanpageService.GetAll();
            return Ok(fanpage);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var fanpage = await _fanpageService.GetById(id);
            if (fanpage == null) return BadRequest("Not found fanpage");
            return Ok(fanpage);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] FanpageCreateRequest request)
        {
            var fanpageId = await _fanpageService.Create(request);
            if (fanpageId == 0)
                return BadRequest();
            var fanpage = await _fanpageService.GetById(fanpageId);

            return CreatedAtAction(nameof(GetById), new { id = fanpageId }, fanpage);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] FanpageUpdateReqeust request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.FanpageId = id;
            var affectedResult = await _fanpageService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _fanpageService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
