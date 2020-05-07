using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularDemo.DAL.Repositories
{
    public interface IQueryRepository<TEntity>
    {
        IQueryable<TEntity> GetQueryable();
        Task<IQueryable<TEntity>> SearchAsync(IEnumerable<string> strs);
    }
}
