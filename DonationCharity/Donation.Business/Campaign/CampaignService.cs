using Donation.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Donation.Data.Entities;
using Donation.Business.Campaign.dto;
using Donation.Business.Paging;

namespace Donation.Business.Campaign
{
    public class CampaignService : ICampaignService
    {
        private readonly DonationContext _context;
        public CampaignService(DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CampaignCreateRequest request)
        {
            var campaign = new Donation.Data.Entities.Campaign()
            {
                CampaignName = request.CampaignName,
                OrganizationId =request.OrganizationId,
                Description =request.Description,
                Title = request.Title,
                DateCreate = request.DateCreate,
                Image =request.Image,
                DonationCaseId = request.DonationCaseId,
                CardNumber = request.CardNumber,
                PaymentId = request.PaymentId
            };
            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();
            return campaign.CampaignId;
        }

        public async Task<List<CampaignViewModel>> GetAll()
        {
            var query = from c in _context.Campaigns
                                    select new { c };

            return await query.Select(x => new CampaignViewModel()
            {
                CampaignId = x.c.CampaignId,
                CampaignName = x.c.CampaignName,
                CardNumber = x.c.CardNumber,
                DateCreate = (DateTime)x.c.DateCreate,
                Description = x.c.Description,
                DonationCaseId = (int)x.c.DonationCaseId,
                Image = x.c.Image,
                OrganizationId = (int)x.c.OrganizationId,
                PaymentId = (int)x.c.PaymentId,
                Title = x.c.Title
            }).ToListAsync();
        }

        public async Task<PageResult<CampaignViewModel>> GetAllPaging(GetCampaignPagingRequest request)
        {
            var query = from c in _context.Campaigns
                        join dc in _context.DonationCases on c.DonationCaseId equals dc.DonationCaseId
                        select new { c, dc };
            //filter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.c.CampaignName.Contains(request.keyword));

            if(request.DonationCaseId != null && request.DonationCaseId != 0)
            {
                query = query.Where(p => p.dc.DonationCaseId == request.DonationCaseId);
            }
            //paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new CampaignViewModel()
                {
                    CampaignId = x.c.CampaignId,
                    CampaignName = x.c.CampaignName,
                    CardNumber = x.c.CardNumber,
                    DateCreate = (DateTime)x.c.DateCreate,
                    Description = x.c.Description,
                    DonationCaseId = (int)x.c.DonationCaseId,
                    Image = x.c.Image,
                    OrganizationId = (int)x.c.OrganizationId,
                    PaymentId = (int)x.c.PaymentId,
                    Title = x.c.Title
                }).ToListAsync();

            // select and projection
            var pagedResult = new PageResult<CampaignViewModel>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<CampaignViewModel> GetById(int id)
        {
            var query = from c in _context.Campaigns
                        where c.CampaignId == id
                        select new { c };

            return await query.Select(x => new CampaignViewModel()
            {
                CampaignId = x.c.CampaignId,
                CampaignName = x.c.CampaignName,
                CardNumber = x.c.CardNumber,
                DateCreate = (DateTime)x.c.DateCreate,
                Description = x.c.Description,
                DonationCaseId = (int)x.c.DonationCaseId,
                Image = x.c.Image,
                OrganizationId = (int)x.c.OrganizationId,
                PaymentId = (int)x.c.PaymentId,
                Title = x.c.Title
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(CampaignUpdateRequest request)
        {
            var campaign = await _context.Campaigns.FindAsync(request.CampaignId);
            if (campaign == null) throw new Exception("not found");

            campaign.CampaignName = request.CampaignName;
            campaign.Description = request.Description;
            campaign.Title = request.Title;
            campaign.Image = request.Image;
            campaign.DonationCaseId = request.DonationCaseId;
            campaign.CardNumber = request.CardNumber;
            return await _context.SaveChangesAsync();
        }
    }
}
