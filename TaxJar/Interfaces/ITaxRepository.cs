using System.Threading.Tasks;

namespace TaxJar.Interfaces
{
    public interface ITaxRepository : IBaseRepository
    {
        Task<Tout> Get<Tin, Tout>(Tin request);
    }
}