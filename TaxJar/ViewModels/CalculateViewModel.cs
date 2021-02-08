using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxJar.Interfaces;
using TaxJar.Models;
using Xamarin.Forms;

namespace TaxJar.ViewModels
{
    public class CalculateViewModel : BaseViewModel
    {
        private readonly ITaxService taxService;

        public ICommand CalculateTaxesCommand { get; private set; }

        private string toStreetEntry;
        public string ToStreetEntry
        {
            get => toStreetEntry;
            set => SetProperty(ref toStreetEntry, value);
        }

        private string toCityEntry;
        public string ToCityEntry
        {
            get => toCityEntry;
            set => SetProperty(ref toCityEntry, value);
        }

        private string toStateEntry;
        public string ToStateEntry
        {
            get => toStateEntry;
            set => SetProperty(ref toStateEntry, value);
        }

        private string toZipEntry;
        public string ToZipEntry
        {
            get => toZipEntry;
            set => SetProperty(ref toZipEntry, value);
        }

        private string toCountryEntry;
        public string ToCountryEntry
        {
            get => toCountryEntry;
            set => SetProperty(ref toCountryEntry, value);
        }

        private int amountEntry;
        public int AmountEntry
        {
            get => amountEntry;
            set => SetProperty(ref amountEntry, value);
        }

        private int shippingEntry;
        public int ShippingEntry
        {
            get => shippingEntry;
            set => SetProperty(ref shippingEntry, value);
        }

        private string state;
        public string State
        {
            get => state;
            set => SetProperty(ref state, value);
        }

        private string city;
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        private string stateRate;
        public string StateRate
        {
            get => stateRate;
            set => SetProperty(ref stateRate, value);
        }

        private string county;
        public string County
        {
            get => county;
            set => SetProperty(ref county, value);
        }

        private string countyRate;
        public string CountyRate
        {
            get => countyRate;
            set => SetProperty(ref countyRate, value);
        }

        private string cityRate;
        public string CityRate
        {
            get => cityRate;
            set => SetProperty(ref cityRate, value);
        }

        private string combinedDistrictRate;
        public string CombindedDistrictRate
        {
            get => combinedDistrictRate;
            set => SetProperty(ref combinedDistrictRate, value);
        }

        private string combinedRate;
        public string CombindedRate
        {
            get => combinedRate;
            set => SetProperty(ref combinedRate, value);
        }

        private bool freightTaxable;
        public bool FreightTaxable
        {
            get => freightTaxable;
            set => SetProperty(ref freightTaxable, value);
        }

        private string specialRate;
        public string SpecialRate
        {
            get => specialRate;
            set => SetProperty(ref specialRate, value);
        }

        //TODO: Setup product service to get list of products
        public CalculateViewModel(ITaxService taxService)
        {
            this.taxService = taxService;

            CalculateTaxesCommand = new Command(async () => await CalculateTaxes());
        }

        private async Task CalculateTaxes()
        {
            try
            {
                //TODO: Add validation and custom controls to highlight required fields

                IsBusy = true;
                IsNotBusy = false;

                //TODO: A couple ways to get the clientId. If this app is to be used by an "agent", the agent can select the client in the dropdown and pass the clientId.
                //if used by the client directly, recommended to set the clientId based on the auth token passed
                //NOTE: Setting clientId and productId
                var getCalculation = new GetCalculationModel
                {
                    Amount = AmountEntry,
                    ClientId = "1",
                    ProductId = "1",
                    Shipping = ShippingEntry,
                    ToCity = ToCityEntry,
                    ToCountry = ToCountryEntry,
                    ToState = ToStateEntry,
                    ToStreet = ToStreetEntry,
                    ToZip = ToZipEntry
                };

                var response = await taxService.Calculate(getCalculation);

                State = response.Tax.Jurisdictions.State;
                CityRate = response.Tax.Breakdown.CityTaxRate.ToString();
                City = response.Tax.Jurisdictions.City;
                CombindedRate = response.Tax.Breakdown.CombinedTaxRate.ToString();
                County = response.Tax.Jurisdictions.County;
                CountyRate = response.Tax.Breakdown.CountyTaxRate.ToString();
                SpecialRate = response.Tax.Breakdown.SpecialTaxRate.ToString();
                StateRate = response.Tax.Breakdown.StateTaxRate.ToString();
                FreightTaxable = response.Tax.FreightTaxable;

                IsBusy = false;
                IsNotBusy = true;
            }
            catch(Exception ex)
            {
                //TODO: notify the user something went wrong
                Console.Write(ex);

                IsBusy = false;
                IsNotBusy = true;
            }
        }
    }
}
