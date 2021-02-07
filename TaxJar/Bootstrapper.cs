using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using TaxJar.Interfaces;
using TaxJar.ViewModels;
using TaxJar.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace TaxJar
{
    public class Bootstrapper
    {
        private static IViewFactory viewFactory;

        public Bootstrapper()
        {
        }

        public void Initialize(AppModule module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            var container = builder.Build();

            var autofacServiceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => autofacServiceLocator);

            viewFactory = container.Resolve<IViewFactory>();

            RegisterViews();
            SetMainPage();
        }

        private void RegisterViews()
        {
            viewFactory.Register<MainViewModel, MainPage>();
            viewFactory.Register<RatesViewModel, RatesPage>();
            viewFactory.Register<CalculateViewModel, CalculatePage>();
        }

        private void SetMainPage()
        {
            var mainPage = viewFactory.Resolve<MainViewModel>() as Xamarin.Forms.TabbedPage;

            if(mainPage.Children.Count > 0)
            {
                Xamarin.Forms.Application.Current.MainPage = mainPage;
            }

            var ratesNavigationPage = new Xamarin.Forms.NavigationPage(viewFactory.Resolve<RatesViewModel>())
            {
                Title = "Rates",
                IconImageSource = ImageSource.FromFile("tab_feed.png")
            };

            ratesNavigationPage.On<iOS>().SetHideNavigationBarSeparator(true);
            ratesNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            var calculateNavigationPage = new Xamarin.Forms.NavigationPage(viewFactory.Resolve<CalculateViewModel>())
            {
                Title = "Calculator",
                IconImageSource = ImageSource.FromFile("tab_about.png")
            };

            calculateNavigationPage.On<iOS>().SetHideNavigationBarSeparator(true);
            calculateNavigationPage.On<iOS>().SetPrefersLargeTitles(true);

            mainPage.Children.Add(ratesNavigationPage);
            mainPage.Children.Add(calculateNavigationPage);

            Xamarin.Forms.Application.Current.MainPage = mainPage;
        }
    }
}
