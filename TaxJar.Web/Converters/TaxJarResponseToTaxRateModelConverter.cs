using System;
using System.Linq;
using AutoMapper;
using TaxJar.Api.Models;

namespace TaxJar.Api.Converters
{
    public class TaxJarResponseToTaxRateModelConverter : ITypeConverter<TaxJarRateResponse, TaxRateModel>
    {
        public TaxJarResponseToTaxRateModelConverter()
        {
        }

        public TaxRateModel Convert(TaxJarRateResponse source, TaxRateModel destination, ResolutionContext context)
        {
            if(destination == null)
            {
                destination = new TaxRateModel();
            }

            destination.City = source.Rate.City;
            destination.CityRate = source.Rate.CityRate;
            destination.CombinedDistrictRate = source.Rate.CombinedDistrictRate;
            destination.CombinedRate = source.Rate.CombinedRate;
            destination.County = source.Rate.County;
            destination.Country = source.Rate.Country;
            destination.CountyRate = source.Rate.CountyRate;
            destination.FreightTaxable = source.Rate.FreightTaxable;
            destination.State = source.Rate.State;
            destination.StateRate = source.Rate.StateRate;
            destination.Zip = source.Rate.Zip;
            destination.StandardRate = source.Rate.StandardRate;
            destination.ReducedRate = source.Rate.ReducedRate;
            destination.SuperReducedRate = source.Rate.SuperReducedRate;
            destination.ParkingRate = source.Rate.ParkingRate;
            destination.DistanceSaleThreshold = source.Rate.DistanceSaleThreshold;
            destination.DateRequested = DateTime.Now.ToUniversalTime();

            return destination;
        }
    }
}
