using Donation.Business.Organizations.dto;
using Donation.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Donation.Data.Entities;

namespace Donation.Business.Organizations
{
    public class UserService : IUserService
    {
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
                Status = request.Status,
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
                        where c.Id == id
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

        public async Task<int> Update(UserUpdateRequest request)
        {
            var user = await _context.Users.FindAsync(request.Id);
            if (user == null) throw new Exception("not found");

            user.Name = request.Name;
            user.Address = request.Address;
            user.PhoneNumber = request.PhoneNumber;
            user.Email = request.Email;
            user.Password = request.Password;
            user.RoleId = request.RoleId;
            user.Status = request.Status;
            user.Uid = request.Uid;
            return await _context.SaveChangesAsync();
        }
    }
}
