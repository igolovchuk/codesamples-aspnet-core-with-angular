using System.Collections.Generic;
using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services
{    
    public interface IFilterService<TEntityDTO> where TEntityDTO : class, new()
    {
        Task<ulong> TotalRecordsAmountAsync();
        Task<IEnumerable<TEntityDTO>> GetQueriedAsync(DataTableRequestDTO dataFilter);
    }
}
