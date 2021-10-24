using Donation.Business.PaymentEvidence.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Donation.Business.Image;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;

namespace Donation.Business.PaymentEvidence
{
    public class PaymentEvidenceService : IPaymentEvidenceService
    {
        private readonly DonationContext _context;
        private readonly IStorageService _storageService;
        public PaymentEvidenceService( DonationContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(PaymentEvidenceCreateRequest request)
        {
            var paymentEvidence = new Donation.Data.Entities.PaymentEvidence()
            {
                PaymentEvidenceDate = DateTime.Now,
                ProductId = request.ProductId,
                Status = true

            };
            if (request.PaymentEvidenceImage != null)
            {
                paymentEvidence.PaymentEvidenceImage = await this.SaveFile(request.PaymentEvidenceImage);
            }
            _context.PaymentEvidences.Add(paymentEvidence);
            await _context.SaveChangesAsync();
            return paymentEvidence.PaymentEvidenceId;
        }

        public async Task<int> Delete(int id)
        {
            var paymentEvidence = await _context.PaymentEvidences.FindAsync(id);
            if (paymentEvidence == null) throw new Exception("not found this payment evidence");
            paymentEvidence.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<PaymentEvidenceViewModel>> GetAll()
        {
            var query = from c in _context.PaymentEvidences
                        where c.Status == true
                        select new { c };
            return await query.Select(x => new PaymentEvidenceViewModel()
            {
                PaymentEvidenceId = x.c.PaymentEvidenceId,
                PaymentEvidenceImage = x.c.PaymentEvidenceImage,
                PaymentEvidenceDate = (DateTime)x.c.PaymentEvidenceDate,
                ProductId = x.c.ProductId

            }).ToListAsync();
        }

        public async Task<PaymentEvidenceViewModel> GetById(int id)
        {
            var query = from c in _context.PaymentEvidences
                        where c.PaymentEvidenceId == id && c.Status == true
                        select new { c };
            return await query.Select(x => new PaymentEvidenceViewModel()
            {
                PaymentEvidenceId = x.c.PaymentEvidenceId,
                PaymentEvidenceImage = x.c.PaymentEvidenceImage,
                PaymentEvidenceDate = (DateTime)x.c.PaymentEvidenceDate,
                ProductId = x.c.ProductId
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(PaymentEvidenceUpdateRequest request)
        {
            var paymentEvidence = await _context.PaymentEvidences.FindAsync(request.PaymentEvidenceId);
            if (paymentEvidence == null) throw new Exception("not found");

            paymentEvidence.PaymentEvidenceImage = request.PaymentEvidenceImage;
            paymentEvidence.PaymentEvidenceDate = DateTime.Now;
            paymentEvidence.ProductId = request.ProductId;
            return await _context.SaveChangesAsync();
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
