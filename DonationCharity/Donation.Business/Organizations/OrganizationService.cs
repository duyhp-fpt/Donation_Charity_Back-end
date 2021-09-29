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
    public class OrganizationService : IOrganizationService
    {
        private readonly DonationDbContext _context;
        public OrganizationService(DonationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(OrganizationCreateRequest request)
        {
            var organization = new Organization()
            {
                OrganizationName = request.OrganizationName,
                Description = request.Description,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = request.Password
            };
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
            return organization.OrganizationId;
        }

        public async Task<List<OrganizationViewModel>> GetAll()
        {
            var query = from c in _context.Organizations
                        select new { c };

            return await query.Select(x => new OrganizationViewModel()
            {
                OrganizationId = x.c.OrganizationId,
                OrganizationName = x.c.OrganizationName,
                Description = x.c.Description,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password
            }).ToListAsync();
        }

        public async Task<OrganizationViewModel> GetById(int id)
        {
            var query = from c in _context.Organizations
                        where c.OrganizationId == id
                        select new { c };

            return await query.Select(x => new OrganizationViewModel()
            {
                OrganizationId = x.c.OrganizationId,
                OrganizationName = x.c.OrganizationName,
                Description = x.c.Description,
                Address = x.c.Address,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email,
                Password = x.c.Password
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(OrganizationUpdateRequest request)
        {
            var organiztion = await _context.Organizations.FindAsync(request.OrganizationId);
            if (organiztion == null) throw new Exception("not found");

            organiztion.OrganizationName = request.OrganizationName;
            organiztion.Description = request.Description;
            organiztion.Address = request.Address;
            organiztion.PhoneNumber = request.PhoneNumber;
            organiztion.Email = request.Email;
            organiztion.Password = request.Password;
            return await _context.SaveChangesAsync();
        }
    }
}
