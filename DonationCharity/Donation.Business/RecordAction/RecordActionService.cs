using Donation.Business.RecordAction.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Donation.Business.RecordAction
{
    public class RecordActionService : IRecordActionService
    {
        private readonly DonationContext _context;
        public RecordActionService(DonationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(RecordActionCreateRequest request)
        {
            var recordAction = new Donation.Data.Entities.RecordAction()
            {
                UserId = request.UserId,
                Action = request.Action,
                Time = request.Time
            };
            _context.RecordActions.Add(recordAction);
            await _context.SaveChangesAsync();
            return recordAction.RecordId;
        }

        public async Task<int> Delete(int id)
        {
            var recordAction = await _context.RecordActions.FindAsync(id);
            if (recordAction == null) throw new Exception("not found this record action");
            _context.RecordActions.Remove(recordAction);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<RecordActionViewModel>> GetAll()
        {
            var query = from c in _context.RecordActions
                        select new { c };
            return await query.Select(x => new RecordActionViewModel()
            {
                RecordId = x.c.RecordId,
                UserId = (int)x.c.UserId,
                Action = x.c.Action,
                Time = (DateTime)x.c.Time
            }).ToListAsync();
        }

        public async Task<RecordActionViewModel> GetById(int id)
        {
            var query = from c in _context.RecordActions
                        where c.RecordId == id
                        select new { c };
            return await query.Select(x => new RecordActionViewModel()
            {
                RecordId = x.c.RecordId,
                UserId = (int)x.c.UserId,
                Action = x.c.Action,
                Time = (DateTime)x.c.Time
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(RecordActionUpdateRequest request)
        {
            var recordAction = await _context.RecordActions.FindAsync(request.RecordId);
            if (recordAction == null) throw new Exception("not found");

            recordAction.UserId = request.UserId;
            recordAction.Action = request.Action;
            recordAction.Time = request.Time;
            return await _context.SaveChangesAsync();
        }
    }
}
