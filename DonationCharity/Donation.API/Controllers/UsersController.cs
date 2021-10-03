﻿using Donation.Business.Organizations;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var user = await _userService.GetAll();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null) return BadRequest("Not found organization");
            return Ok(user);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Create([FromForm] UserCreateRequest request)
        {
            var userId = await _userService.Create(request);
            if (userId == 0)
                return BadRequest();
            var user = await _userService.GetById(userId);

            return CreatedAtAction(nameof(GetById), new { id = userId }, user);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromForm] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = id;
            var affectedResult = await _userService.Update(request);
            if (affectedResult == 0) return BadRequest();
            return Ok("update success");
        }
    }
}
