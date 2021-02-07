using System;
using System.Threading.Tasks;
using AutoMapper;
using TaxJar.Interfaces;
using TaxJar.Models;
using TaxJar.Models.Requests;
using TaxJar.Models.Responses;

namespace TaxJar.Services
{
    public class TaxService : ITaxService
    {
        private ITaxRepository taxRepository;
        private IMapper mapper;

        public TaxService(ITaxRepository taxRepository, IMapper mapper)
        {
            this.taxRepository = taxRepository;
            this.mapper = mapper;
        }

        public async Task<TaxCalculationResponse> Calculate(GetCalculationModel request)
        {
            try
            {
                var mapped = mapper.Map<TaxCalculationRequest>(request);

                var response = await taxRepository.Post<TaxCalculationRequest, TaxCalculationResponse>(mapped);

                return response;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<TaxRateResponse> GetRates(GetTaxRateModel request)
        {
            var mapped = mapper.Map<TaxRateRequest>(request);

            return await taxRepository.Get<TaxRateRequest, TaxRateResponse>(mapped);
        }
    }
}
