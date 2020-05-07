using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class CoreAngularDemoionFilterService : BaseFilterService<CoreAngularDemoion, CoreAngularDemoionDTO>
    {
        public CoreAngularDemoionFilterService(IQueryRepository<CoreAngularDemoion> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
