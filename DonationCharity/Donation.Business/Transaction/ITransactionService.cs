using Donation.Business.Transaction.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Transaction
{
    public interface ITransactionService
    {
        Task<List<TransactionViewModel>> GetAll();
        Task<TransactionViewModel> GetById(int id);
        Task<int> Create(TransactionCreateRequest request);
        Task<int> Update(TransactionUpdateRequest request);
        Task<int> Delete(int id);
    }
}
