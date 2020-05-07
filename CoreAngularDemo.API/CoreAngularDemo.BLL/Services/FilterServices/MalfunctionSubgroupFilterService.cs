using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class MalfunctionSubgroupFilterService : BaseFilterService<MalfunctionSubgroup, MalfunctionSubgroupDTO>
    {
        public MalfunctionSubgroupFilterService(IQueryRepository<MalfunctionSubgroup> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
