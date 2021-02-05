using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace TaxJar.Api.HttpClients.Handlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly Microsoft.Extensions.Configuration
.IConfiguration configuration;
        private string taxJarApiKey = string.Empty;

        public AuthenticationHandler(Microsoft.Extensions.Configuration.
IConfiguration configuration) : this(new HttpClientHandler())
        {
            this.configuration = configuration;
            taxJarApiKey = configuration["TaxJarKey"];
        }

        protected AuthenticationHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", taxJarApiKey);

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
