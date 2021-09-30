using Donation.Business.RecordAction.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.RecordAction
{
    public interface IRecordActionService
    {
        Task<List<RecordActionViewModel>> GetAll();
        Task<RecordActionViewModel> GetById(int id);
        Task<int> Create(RecordActionCreateRequest request);
        Task<int> Update(RecordActionUpdateRequest request);
        Task<int> Delete(int id);
    }
}
