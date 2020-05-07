using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class UserFilterService : BaseFilterService<User, UserDTO>
    {
        public UserFilterService(IQueryRepository<User> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
