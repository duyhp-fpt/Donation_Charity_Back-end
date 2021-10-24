using Donation.Business.Campaign.dto;
using Donation.Business.Paging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Campaign
{
    public interface ICampaignService
    {
        public Task<List<CampaignViewModel>> GetAll();
        public Task<CampaignViewModel> GetById(int id);
        public Task<int> Create(CampaignCreateRequest request);
        public Task<int> Update(CampaignUpdateRequest request);
        Task<PageResult<CampaignViewModel>> GetAllPaging(GetCampaignPagingRequest request);
        Task<string> SaveFile(IFormFile file);

    }
}
