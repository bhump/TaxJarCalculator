using System;
using System.Linq;
using System.Web;
using TaxJar.Api.Interfaces;

namespace TaxJar.Api.Helpers
{
    public class UriHelper : IUriHelper
    {
        public UriHelper()
        {
        }

        public Uri CreateUri(string baseUrl, string endpoint)
        {
            return new Uri($"{baseUrl}{endpoint}");
        }

        public Uri CreateUri(string baseUrl, string endpoint, string id)
        {
            return new Uri($"{baseUrl}{endpoint}/{id}");
        }

        public Uri CreateUri(string baseUrl, string endpoint, string id, string queryString)
        {
            return new Uri($"{baseUrl}{endpoint}/{id}?{queryString}");
        }

        public string CreateQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             where (string)p.GetValue(obj, null) != string.Empty
                             select p.Name.ToLower() + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString().ToLower());

            return string.Join("&", properties.ToArray());
        }
    }
}
