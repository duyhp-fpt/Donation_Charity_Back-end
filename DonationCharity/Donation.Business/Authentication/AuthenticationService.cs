using Donation.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string Secret = "das789dc677k70ovhh3eikkcbmz7wjvcbsufjj98";
        private const string AdminUI = "aS9Phaqh1Egxx9SXAB7FsNW5dH92";
        private readonly DonationContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationService(DonationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string Authenticate(string uid)
        {
            var user = LoadUserByUid(uid);
            if (user != null)
            {
                var customToken = CreateCustomToken(uid, user.Id);
                return customToken;
            }
            return "";
        }

        private async Task<Donation.Data.Entities.User> LoadUserByUid(string uid)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Uid.Equals(uid));
        }

        private string CreateCustomToken(string uid, int id)
        {
            var uidAdmin = AdminUI;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            Console.WriteLine(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", id.ToString()),
                    new Claim("uid", uid),
                    new Claim(ClaimTypes.Role, uid.Equals(uidAdmin) ? "ADMIN" : "DONATOR")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;

        }
    }
}
