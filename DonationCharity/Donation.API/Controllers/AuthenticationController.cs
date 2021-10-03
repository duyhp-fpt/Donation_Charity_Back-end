using Donation.Business.Authentication;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LoginWithIdTokenAsync(string idToken)
        {
            if (idToken == null) return BadRequest();
            try
            {
                //FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance
                //    .VerifyIdTokenAsync(idToken);
                //string uid = decodedToken.Uid;
                string uid = idToken;
                string jwtToken = _authenticationService.Authenticate(uid);
                if (jwtToken.Length != 0)
                    return Ok(jwtToken);
                else
                    return Ok(uid);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
