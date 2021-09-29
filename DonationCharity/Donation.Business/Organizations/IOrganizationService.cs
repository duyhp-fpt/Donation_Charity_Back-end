using Donation.Business.Organizations.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Organizations
{
    public interface IOrganizationService
    {
        Task<List<OrganizationViewModel>> GetAll();
        Task<OrganizationViewModel> GetById(int id);
        Task<int> Create(OrganizationCreateRequest request);
        Task<int> Update(OrganizationUpdateRequest request);
    }
}
