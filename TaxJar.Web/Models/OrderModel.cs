using System;
namespace TaxJar.Api.Models
{
    public class OrderModel
    {
        public string ClientId { get; set; }

        public string ToCountry { get; set; }

        public string ToZip { get; set; }

        public string ToState { get; set; }

        public float Shipping { get; set; }

        public DateTime? DateCalculated { get; set; }
    }
}
