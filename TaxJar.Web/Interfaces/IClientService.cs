using System;
using System.Threading.Tasks;
using TaxJar.Api.Models;

namespace TaxJar.Api.Interfaces
{
    public interface IClientService
    {
        ClientModel GetClient(string id);
    }
}
