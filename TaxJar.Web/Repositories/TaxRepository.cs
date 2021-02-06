using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TaxJar.Api.Constants;
using TaxJar.Api.HttpClients;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;

namespace TaxJar.Api.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private readonly IUriHelper uriHelper;
        private readonly IMapper mapper;
        private readonly ITaxRateHttpClient taxRateHttpClient;
        private readonly string baseUrl = UrlConstants.BaseUrl;

        public TaxRepository(IUriHelper uriHelper, IMapper mapper, ITaxRateHttpClient taxRateHttpClient)
        {
            this.uriHelper = uriHelper;
            this.mapper = mapper;
            this.taxRateHttpClient = taxRateHttpClient;
        }

        public Task<T> Delete<T>(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        //NOTE: id is zip code in this scenario
        public async Task<T> Get<T>(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id), "Zip cannot be null or empty");
            }

            Uri uri = uriHelper.CreateUri(baseUrl, UrlConstants.Rates, id);

            HttpResponseMessage response = await taxRateHttpClient.Client.GetAsync(uri);

            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(responseContent);
        }

        public async Task<Tout> Get<Tin, Tout>(Tin request)
        {
            try
            {
                TaxRateModel mapped = mapper.Map<Tin, TaxRateModel>(request);
                string zip = mapped.Zip;

                TaxRateModel queryObject = mapped;
                queryObject.Zip = string.Empty;

                string query = uriHelper.CreateQueryString(queryObject);

                var url = uriHelper.CreateUri(baseUrl, UrlConstants.Rates, zip, query);

                HttpResponseMessage response = await taxRateHttpClient.Client.GetAsync(url);

                string responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Tout>(responseContent);
            }
            catch(Exception ex)
            {
                Console.Write(ex);

                throw;
            }
        }

        public Task<Tout> Patch<Tin, Tout>(Tin request)
        {
            throw new NotImplementedException();
        }

        public async Task<Tout> Post<Tin, Tout>(Tin request)
        {
            try
            {
                OrderModel orderModelMapped = mapper.Map<Tin, OrderModel>(request);

                TaxJarCalculateRequest mapped = mapper.Map<OrderModel, TaxJarCalculateRequest>(orderModelMapped);

                Uri uri = uriHelper.CreateUri(baseUrl, UrlConstants.Taxes);

                string json = JsonConvert.SerializeObject(mapped);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await taxRateHttpClient.Client.PostAsync(uri, content);

                string responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Tout>(responseContent);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Tout> Put<Tin, Tout>(Tin request)
        {
            throw new NotImplementedException();
        }
    }
}
