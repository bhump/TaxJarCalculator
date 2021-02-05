using System;
using System.Threading.Tasks;
using AutoMapper;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;

namespace TaxJar.Api.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository taxRepository;
        private readonly IMapper mapper;

        public TaxService(ITaxRepository taxRepository, IMapper mapper)
        {
            this.taxRepository = taxRepository;
            this.mapper = mapper;
        }

        public Task<OrderModel> Calculate(TaxCalculationRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetTaxRates()
        {
            throw new NotImplementedException();
        }

        public async Task<TaxRateModel> GetTaxRates(TaxRateRequest request)
        {
            TaxJarRateResponse response = null;

            TaxRateModel mapped = mapper.Map<TaxRateModel>(request);

            if (request == null)
            {
                throw new ArgumentException(nameof(request), "Request cannot be null. Zip code is required.");
            }

            if (string.IsNullOrEmpty(request.Zip))
            {
                throw new ArgumentException(nameof(request.Zip), "Zip Code is required.");
            }

            if(!string.IsNullOrEmpty(request.City) || !string.IsNullOrEmpty(request.State) || !string.IsNullOrEmpty(request.Street) || !string.IsNullOrEmpty(request.Country))
            {
                response = await taxRepository.Get<TaxRateModel, TaxJarRateResponse>(mapped);
            }
            else
            {
                response = await taxRepository.Get<TaxJarRateResponse>(request.Zip);
            }

            return mapper.Map<TaxRateModel>(response);
        }
    }
}
