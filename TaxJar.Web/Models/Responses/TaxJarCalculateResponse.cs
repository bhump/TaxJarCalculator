using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaxJar.Api.Models.Responses
{

    public class TaxJarCalculateResponse
    {
        [JsonProperty("tax")]
        public Tax Tax;
    }

    public class Jurisdictions
    {
        [JsonProperty("country")]
        public string Country;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("county")]
        public string County;

        [JsonProperty("city")]
        public string City;
    }

    public class LineItem
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("taxable_amount")]
        public float TaxableAmount;

        [JsonProperty("tax_collectable")]
        public float TaxCollectable;

        [JsonProperty("combined_tax_rate")]
        public float CombinedTaxRate;

        [JsonProperty("state_taxable_amount")]
        public float StateTaxableAmount;

        [JsonProperty("state_sales_tax_rate")]
        public float StateSalesTaxRate;

        [JsonProperty("state_amount")]
        public float StateAmount;

        [JsonProperty("county_taxable_amount")]
        public float CountyTaxableAmount;

        [JsonProperty("county_tax_rate")]
        public float CountyTaxRate;

        [JsonProperty("county_amount")]
        public float CountyAmount;

        [JsonProperty("city_taxable_amount")]
        public float CityTaxableAmount;

        [JsonProperty("city_tax_rate")]
        public float CityTaxRate;

        [JsonProperty("city_amount")]
        public float CityAmount;

        [JsonProperty("special_district_taxable_amount")]
        public float SpecialDistrictTaxableAmount;

        [JsonProperty("special_tax_rate")]
        public float SpecialTaxRate;

        [JsonProperty("special_district_amount")]
        public float SpecialDistrictAmount;
    }

    public class Breakdown
    {
        [JsonProperty("taxable_amount")]
        public float TaxableAmount;

        [JsonProperty("tax_collectable")]
        public float TaxCollectable;

        [JsonProperty("combined_tax_rate")]
        public float CombinedTaxRate;

        [JsonProperty("state_taxable_amount")]
        public float StateTaxableAmount;

        [JsonProperty("state_tax_rate")]
        public float StateTaxRate;

        [JsonProperty("state_tax_collectable")]
        public float StateTaxCollectable;

        [JsonProperty("county_taxable_amount")]
        public float CountyTaxableAmount;

        [JsonProperty("county_tax_rate")]
        public float CountyTaxRate;

        [JsonProperty("county_tax_collectable")]
        public float CountyTaxCollectable;

        [JsonProperty("city_taxable_amount")]
        public float CityTaxableAmount;

        [JsonProperty("city_tax_rate")]
        public float CityTaxRate;

        [JsonProperty("city_tax_collectable")]
        public float CityTaxCollectable;

        [JsonProperty("special_district_taxable_amount")]
        public float SpecialDistrictTaxableAmount;

        [JsonProperty("special_tax_rate")]
        public float SpecialTaxRate;

        [JsonProperty("special_district_tax_collectable")]
        public float SpecialDistrictTaxCollectable;

        [JsonProperty("line_items")]
        public List<LineItem> LineItems;
    }

    public class Tax
    {
        [JsonProperty("order_total_amount")]
        public float OrderTotalAmount;

        [JsonProperty("shipping")]
        public float Shipping;

        [JsonProperty("taxable_amount")]
        public float TaxableAmount;

        [JsonProperty("amount_to_collect")]
        public float AmountToCollect;

        [JsonProperty("rate")]
        public float Rate;

        [JsonProperty("has_nexus")]
        public bool HasNexus;

        [JsonProperty("freight_taxable")]
        public bool FreightTaxable;

        [JsonProperty("tax_source")]
        public string TaxSource;

        [JsonProperty("jurisdictions")]
        public Jurisdictions Jurisdictions;

        [JsonProperty("breakdown")]
        public Breakdown Breakdown;
    }
}

