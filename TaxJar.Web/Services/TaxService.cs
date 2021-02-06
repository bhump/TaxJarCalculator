using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;
using TaxJar.Api.Models.Responses;

namespace TaxJar.Api.Services
{
    public class TaxService : ITaxService
    {
        private readonly ITaxRepository taxRepository;
        private readonly IProductService productService;
        private readonly IClientService clientService;
        private readonly IMapper mapper;

        public TaxService(ITaxRepository taxRepository, IMapper mapper, IClientService clientService, IProductService productService)
        {
            this.taxRepository = taxRepository;
            this.mapper = mapper;
            this.productService = productService;
            this.clientService = clientService;
        }

        public async Task<TaxJarCalculateResponse> Calculate(TaxCalculationRequest request)
        {
            OrderModel mapped = mapper.Map<OrderModel>(request);

            //NOTE: Returning mocked data so clientId isn't used right now
            ClientModel client = clientService.GetClient(mapped.ClientId);
            ProductModel product = productService.GetProduct(request.ProductId);

            var lineItems = new List<Models.LineItem>
            {
                mapper.Map<Models.LineItem>(product)
            };

            mapped.LineItems = lineItems;
            mapped.FromCity = client.City;
            mapped.FromCountry = client.Country;
            mapped.FromState = client.State;
            mapped.FromStreet = client.Street;
            mapped.FromZip = client.Zip;

            TaxJarCalculateResponse response = null;

            response = await taxRepository.Post<OrderModel, TaxJarCalculateResponse>(mapped);

            //TODO: Add mapping to TaxCalculationResposne, but for sake of time, return object from TaxJar. I would like to flatten this response out eventually.
            return response;
        }

        public Task<string> GetTaxRates()
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
