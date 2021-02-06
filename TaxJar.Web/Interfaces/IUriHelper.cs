using System;
namespace TaxJar.Api.Interfaces
{
    public interface IUriHelper
    {
        Uri CreateUri(string baseUrl, string endpoint);

        Uri CreateUri(string baseUrl, string endpoint, string id);

        Uri CreateUri(string baseUrl, string endpoint, string id, string queryString);

        string CreateQueryString(object obj);
    }
}
