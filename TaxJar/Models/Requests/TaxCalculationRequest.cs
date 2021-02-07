using System;
namespace TaxJar.Models.Requests
{
    public class TaxCalculationRequest
    {
        public string ClientId { get; set; }

        public string ProductId { get; set; }

        public string ToCountry { get; set; }

        public string ToZip { get; set; }

        public string ToState { get; set; }

        public string ToCity { get; set; }

        public string ToStreet { get; set; }

        public float Shipping { get; set; }

        public int Amount { get; set; }
    }
}
