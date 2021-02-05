using System;
using System.Threading.Tasks;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;

namespace TaxJar.Api.Interfaces
{
    public interface ITaxService
    {
        Task<string> GetTaxRates();

        Task<TaxRateModel> GetTaxRates(TaxRateRequest request);

        Task<OrderModel> Calculate(TaxCalculationRequest request);
    }
}
