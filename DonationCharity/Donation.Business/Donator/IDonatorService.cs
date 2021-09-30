using Donation.Business.Donator.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Donator
{
    public interface IDonatorService
    {
        Task<List<DonatorViewModel>> GetAll();
        Task<DonatorViewModel> GetById(int id);
        Task<int> Create(DonatorCreateRequest request);
        Task<int> Update(DonatorUpdateRequest request);
    }
}
