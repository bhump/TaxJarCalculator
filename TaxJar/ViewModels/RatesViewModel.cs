using System;
using System.Windows.Input;
using TaxJar.Interfaces;
using Xamarin.Forms;

namespace TaxJar.ViewModels
{
    public class RatesViewModel : BaseViewModel
    {
        public ICommand GetTaxRateCommand { get; private set; }

        private readonly ITaxService taxService;

        private string state;
        public string State
        {
            get => state;
            set => SetProperty(ref state, value);
        }

        private string stateRate;
        public string StateRate
        {
            get => stateRate;
            set => SetProperty(ref stateRate, value);
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

        private void GetTaxRate()
        {
            
        }
    }
}
