using System;
using System.Collections.Generic;
using System.Linq;
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
            destination.ToZip = source.ToZip;
            destination.ToCity = source.ToCity;
            destination.ToStreet = source.ToStreet;
            destination.FromCity = source.FromCity;
            destination.FromCountry = source.FromCountry;
            destination.FromState = source.FromState;
            destination.FromStreet = source.FromStreet;
            destination.FromZip = source.FromZip;
            destination.Shipping = source.Shipping;
            destination.Amount = source.Amount;

            var items = source.LineItems.Select(x => new Models.Requests.LineItem()
            {
                Id = x.Id,
                Discount = x.Discount,
                ProductTaxCode = x.ProductTaxCode,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice
            }).ToList();

            destination.LineItems = items;

            return destination;
        }
    }
}
