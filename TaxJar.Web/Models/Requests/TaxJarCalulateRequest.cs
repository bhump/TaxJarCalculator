using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace TaxJar.Api.Models.Requests
{
    public class TaxJarCalculateRequest
    {
        [JsonProperty("from_country")]
        public string FromCountry;

        [JsonProperty("from_zip")]
        public string FromZip;

        [JsonProperty("from_state")]
        public string FromState;

        [JsonProperty("from_city")]
        public string FromCity;

        [JsonProperty("from_street")]
        public string FromStreet;

        [JsonProperty("to_country")]
        public string ToCountry;

        [JsonProperty("to_zip")]
        public string ToZip;

        [JsonProperty("to_state")]
        public string ToState;

        [JsonProperty("to_city")]
        public string ToCity;

        [JsonProperty("to_street")]
        public string ToStreet;

        [JsonProperty("amount")]
        public int Amount;

        [JsonProperty("shipping")]
        public float Shipping;

        [JsonProperty("nexus_addresses")]
        public List<NexusAddress> NexusAddresses;

        [JsonProperty("line_items")]
        public List<LineItem> LineItems;
    }

    public class NexusAddress
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("country")]
        public string Country;

        [JsonProperty("zip")]
        public string Zip;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("city")]
        public string City;

        [JsonProperty("street")]
        public string Street;
    }

    public class LineItem
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("quantity")]
        public int Quantity;

        [JsonProperty("product_tax_code")]
        public string ProductTaxCode;

        [JsonProperty("unit_price")]
        public int UnitPrice;

        [JsonProperty("discount")]
        public int Discount;
    }
}

