using System;
using System.Threading.Tasks;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;
using TaxJar.Api.Models.Responses;

namespace TaxJar.Api.Interfaces
{
    public interface ITaxService
    {
        Task<string> GetTaxRates();

        Task<TaxRateModel> GetTaxRates(TaxRateRequest request);

        Task<TaxJarCalculateResponse> Calculate(TaxCalculationRequest request);
    }
}
