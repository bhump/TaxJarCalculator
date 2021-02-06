using System;
using System.Net.Http;

namespace TaxJar.Interfaces
{
    public interface ITaxClient
    {
        HttpClient Client { get; }
    }
}
