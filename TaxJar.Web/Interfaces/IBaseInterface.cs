using System;
using System.Threading.Tasks;

namespace TaxJar.Api.Interfaces
{
    public interface IBaseInterface
    {
        Task<T> Get<T>();

        Task<T> Get<T>(string id);

        Task<Tout> Post<Tin, Tout>(Tin request);

        Task<Tout> Put<Tin, Tout>(Tin request);

        Task<T> Delete<T>(string id);

        Task<Tout> Patch<Tin, Tout>(Tin request);
    }
}
