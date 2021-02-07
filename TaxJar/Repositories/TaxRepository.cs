using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaxJar.Constants;
using TaxJar.Interfaces;

namespace TaxJar.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        private ITaxClient taxClient;

        public TaxRepository(ITaxClient taxClient)
        {
            this.taxClient = taxClient;
        }

        public Task<T> Delete<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tout> Get<Tin, Tout>(Tin request)
        {
            try
            {
                string url = $"{UrlConstants.BaseUrl}{UrlConstants.Tax}";

                string json = JsonConvert.SerializeObject(request);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get,
                    Content = content
                };

                HttpResponseMessage response = await taxClient.Client.SendAsync(requestMessage);

                var responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Tout>(responseContent);
            }
            catch(Exception ex)
            {
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
                var url = $"{UrlConstants.BaseUrl}{UrlConstants.Tax}";

                string json = JsonConvert.SerializeObject(request);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await taxClient.Client.PostAsync(new Uri(url), content);

                string responseContent = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Tout>(responseContent);
            }
            catch(Exception ex)
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
