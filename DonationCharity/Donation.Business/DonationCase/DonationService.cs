using Donation.Business.DonationCase.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.DonationCase
{
    public class DonationService : IDonationCaseService
    {
        public Task<int> Create(DonationCaseCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DonationCaseViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DonationCaseViewModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(DonationCaseUpdateRequest reqeust)
        {
            throw new NotImplementedException();
        }
    }
}
