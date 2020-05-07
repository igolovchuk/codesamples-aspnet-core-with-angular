using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class MalfunctionFilterService : BaseFilterService<Malfunction, MalfunctionDTO>
    {
        public MalfunctionFilterService(IQueryRepository<Malfunction> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
