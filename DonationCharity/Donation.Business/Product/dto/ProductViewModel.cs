using System;
using System.Collections.Generic;
using System.Text;

namespace Donation.Business.Product.dto
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public int PaymentId { get; set; }
    }
}
