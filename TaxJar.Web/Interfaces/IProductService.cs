using System;
using System.Threading.Tasks;
using TaxJar.Api.Models;

namespace TaxJar.Api.Interfaces
{
    public interface IProductService
    {
        ProductModel GetProduct(string id);
    }
}
