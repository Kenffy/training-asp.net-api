using api.Models;
using System.Linq.Expressions;

namespace api.repository.IReposirory
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
