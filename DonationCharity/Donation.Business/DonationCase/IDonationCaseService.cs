using Donation.Business.DonationCase.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.DonationCase
{
    public interface IDonationCaseService
    {
        Task<List<DonationCaseViewModel>> GetAll();
        Task<DonationCaseViewModel> GetById(int id);
        Task<int> Create(DonationCaseCreateRequest request);
        Task<int> Update(DonationCaseUpdateRequest request);
        Task<int> Delete(int id);
    }
}
