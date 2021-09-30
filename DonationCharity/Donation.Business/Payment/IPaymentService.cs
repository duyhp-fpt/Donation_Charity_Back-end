using Donation.Business.Payment.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Payment
{
    public interface IPaymentService
    {
        Task<List<PaymentViewModel>> GetAll();
        Task<PaymentViewModel> GetById(int id);
        Task<int> Create(PaymentCreateRequest request);
        Task<int> Update(PaymentUpdateRequest request);
        Task<int> Delete(int id);
    }
}
