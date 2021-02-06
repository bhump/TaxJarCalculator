using System;
using System.Net.Http;
using TaxJar.Clients.Handlers;
using TaxJar.Interfaces;

namespace TaxJar.Clients
{
    public class TaxClient : ITaxClient
    {
        private HttpClient taxClient;

        public TaxClient()
        {
        }

        public HttpClient Client
        {
            get
            {
                if (taxClient == null)
                {
                    var loghandler = new LoggingHandler();
                    var client = new HttpClient(loghandler);

                    taxClient = client;
                }

                return taxClient;
            }
        }
    }
}
