using System;
using AutoMapper;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;

namespace TaxJar.Api.Converters
{
    public class OrderModelToTaxJarRequestConverter : ITypeConverter<OrderModel,TaxJarCalculateRequest>
    {
        public OrderModelToTaxJarRequestConverter()
        {
        }

        public TaxJarCalculateRequest Convert(OrderModel source, TaxJarCalculateRequest destination, ResolutionContext context)
        {
            if(destination == null)
            {
                destination = new TaxJarCalculateRequest();
            }

            destination.ToState = source.ToState;
            destination.ToCountry = source.ToCountry;
            destination.Shipping = source.Shipping;
            destination.ToZip = source.ToZip;
            source.DateCalculated = DateTime.Now.ToUniversalTime();

            return destination;
        }
    }
}
