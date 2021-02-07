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

        public CalculateViewModel(ITaxService taxService)
        {
            this.taxService = taxService;

            CalculateTaxesCommand = new Command(async () => await CalculateTaxes());
        }

        private async Task CalculateTaxes()
        {
            IsBusy = true;
            IsNotBusy = false;

            var getCalculation = new GetCalculationModel
            {
                Amount = 15,
                ClientId = "1",
                ProductId = "1",
                Shipping = 2,
                ToCity = "Los Angeles",
                ToCountry = "US",
                ToState = "CA",
                ToStreet = "1335 E 103rd St",
                ToZip = "90002"
            };

            var response = await taxService.Calculate(getCalculation);

            IsBusy = false;
            IsNotBusy = true;
        }
    }
}
