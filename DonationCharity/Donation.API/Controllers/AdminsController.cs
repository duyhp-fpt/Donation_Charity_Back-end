using Donation.Business.Admins;
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
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminsController(IAdminService adminService)
        {

            _adminService = adminService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAdmin()
        {
            var admin = await _adminService.GetAllAdmin();
            return Ok(admin);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAminById(int id)
        {
            var admin = await _adminService.GetAdminById(id);
            if (admin == null) return BadRequest("cannot find admin");
            return Ok(admin);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> GetAminByUsernameAndPassword(string userName, string password)
        {
            var admin = await _adminService.loginAdmin(userName, password);
            if (admin == null) return BadRequest("cannot find admin");
            return Ok(admin);
        }

    }
}
