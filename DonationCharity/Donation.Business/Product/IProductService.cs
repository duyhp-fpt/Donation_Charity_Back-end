using Donation.Business.Product.dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Donation.Business.Product
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(int id);
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int id);
    }
}
