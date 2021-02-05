﻿using System;
using AutoMapper;
using TaxJar.Api.Converters;
using TaxJar.Api.Models;
using TaxJar.Api.Models.Requests;
using TaxJar.Api.Models.Responses;

namespace TaxJar.Api.AutoMapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TaxJarRateResponse, TaxRateModel>().ConvertUsing<TaxJarResponseToTaxRateModelConverter>();
            CreateMap<TaxRateModel, TaxRateResponse>();
            CreateMap<TaxRateRequest, TaxRateModel>();
            CreateMap(typeof(Source<>), typeof(Destination<>));
        }
    }

    public class Source<T>
    {
        public T Value { get; set; }
    }

    public class Destination<T>
    {
        public T Value { get; set; }
    }
}
