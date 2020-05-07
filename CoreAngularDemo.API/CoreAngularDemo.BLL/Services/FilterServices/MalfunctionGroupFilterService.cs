using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class MalfunctionGroupFilterService : BaseFilterService<MalfunctionGroup, MalfunctionGroupDTO>
    {
        public MalfunctionGroupFilterService(IQueryRepository<MalfunctionGroup> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
