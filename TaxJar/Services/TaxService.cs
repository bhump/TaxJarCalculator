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
            if (request == null)
            {
                throw new NullReferenceException();
            }

            if(string.IsNullOrEmpty(request.ClientId))
            {
                throw new ArgumentNullException(nameof(request.ClientId));
            }

            if (string.IsNullOrEmpty(request.ToCountry))
            {
                throw new ArgumentNullException(nameof(request.ToCountry));
            }

            if (string.IsNullOrEmpty(request.ToState))
            {
                throw new ArgumentNullException(nameof(request.ToState));
            }

            if (string.IsNullOrEmpty(request.ToZip) && request.ToCountry == "US" || string.IsNullOrEmpty(request.ToZip) && request.ToCountry == "CA")
            {
                throw new ArgumentNullException(nameof(request.ToZip));
            }

            var mapped = mapper.Map<TaxCalculationRequest>(request);

            var response = await taxRepository.Post<TaxCalculationRequest, TaxCalculationResponse>(mapped);

            return response;
        }

        public async Task<TaxRateResponse> GetRates(GetTaxRateModel request)
        {
            if (request == null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrEmpty(request.Zip))
            {
                throw new ArgumentNullException(nameof(request.Zip));
            }

            if (string.IsNullOrEmpty(request.Country))
            {
                throw new ArgumentNullException(nameof(request.Country));
            }

            var mapped = mapper.Map<TaxRateRequest>(request);

            return await taxRepository.Get<TaxRateRequest, TaxRateResponse>(mapped);
        }
    }
}
