using System;
namespace TaxJar.Api.Models.Requests
{
    public class TaxRateRequest
    {
        public string Zip { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
