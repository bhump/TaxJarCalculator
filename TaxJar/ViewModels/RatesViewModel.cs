using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TaxJar.Interfaces;
using TaxJar.Models;
using TaxJar.Models.Requests;
using Xamarin.Forms;

namespace TaxJar.ViewModels
{
    public class RatesViewModel : BaseViewModel
    {
        public ICommand GetTaxRateCommand { get; private set; }

        private readonly ITaxService taxService;

        private string streetEntry;
        public string StreetEntry
        {
            get => streetEntry;
            set => SetProperty(ref streetEntry, value);
        }

        private string cityEntry;
        public string CityEntry
        {
            get => cityEntry;
            set => SetProperty(ref cityEntry, value);
        }

        private string countryEntry;
        public string CountryEntry
        {
            get => countryEntry;
            set => SetProperty(ref countryEntry, value);
        }

        private string zipEntry;
        public string ZipEntry
        {
            get => zipEntry;
            set => SetProperty(ref zipEntry, value);
        }

        private string stateEntry;
        public string StateEntry
        {
            get => stateEntry;
            set => SetProperty(ref stateEntry, value);
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

        private string standardRate;
        public string StandardRate
        {
            get => standardRate;
            set => SetProperty(ref standardRate, value);
        }

        private string reducedRate;
        public string ReducedRate
        {
            get => reducedRate;
            set => SetProperty(ref reducedRate, value);
        }

        private string superReducedRate;
        public string SuperReducedRate
        {
            get => superReducedRate;
            set => SetProperty(ref superReducedRate, value);
        }

        private string parkingRate;
        public string ParkingRate
        {
            get => parkingRate;
            set => SetProperty(ref parkingRate, value);
        }

        private string distanceSaleThreshold;
        public string DistanceSaleThreshold
        {
            get => distanceSaleThreshold;
            set => SetProperty(ref distanceSaleThreshold, value);
        }

        public RatesViewModel(ITaxService taxService)
        {
            this.taxService = taxService;

            GetTaxRateCommand = new Command(() => GetTaxRate());
        }

        private async Task GetTaxRate()
        {
            IsBusy = true;
            IsNotBusy = false;

            var request = new GetTaxRateModel
            {
                Street = streetEntry,
                City = cityEntry,
                State = stateEntry,
                Zip = zipEntry,
                Country = countryEntry
            };

            var response = await taxService.GetRates(request);

            State = response.State;
            CityRate = response.CityRate.ToString();
            City = response.City;
            CombindedDistrictRate = response.CombinedDistrictRate.ToString();
            CombindedRate = response.CombinedRate.ToString();
            County = response.County;
            CountyRate = response.CountyRate.ToString();
            ParkingRate = response.ParkingRate.ToString();
            StandardRate = response.StandardRate.ToString();
            ReducedRate = response.ReducedRate.ToString();
            SuperReducedRate = response.SuperReducedRate.ToString();
            StateRate = response.StateRate.ToString();
            FreightTaxable = response.FreightTaxable;
            DistanceSaleThreshold = response.DistanceSaleThreshold.ToString();

            IsBusy = false;
            IsNotBusy = true;
        }
    }
}
