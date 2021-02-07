using System;
using Autofac;
using AutoMapper;
using TaxJar.Clients;
using TaxJar.Factories;
using TaxJar.Interfaces;
using TaxJar.Models;
using TaxJar.Models.Requests;
using TaxJar.Repositories;
using TaxJar.Services;
using TaxJar.ViewModels;
using TaxJar.Views;
using Xamarin.Forms;

namespace TaxJar
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => Application.Current.MainPage.Navigation).InstancePerLifetimeScope();

            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();

            builder.RegisterType<TaxClient>().As<ITaxClient>().SingleInstance();

            #region ViewModels
            builder.RegisterType<MainViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<RatesViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<CalculateViewModel>().InstancePerLifetimeScope();
            #endregion

            #region Views
            builder.RegisterType<MainPage>();
            builder.RegisterType<RatesPage>();
            builder.RegisterType<CalculatePage>();
            #endregion

            #region Sevices
            builder.RegisterType<TaxService>().As<ITaxService>();
            #endregion

            #region Repositories
            builder.RegisterType<TaxRepository>().As<ITaxRepository>();
            #endregion

            #region AutoMapper
            builder.Register(ConfigureAutoMapper);
            builder.Register(context => context.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            #endregion
        }

        public MapperConfiguration ConfigureAutoMapper(IComponentContext context)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<GetTaxRateModel, TaxRateRequest>();
                config.CreateMap<GetCalculationModel, TaxCalculationRequest>();
            });

            return configuration;
        }
    }
}
