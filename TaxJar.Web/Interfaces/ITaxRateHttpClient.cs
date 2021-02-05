using System;
using System.Net.Http;

namespace TaxJar.Api.Interfaces
{
    public interface ITaxRateHttpClient
    {
        public HttpClient Client { get; }
    }
}
