using Donation.Business.Product;
using Donation.Business.Product.dto;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController (IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetAll()
        {
            var product = await _productService.GetAll();
            return Ok(product);
        }
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null) return BadRequest("Not found product");
            return Ok(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var fanpageId = await _productService.Create(request);
            if (fanpageId == 0)
                return BadRequest();
            var fanpage = await _productService.GetById(fanpageId);

            return CreatedAtAction(nameof(GetById), new { id = fanpageId }, fanpage);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        [MapToApiVersion("1.0")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.ProductId = id;
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }

        [HttpDelete("{Id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> Delete(int Id)
        {
            var affectedResult = await _productService.Delete(Id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok("Delete Success");
        }
    }
}
