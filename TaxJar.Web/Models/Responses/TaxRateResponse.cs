using System;
using Newtonsoft.Json;

namespace TaxJar.Api.Models.Responses
{
    public class TaxRateResponse
    {
        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state_rate")]
        public float StateRate { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("county")]
        public string County { get; set; }

        [JsonProperty("county_rate")]
        public float CountyRate { get; set; }

        [JsonProperty("country_rate")]
        public float CountryRate { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_rate")]
        public float CityRate { get; set; }

        [JsonProperty("combined_district_rate")]
        public float CombinedDistrictRate { get; set; }

        [JsonProperty("combined_rate")]
        public float CombinedRate { get; set; }

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        [JsonProperty("date_requested")]
        public DateTime DateRequested { get; set; }

        [JsonProperty("standard_rate")]
        public float StandardRate { get; set; }

        [JsonProperty("reduced_rate")]
        public float ReducedRate { get; set; }

        [JsonProperty("super_reduced_rate")]
        public float SuperReducedRate { get; set; }

        [JsonProperty("parking_rate")]
        public float ParkingRate { get; set; }

        [JsonProperty("distance_sale_threshold")]
        public float DistanceSaleThreshold { get; set; }
    }
}
