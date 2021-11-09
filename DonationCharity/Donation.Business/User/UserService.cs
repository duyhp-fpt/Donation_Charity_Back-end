using Donation.Business.Organizations.dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Donation.Data.Entities;
using Donation.Business.User.dto;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Donation.Business.Organizations
{
    public class UserService : IUserService
    {
        private const string Secret = "das789dc677k70ovhh3eikkcbmz7wjvcbsufjj98";
        private readonly DonationContext _context;
        public UserService(DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(UserCreateRequest request)
        {
            var user = new Donation.Data.Entities.User()
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Status = "true",
                RoleId = request.RoleId,
                Uid = request.Uid
                
                
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<List<UserViewModel>> GetAll()
        {
            var query = from c in _context.Users
                        where c.Status == "true"
                        select new { c };

            return await query.Select(x => new UserViewModel()
            {
                Id = x.c.Id,
                Name = x.c.Name,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password,
                RoleId =x.c.RoleId,
                Uid = x.c.Uid
            }).ToListAsync();
        }

        public async Task<UserViewModel> GetById(int id)
        {
            var query = from c in _context.Users
                        where c.Id == id && c.Status == "true"
                        select new { c };

            return await query.Select(x => new UserViewModel()
            {
                Id = x.c.Id,
                Name = x.c.Name,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password,
                RoleId = x.c.RoleId,
                Uid = x.c.Uid
            }).FirstOrDefaultAsync();
        }

        public async Task<Data.Entities.User> GetUser(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<int> Update(UserUpdateRequest request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null) throw new Exception("not found");

            user.Name = request.Name;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.Password = request.Password;
            user.RoleId = (int)request.RoleId;
            user.Status = "true";
            user.Uid = request.Uid;
            return await _context.SaveChangesAsync();
        }

        public async Task<string> Login(LoginRequest request)
        {
            if (request != null && request.email != null & request.password != null)
            {
                var user = await GetUser(request.email, request.password);
                if (user != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var role = "";
                    if(user.RoleId == 1)
                    {
                        role = "ADMIN";
                    }else if (user.RoleId == 2){
                        role = "DONATOR";
                    }
                    else
                    {
                        role = "ORGANIZATION";
                    }
                    var claims = new[]
                    {
                            new Claim("id", user.Id.ToString()),
                            new Claim("Name", user.Name),
                            new Claim("Phone", user.PhoneNumber.ToString()),
                            new Claim("Address", user.Address.ToString()),
                            new Claim("Email", user.Email),
                            new Claim("Password", user.Password),
                            new Claim("role", role)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(Secret,
                 Secret,
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);
                    var jwtToken = tokenHandler.WriteToken(token);
                    return jwtToken;
                }
                return null;
            }
            return null;
        }

        public async Task<int> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) throw new Exception("not found user");
            user.Status = "false";
            return await _context.SaveChangesAsync();
        }
    }
}
