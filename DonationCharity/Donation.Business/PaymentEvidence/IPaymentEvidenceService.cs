using Donation.Business.PaymentEvidence.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.PaymentEvidence
{
    public interface IPaymentEvidenceService
    {
        Task<List<PaymentEvidenceViewModel>> GetAll();
        Task<PaymentEvidenceViewModel> GetById(int id);
        Task<int> Create(PaymentEvidenceCreateRequest request);
        Task<int> Update(PaymentEvidenceUpdateRequest request);
        Task<int> Delete(int id);
    }
}
