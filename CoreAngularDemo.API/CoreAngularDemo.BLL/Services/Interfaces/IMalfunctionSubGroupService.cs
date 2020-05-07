using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services.Interfaces
{
    /// <summary>
    /// Malfunction Subgroup model CRUD
    /// </summary>
    public interface IMalfunctionSubgroupService : ICrudService<MalfunctionSubgroupDTO>
    {
        Task<IEnumerable<MalfunctionSubgroupDTO>> GetByGroupNameAsync(string groupName);
    }
}
