using Donation.Business.Fanpage.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Fanpage
{
    public interface IFanpageService
    {
        Task<List<FanpageViewModel>> GetAll();
        Task<FanpageViewModel> GetById(int id);
        Task<int> Create(FanpageCreateRequest request);
        Task<int> Update(FanpageUpdateRequest request);
        Task<int> Delete(int id);
    }
}
