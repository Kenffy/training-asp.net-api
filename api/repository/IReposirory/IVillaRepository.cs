using api.Models;
using System.Linq.Expressions;

namespace api.repository.IReposirory
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
