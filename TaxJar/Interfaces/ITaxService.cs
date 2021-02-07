using System;
using System.Threading.Tasks;
using TaxJar.Models;
using TaxJar.Models.Requests;
using TaxJar.Models.Responses;

namespace TaxJar.Interfaces
{
    public interface ITaxService
    {
        Task<TaxRateResponse> GetRates(GetTaxRateModel request);

        Task<TaxCalculationResponse> Calculate(GetCalculationModel request);
    }
}
