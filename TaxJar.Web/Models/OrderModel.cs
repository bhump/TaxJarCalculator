using System;
using System.Collections.Generic;

namespace TaxJar.Api.Models
{
    public class OrderModel
    {
        public string ClientId { get; set; }

        public string ToCountry { get; set; }

        public string ToCity { get; set; }

        public string ToZip { get; set; }

        public string ToState { get; set; }

        public string ToStreet { get; set; }

        public float Shipping { get; set; }

        public string FromCountry { get; set; }

        public string FromZip { get; set; }

        public string FromState { get; set; }

        public string FromCity { get; set; }

        public string FromStreet { get; set; }

        public IEnumerable<LineItem> LineItems { get; set; }

        public int Amount { get; set; }

        public DateTime? DateCalculated { get; set; }
    }

    public class LineItem
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public string ProductTaxCode { get; set; }

        public float UnitPrice { get; set; }

        public float Discount { get; set; }
    }

}
