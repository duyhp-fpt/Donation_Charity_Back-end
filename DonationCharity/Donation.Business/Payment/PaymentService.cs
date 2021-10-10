using Donation.Business.Payment.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly DonationContext _context;
        public PaymentService(
            DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PaymentCreateRequest request)
        {
            var payment = new Donation.Data.Entities.Payment()
            {
                PaymentDate = request.PaymentDate,
                TotalPrice = request.TotalPrice,
                Status = true
            };
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment.PaymentId;
        }

        public async Task<int> Delete(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) throw new Exception("not found this payment");
            payment.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PaymentViewModel>> GetAll()
        {
            var query = from c in _context.Payments
                        where c.Status == true
                        select new { c };
            return await query.Select(x => new PaymentViewModel()
            {
                PaymentId = x.c.PaymentId,
                PaymentDate = (DateTime)x.c.PaymentDate,
                TotalPrice = (double)x.c.TotalPrice
            }).ToListAsync();
        }

        public async Task<PaymentViewModel> GetById(int id)
        {
            var query = from c in _context.Payments
                        where c.PaymentId == id && c.Status == true
                        select new { c };
            return await query.Select(x => new PaymentViewModel()
            {
                PaymentId = x.c.PaymentId,
                PaymentDate = (DateTime)x.c.PaymentDate,
                TotalPrice = (double)x.c.TotalPrice
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(PaymentUpdateRequest request)
        {
            var payment = await _context.Payments.FindAsync(request.PaymentId);
            if (payment == null) throw new Exception("not found");

            payment.PaymentDate = request.PaymentDate;
            payment.TotalPrice = request.TotalPrice;
            return await _context.SaveChangesAsync();
        }
    }
}
