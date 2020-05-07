using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class StateFilterService : BaseFilterService<State, StateDTO>
    {
        public StateFilterService(IQueryRepository<State> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
