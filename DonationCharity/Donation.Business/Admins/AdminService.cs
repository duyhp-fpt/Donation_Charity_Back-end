﻿using Donation.Business.Admins.dto;
using Donation.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Donation.Business.Admins
{
    public class AdminService : IAdminService
    {
        private readonly DonationDbContext _context;
        public AdminService(DonationDbContext context)
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
    }
}