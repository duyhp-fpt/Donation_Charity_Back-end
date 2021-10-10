using Donation.Business.DonationCase.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.DonationCase
{
    public class DonationCaseService : IDonationCaseService
    {
        private DonationContext _context;
        public DonationCaseService (DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DonationCaseCreateRequest request)
        {
            var donationCase = new Donation.Data.Entities.DonationCase()
            {
                DonationCaseName = request.DonationCaseName,
                Description = request.Description,
                Status = true
            };
            _context.DonationCases.Add(donationCase);
            await _context.SaveChangesAsync();
            return donationCase.DonationCaseId;
        }

        public async Task<int> Delete(int id)
        {
            var donationCase = await _context.DonationCases.FindAsync(id);
            if (donationCase == null) throw new Exception("not found this fanpage");
            donationCase.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DonationCaseViewModel>> GetAll()
        {
            var query = from c in _context.DonationCases
                        where c.Status == true
                        select new { c };
            return await query.Select(x => new DonationCaseViewModel()
            {
                DonationCaseId = x.c.DonationCaseId,
                DonationCaseName = x.c.DonationCaseName,
                Description = x.c.Description
            }).ToListAsync();
        }

        public async Task<DonationCaseViewModel> GetById(int id)
        {
            var query = from c in _context.DonationCases
                        where c.DonationCaseId == id && c.Status == true
                        select new { c };
            return await query.Select(x => new DonationCaseViewModel()
            {
                DonationCaseId = x.c.DonationCaseId,
                DonationCaseName = x.c.DonationCaseName,
                Description = x.c.Description
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(DonationCaseUpdateRequest request)
        {
            var donationCase = await _context.DonationCases.FindAsync(request.DonationCaseId);
            if (donationCase == null) throw new Exception("not found");

            donationCase.DonationCaseId = request.DonationCaseId;
            donationCase.DonationCaseName = request.DonationCaseName;
            donationCase.Description = request.Description;
            return await _context.SaveChangesAsync();
        }
    }
}
