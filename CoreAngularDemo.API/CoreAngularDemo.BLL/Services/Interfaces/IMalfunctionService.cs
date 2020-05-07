using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services.Interfaces
{
    /// <summary>
    /// Malfunction model CRUD
    /// </summary>
    public interface IMalfunctionService : ICrudService<MalfunctionDTO>
    {
        Task<IEnumerable<MalfunctionDTO>> GetBySubgroupNameAsync(string subgroupName);
    }
}
