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
        public int TaxableAmount;

        [JsonProperty("tax_collectable")]
        public double TaxCollectable;

        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate;

        [JsonProperty("state_taxable_amount")]
        public int StateTaxableAmount;

        [JsonProperty("state_sales_tax_rate")]
        public double StateSalesTaxRate;

        [JsonProperty("state_amount")]
        public double StateAmount;

        [JsonProperty("county_taxable_amount")]
        public int CountyTaxableAmount;

        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate;

        [JsonProperty("county_amount")]
        public double CountyAmount;

        [JsonProperty("city_taxable_amount")]
        public int CityTaxableAmount;

        [JsonProperty("city_tax_rate")]
        public int CityTaxRate;

        [JsonProperty("city_amount")]
        public int CityAmount;

        [JsonProperty("special_district_taxable_amount")]
        public int SpecialDistrictTaxableAmount;

        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate;

        [JsonProperty("special_district_amount")]
        public double SpecialDistrictAmount;
    }

    public class Breakdown
    {
        [JsonProperty("taxable_amount")]
        public int TaxableAmount;

        [JsonProperty("tax_collectable")]
        public double TaxCollectable;

        [JsonProperty("combined_tax_rate")]
        public double CombinedTaxRate;

        [JsonProperty("state_taxable_amount")]
        public int StateTaxableAmount;

        [JsonProperty("state_tax_rate")]
        public double StateTaxRate;

        [JsonProperty("state_tax_collectable")]
        public double StateTaxCollectable;

        [JsonProperty("county_taxable_amount")]
        public int CountyTaxableAmount;

        [JsonProperty("county_tax_rate")]
        public double CountyTaxRate;

        [JsonProperty("county_tax_collectable")]
        public double CountyTaxCollectable;

        [JsonProperty("city_taxable_amount")]
        public int CityTaxableAmount;

        [JsonProperty("city_tax_rate")]
        public int CityTaxRate;

        [JsonProperty("city_tax_collectable")]
        public int CityTaxCollectable;

        [JsonProperty("special_district_taxable_amount")]
        public int SpecialDistrictTaxableAmount;

        [JsonProperty("special_tax_rate")]
        public double SpecialTaxRate;

        [JsonProperty("special_district_tax_collectable")]
        public double SpecialDistrictTaxCollectable;

        [JsonProperty("line_items")]
        public List<LineItem> LineItems;
    }

    public class Tax
    {
        [JsonProperty("order_total_amount")]
        public double OrderTotalAmount;

        [JsonProperty("shipping")]
        public double Shipping;

        [JsonProperty("taxable_amount")]
        public int TaxableAmount;

        [JsonProperty("amount_to_collect")]
        public double AmountToCollect;

        [JsonProperty("rate")]
        public double Rate;

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

