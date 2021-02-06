using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaxJar.Clients.Handlers
{
    public class LoggingHandler : DelegatingHandler
    {
        public LoggingHandler() : this(new HttpClientHandler())
        {

        }

        protected LoggingHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("Request: " + request);

            var response = await base.SendAsync(request, cancellationToken);

            Debug.WriteLine("Response: " + response);

            return response;
        }
    }
}
