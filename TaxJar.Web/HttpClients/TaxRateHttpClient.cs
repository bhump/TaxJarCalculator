using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using TaxJar.Api.HttpClients.Handlers;
using TaxJar.Api.Interfaces;

namespace TaxJar.Api.HttpClients
{
    public class TaxRateHttpClient : ITaxRateHttpClient
    {
        private HttpClient taxRateClient;
        private readonly IConfiguration configuration;

        public TaxRateHttpClient(IConfiguration configuraton)
        {
            configuration = configuraton;
        }

        public HttpClient Client
        {
            get
            {
                if (taxRateClient == null)
                {
                    var authHandler = new AuthenticationHandler(configuration);
                    var loghandler = new LoggingHandler(authHandler);
                    var client = new HttpClient(loghandler);

                    taxRateClient = client;
                }

                return taxRateClient;
            }
        }
    }
}
