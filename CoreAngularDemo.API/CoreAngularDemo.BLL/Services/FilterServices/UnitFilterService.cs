using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class UnitFilterService : BaseFilterService<Unit, UnitDTO>

    {
        public UnitFilterService(IQueryRepository<Unit> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}