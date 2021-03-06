using Donation.Business.PaymentEvidence.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.PaymentEvidence
{
    public class PaymentEvidenceService : IPaymentEvidenceService
    {
        private readonly DonationContext _context;
        public PaymentEvidenceService( DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PaymentEvidenceCreateRequest request)
        {
            var paymentEvidence = new Donation.Data.Entities.PaymentEvidence()
            {
                PaymentEvidenceImage = request.PaymentEvidenceImage,
                PaymentEvidenceDate = request.PaymentEvidenceDate
            };
            _context.PaymentEvidences.Add(paymentEvidence);
            await _context.SaveChangesAsync();
            return paymentEvidence.PaymentEvidenceId;
        }

        public async Task<int> Delete(int id)
        {
            var paymentEvidence = await _context.PaymentEvidences.FindAsync(id);
            if (paymentEvidence == null) throw new Exception("not found this payment evidence");
            _context.PaymentEvidences.Remove(paymentEvidence);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PaymentEvidenceViewModel>> GetAll()
        {
            var query = from c in _context.PaymentEvidences
                        select new { c };
            return await query.Select(x => new PaymentEvidenceViewModel()
            {
                PaymentEvidenceId = x.c.PaymentEvidenceId,
                PaymentEvidenceImage = x.c.PaymentEvidenceImage,
                PaymentEvidenceDate = (DateTime)x.c.PaymentEvidenceDate
            }).ToListAsync();
        }

        public async Task<PaymentEvidenceViewModel> GetById(int id)
        {
            var query = from c in _context.PaymentEvidences
                        where c.PaymentEvidenceId == id
                        select new { c };
            return await query.Select(x => new PaymentEvidenceViewModel()
            {
                PaymentEvidenceId = x.c.PaymentEvidenceId,
                PaymentEvidenceImage = x.c.PaymentEvidenceImage,
                PaymentEvidenceDate = (DateTime)x.c.PaymentEvidenceDate
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(PaymentEvidenceUpdateRequest request)
        {
            var paymentEvidence = await _context.PaymentEvidences.FindAsync(request.PaymentEvidenceId);
            if (paymentEvidence == null) throw new Exception("not found");

            paymentEvidence.PaymentEvidenceImage = request.PaymentEvidenceImage;
            paymentEvidence.PaymentEvidenceDate = request.PaymentEvidenceDate;
            return await _context.SaveChangesAsync();
        }
    }
}
