using System;
using System.Threading.Tasks;
using TaxJar.Api.Models;

namespace TaxJar.Api.Interfaces
{
    public interface ITaxRepository : IBaseInterface
    {
        Task<Tout> Get<Tin, Tout>(Tin request);
    }
}
