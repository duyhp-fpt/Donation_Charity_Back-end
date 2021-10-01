using Donation.Business.Admins.dto;
using Donation.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Donation.Data.Entities;

namespace Donation.Business.Admins
{
    public class AdminService : IAdminService
    {
        private readonly DonationContext _context;
        public AdminService(DonationContext context)
        {
            _context = context;
        }


        public async Task<AdminViewModel> GetAdminById(int id)
        {
            var query = from c in _context.Admins
                        where c.AdminId == id
                        select new { c };

            return await query.Select(x => new AdminViewModel()
            {
                AdminId = x.c.AdminId,
                UserName = x.c.UserName,
                PhoneNumber = x.c.PhoneNumber,
                Email = x.c.Email
            }).FirstOrDefaultAsync();
        }

        public async Task<List<AdminViewModel>> GetAllAdmin()
        {
            var query = from c in _context.Admins
                        select new { c };

            return await query.Select(a => new AdminViewModel()
            {
                AdminId = a.c.AdminId,
                UserName = a.c.UserName,
                Email = a.c.Email,
                PhoneNumber = a.c.PhoneNumber
            }).ToListAsync();
        }

        public async Task<Admin> loginAdmin(string userName, string password)
        {
            var query =from admin in _context.Admins
                       where admin.UserName == userName && admin.Password==password
                       select new { admin};
            /*return await query.Select(x => new AdminViewModel()
            {
                AdminId = x.admin.AdminId,
                UserName = x.admin.UserName,
                PhoneNumber = x.admin.PhoneNumber,
                Email = x.admin.Email
            }).FirstOrDefaultAsync();*/
            Admin admin1 = (from admin in _context.Admins
                                     where admin.UserName == userName && admin.Password == password
                                     select admin).FirstOrDefault();
            return admin1;
        }
    }
}
