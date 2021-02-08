using System;
using AutoMapper;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TaxJar.Interfaces;
using TaxJar.Models;
using TaxJar.Models.Requests;
using TaxJar.Models.Responses;
using TaxJar.Services;

namespace TestJar.MobileUnitTests.Services
{
    public class TaxServiceTests
    {
        Mock<ITaxRepository> taxRepoMock;
        Mock<IMapper> mapperMock;

        [SetUp]
        public void Setup()
        {
            taxRepoMock = new Mock<ITaxRepository>();
            mapperMock = new Mock<IMapper>();

            mapperMock.Setup(x => x.Map<TaxRateRequest>(It.IsAny<GetTaxRateModel>()))
            .Returns((GetTaxRateModel source) =>
             {
                 return new TaxRateRequest
                 {
                     City = "City",
                     State = "State",
                     Street = "Street",
                     Country = "Country",
                     Zip = "Zip"
                 };
             });

            mapperMock.Setup(x => x.Map<TaxCalculationRequest>(It.IsAny<GetCalculationModel>()))
            .Returns(() =>
            {
                return new TaxCalculationRequest
                {
                    Amount = 1,
                    ClientId = "1",
                    ProductId = "1",
                    Shipping = 2,
                    ToCity = "ToCity",
                    ToCountry = "ToCountry",
                    ToState = "ToState",
                    ToStreet = "ToStree",
                    ToZip = "ToZip"
                };
            });
        }

        [Test]
        public void GetRates_Null_Request_Expected_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            Assert.That(() => taxService.GetRates(null), Throws.Exception);
        }

        [Test]
        public void GetRates_Null_Zip_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetTaxRateModel
            {
                Zip = null
            };

            Assert.That(() => taxService.GetRates(request), Throws.ArgumentNullException);
        }

        [Test]
        public void GetRates_Empty_Zip_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetTaxRateModel
            {
                Zip = string.Empty
            };

            Assert.That(() => taxService.GetRates(request), Throws.ArgumentNullException);
        }

        [Test]
        public void GetRates_Null_Country_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetTaxRateModel
            {
                Zip = "zip",
                Country = null
            };

            Assert.That(() => taxService.GetRates(request), Throws.ArgumentNullException);
        }

        [Test]
        public void GetRates_Empty_Country_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetTaxRateModel
            {
                Zip = "zip",
                Country = null
            };

            Assert.That(() => taxService.GetRates(request), Throws.ArgumentNullException);
        }

        [Test]
        public void GetRates_Valid_Response_Expected()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetTaxRateModel
            {
                Zip = "zip",
                Country = "country"
            };

            taxRepoMock.Setup(x => x.Get<TaxRateRequest, TaxRateResponse>(It.IsAny<TaxRateRequest>())).ReturnsAsync(() =>
            {
                return new TaxRateResponse
                {
                    City = "City"
                };
            });

            var result = taxService.GetRates(request);

            Assert.NotNull(result);
        }

        [Test]
        public void Calculate_Null_Request_Expected_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            Assert.That(() => taxService.Calculate(null), Throws.Exception);
        }

        [Test]
        public void Calculate_Null_ClientId_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_ClientId_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = string.Empty
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Null_ToCountry_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_ToCountry_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = string.Empty
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Null_ToState_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "ToCountry",
                ToState = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_ToState_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "ToCountry",
                ToState = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Null_ToZip_And_ToCountry_Is_US_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "US",
                ToState = "ToState",
                ToZip = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_ToZip_And_ToCountry_Is_US_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "US",
                ToState = "ToState",
                ToZip = string.Empty
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Null_ToZip_And_ToCountry_Is_CA_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "CA",
                ToState = "ToState",
                ToZip = null
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_ToZip_And_ToCountry_Is_CA_Expected_Argument_Null_Exception()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "CA",
                ToState = "ToState",
                ToZip = string.Empty
            };

            Assert.That(() => taxService.Calculate(request), Throws.ArgumentNullException);
        }

        [Test]
        public void Calculate_Empty_Zip_Valid_Response_Expected()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "ToCountry",
                ToState = "ToState",
                ToZip = string.Empty
            };

            taxRepoMock.Setup(x => x.Get<TaxCalculationRequest, TaxCalculationResponse>(It.IsAny<TaxCalculationRequest>())).ReturnsAsync(() =>
            {
                return new TaxCalculationResponse
                {
                    Tax = new Tax
                    {
                        Rate = 30
                    }
                };
            });

            var result = taxService.Calculate(request);

            Assert.NotNull(result);
        }

        [Test]
        public void Calculate_ToCountry_US_Valid_Response_Expected()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "US",
                ToState = "ToState",
                ToZip = "30203"
            };

            taxRepoMock.Setup(x => x.Get<TaxCalculationRequest, TaxCalculationResponse>(It.IsAny<TaxCalculationRequest>())).ReturnsAsync(() =>
            {
                return new TaxCalculationResponse
                {
                    Tax = new Tax
                    {
                        Rate = 30
                    }
                };
            });

            var result = taxService.Calculate(request);

            Assert.NotNull(result);
        }

        [Test]
        public void Calculate_ToCountry_CA_Valid_Response_Expected()
        {
            var taxService = new TaxService(taxRepoMock.Object, mapperMock.Object);

            var request = new GetCalculationModel
            {
                ClientId = "1",
                ToCountry = "US",
                ToState = "ToState",
                ToZip = "30203"
            };

            taxRepoMock.Setup(x => x.Get<TaxCalculationRequest, TaxCalculationResponse>(It.IsAny<TaxCalculationRequest>())).ReturnsAsync(() =>
            {
                return new TaxCalculationResponse
                {
                    Tax = new Tax
                    {
                        Rate = 30
                    }
                };
            });

            var result = taxService.Calculate(request);

            Assert.NotNull(result);
        }
    }
}
