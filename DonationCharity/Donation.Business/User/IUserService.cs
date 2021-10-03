using Donation.Business.Organizations.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Organizations
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(int id);
        Task<int> Create(UserCreateRequest request);
        Task<int> Update(UserUpdateRequest request);
    }
}
