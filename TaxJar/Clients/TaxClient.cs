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
                    //NOTE:Ran into a problem debugging locally with Web API - I think my certs are broken. Need to look into later. For now, bypass SSL
#if DEBUG
                    HttpClientHandler clientHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                    };
                    var client = new HttpClient(clientHandler);
#else

                    var loghandler = new LoggingHandler();
                    var client = new HttpClient(loghandler);
#endif

                    taxClient = client;
                }

                return taxClient;
            }
        }
    }
}
