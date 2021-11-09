using Donation.Business.Organizations.dto;
using Donation.Business.User.dto;
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
        Task<Donation.Data.Entities.User> GetUser(String email, String password);
        Task<string> Login(LoginRequest request);
        Task<int> Delete(int id);
    }
}
