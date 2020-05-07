using System.Threading.Tasks;
using CoreAngularDemo.BLL.DTOs;

namespace CoreAngularDemo.BLL.Services.Interfaces
{
    /// <summary>
    /// Action type model CRUD
    /// </summary>
    public interface IStateService : ICrudService<StateDTO>
    {
        /// <summary>
        /// Gets state by name
        /// </summary>
        /// <param name="name">State's name</param>
        /// <returns>State</returns>
        Task<StateDTO> GetStateByNameAsync(string name);
    }
}
