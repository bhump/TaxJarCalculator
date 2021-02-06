using System;
using System.Threading.Tasks;
using TaxJar.Api.Interfaces;
using TaxJar.Api.Models;

namespace TaxJar.Api.Services
{
    public class ClientService : IClientService
    {
        public ClientService()
        {
        }

        public ClientModel GetClient(string id)
        {
            //NOTE: Return mocked data since data source isn't connected
            //TODO: Set up repositories on data source is available
            var client = new ClientModel
            {
                Id = "1",
                Country = "US",
                City = "La Jolla",
                State = "CA",
                Street = "9500 Gilman Drive",
                Zip = "92093",
                Name = "Company Name Here"
            };

            return client;
        }
    }
}
