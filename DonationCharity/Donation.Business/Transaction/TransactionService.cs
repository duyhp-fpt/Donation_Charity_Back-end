using Donation.Business.Transaction.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly DonationContext _context;
        public TransactionService(DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TransactionCreateRequest request)
        { 
            var transaction = new Donation.Data.Entities.Transaction()
            {
                DonatorId = request.DonatorId,
                CampaignId = request.CampaignId,
                Amount = request.Amount,
                Description = request.Description,
                DonateDate = request.DonateDate,
                DonatorCardNumber = request.DonatorCardNumber
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction.TransactionId;
        }

        public async Task<int> Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null) throw new Exception("not found this transaction");
            _context.Transactions.Remove(transaction);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TransactionViewModel>> GetAll()
        {
            var query = from c in _context.Transactions
                        select new { c };
            return await query.Select(x => new TransactionViewModel()
            {
                TransactionId = x.c.TransactionId,
                DonatorId = (int)x.c.DonatorId,
                CampaignId = (int)x.c.CampaignId,
                Amount = (double)x.c.Amount,
                Description = x.c.Description,
                DonateDate = (DateTime)x.c.DonateDate,
                DonatorCardNumber = x.c.DonatorCardNumber
            }).ToListAsync();
        }

        public async Task<TransactionViewModel> GetById(int id)
        {
            var query = from c in _context.Transactions
                        where c.TransactionId == id
                        select new { c };
            return await query.Select(x => new TransactionViewModel()
            {
                TransactionId = x.c.TransactionId,
                DonatorId = (int)x.c.DonatorId,
                CampaignId = (int)x.c.CampaignId,
                Amount = (double)x.c.Amount,
                Description = x.c.Description,
                DonateDate = (DateTime)x.c.DonateDate,
                DonatorCardNumber = x.c.DonatorCardNumber
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(TransactionUpdateRequest request)
        {
            var transaction = await _context.Transactions.FindAsync(request.TransactionId);
            if (transaction == null) throw new Exception("not found");

            transaction.TransactionId = request.TransactionId;
            transaction.DonatorId = request.DonatorId;
            transaction.CampaignId = (request.CampaignId);
            transaction.Amount = request.Amount;
            transaction.Description = request.Description;
            transaction.DonateDate = request.DonateDate;
            transaction.DonatorCardNumber = request.DonatorCardNumber;
            return await _context.SaveChangesAsync();
        }
    }
}
