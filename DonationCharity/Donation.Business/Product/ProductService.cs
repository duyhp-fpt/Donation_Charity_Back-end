using Donation.Business.Product.dto;
using Donation.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using System.IO;
using Donation.Business.Image;

namespace Donation.Business.Product
{
    public class ProductService : IProductService
    {
        private readonly DonationContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ProductService(DonationContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Donation.Data.Entities.Product()
            {
                ProductName = request.ProductName,
                Amount = request.Amount,
                Price = request.Price,
                PaymentId = request.PaymentId,
                Status = true
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.ProductId;
        }

        public async Task<int> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("not found this product");
            product.Status = false;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from c in _context.Products
                        where c.Status == true
                        select new { c };
            return await query.Select(x => new ProductViewModel()
            {
                ProductId = x.c.ProductId,
                ProductName = x.c.ProductName,
                Amount = (double)x.c.Amount,
                Price = (double)x.c.Price,
                PaymentId = (int)x.c.PaymentId
            }).ToListAsync();
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var query = from c in _context.Products
                        where c.ProductId == id && c.Status == true
                        select new { c };
            return await query.Select(x => new ProductViewModel()
            {
                ProductId = x.c.ProductId,
                ProductName = x.c.ProductName,
                Amount = (double)x.c.Amount,
                Price = (double)x.c.Price,
                PaymentId = (int)x.c.PaymentId
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null) throw new Exception("not found");

            product.ProductName = request.ProductName;
            product.Amount = request.Amount;
            product.Price = request.Price;
            product.PaymentId = request.PaymentId;
            return await _context.SaveChangesAsync();
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}
