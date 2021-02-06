using System;
using System.Threading.Tasks;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;

namespace TaxJar.Api.Services
{
    public class ProductService : IProductService
    {
        public ProductService()
        {
        }

        public ProductModel GetProduct(string id)
        {
            //NOTE: Return mocked data since data source isn't connected
            //TODO: Set up repositories on data source is available
            var product = new ProductModel
            {
                Id = "1",
                Quantity = 1,
                ProductTaxCode = "20010",
                UnitPrice = 15,
                Discount = 0
            };

            return product;
        }
    }
}
