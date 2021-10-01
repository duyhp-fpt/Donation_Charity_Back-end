using Donation.Business.Admins.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Admins
{
    public interface IAdminService
    {
        Task<List<AdminViewModel>> GetAllAdmin();
        Task<AdminViewModel> GetAdminById(int id);

        Task<Admin> loginAdmin(string userName,string password);
    }
}
