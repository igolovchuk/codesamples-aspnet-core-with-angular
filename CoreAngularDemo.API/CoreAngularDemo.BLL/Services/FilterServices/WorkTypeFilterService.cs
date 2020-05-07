using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class WorkTypeFilterService : BaseFilterService<WorkType, WorkTypeDTO>
    {
        public WorkTypeFilterService(IQueryRepository<WorkType> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
