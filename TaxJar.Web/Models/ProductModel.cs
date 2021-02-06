using System;
namespace TaxJar.Api.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public string ProductTaxCode { get; set; }

        public int UnitPrice { get; set; }

        public float Discount { get; set; }
    }
}
