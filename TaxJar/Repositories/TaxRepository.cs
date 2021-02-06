using System;
using System.Threading.Tasks;
using TaxJar.Interfaces;

namespace TaxJar.Repositories
{
    public class TaxRepository : ITaxRepository
    {
        public TaxRepository()
        {
        }

        public Task<T> Delete<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Tout> Patch<Tin, Tout>(Tin request)
        {
            throw new NotImplementedException();
        }

        public Task<Tout> Post<Tin, Tout>(Tin request)
        {
            throw new NotImplementedException();
        }

        public Task<Tout> Put<Tin, Tout>(Tin request)
        {
            throw new NotImplementedException();
        }
    }
}
