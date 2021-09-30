using Donation.Business.Donator.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.Donator
{
    public class DonatorService : IDonatorService
    {
        private readonly DonationContext _context;
        public DonatorService(DonationContext context)
        {
            _context = context;
        }
        public async Task<int> Create(DonatorCreateRequest request)
        {
            var donator = new Donation.Data.Entities.Donator()
            {
                DonatorName = request.DonatorName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = request.Password
            };
            _context.Donators.Add(donator);
            await _context.SaveChangesAsync();
            return donator.DonatorId;
        }

        public async Task<List<DonatorViewModel>> GetAll()
        {
            var query = from c in _context.Donators
                        select new {c};
            return await query.Select(x => new DonatorViewModel()
            {
                DonatorId = x.c.DonatorId,
                DonatorName = x.c.DonatorName,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password
            }).ToListAsync();
        }

        public async Task<DonatorViewModel> GetById(int id)
        {
            var query = from c in _context.Donators
                        where c.DonatorId == id
                        select new { c };
            return await query.Select(x => new DonatorViewModel()
            {
                DonatorId = x.c.DonatorId,
                DonatorName = x.c.DonatorName,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(DonatorUpdateRequest request)
        {
            var donator = await _context.Donators.FindAsync(request.DonatorId);
            if (donator == null) throw new Exception("not found");

            donator.DonatorName = request.DonatorName;
            donator.Address = request.Address;
            donator.PhoneNumber = request.PhoneNumber;
            donator.Email = request.Email;
            donator.Password = request.Password;
            return await _context.SaveChangesAsync();
        }
    }
}
