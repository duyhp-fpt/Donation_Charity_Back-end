using Donation.Business.Fanpage.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.Fanpage
{
    public class FanpageService : IFanpageService
    {
        private readonly DonationContext _context;
        public FanpageService (DonationContext context)
        {
            _context = context;
        }
        public async Task<int> Create(FanpageCreateRequest request)
        {
            var fanpage = new Donation.Data.Entities.Fanpage()
            {
                Link = request.Link,
                OrganizationId = request.OrganizationId,
                Status = true
            };
            _context.Fanpages.Add(fanpage);
            await _context.SaveChangesAsync();
            return fanpage.FanpageId;
        }

        public async Task<int> Delete(int id)
        {
            var fanpage = await _context.Fanpages.FindAsync(id);
            if (fanpage == null) throw new Exception("not found this fanpage");
            fanpage.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<FanpageViewModel>> GetAll()
        {
            var query = from c in _context.Fanpages
                        where c.Status == true
                        select new { c };
            return await query.Select(x => new FanpageViewModel()
            {
                FanpageId = x.c.FanpageId,
                Link = x.c.Link,
                OrganizationId = (int)x.c.OrganizationId
            }).ToListAsync();
        }

        public async Task<FanpageViewModel> GetById(int id)
        {
            var query = from c in _context.Fanpages
                        where c.FanpageId == id && c.Status == true
                        select new { c };
            return await query.Select(x => new FanpageViewModel()
            {
                FanpageId = x.c.FanpageId,
                Link = x.c.Link,
                OrganizationId = (int)x.c.OrganizationId
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(FanpageUpdateRequest request)
        {
            var fanpage = await _context.Fanpages.FindAsync(request.FanpageId);
            if (fanpage == null) throw new Exception("not found");

            fanpage.FanpageId = request.FanpageId;
            fanpage.Link = request.Link;
            fanpage.OrganizationId = request.OrganizationId;
            return await _context.SaveChangesAsync();
        }
    }
}
