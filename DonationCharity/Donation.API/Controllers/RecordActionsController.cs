using Donation.Business.RecordAction;
using Donation.Business.RecordAction.dto;
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
    public class RecordActionsController : ControllerBase
    {
        private IRecordActionService _recordActionService;
        public RecordActionsController(IRecordActionService recordActionService)
        {
            _recordActionService = recordActionService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAll()
        {
            var recordAction = await _recordActionService.GetAll();
            return Ok(recordAction);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetById(int id)
        {
            var recordAction = await _recordActionService.GetById(id);
            if (recordAction == null) return BadRequest("Not found record action");
            return Ok(recordAction);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Create([FromForm] RecordActionCreateRequest request)
        {
            var recordId = await _recordActionService.Create(request);
            if (recordId == 0)
                return BadRequest();
            var recordAction = await _recordActionService.GetById(recordId);

            return CreatedAtAction(nameof(GetById), new { id = recordId }, recordAction);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] RecordActionUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.RecordId = id;
            var affectedResult = await _recordActionService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _recordActionService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
