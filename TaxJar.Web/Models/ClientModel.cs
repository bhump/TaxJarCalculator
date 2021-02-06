using System;
namespace TaxJar.Api.Models
{
    public class ClientModel
    {
        public string Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string Street { get; set; }

        public string Name { get; set; }
    }
}
