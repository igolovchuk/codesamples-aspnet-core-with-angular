using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class ManufacturerFilterService : BaseFilterService<Manufacturer ,ManufacturerDTO>
    {
        public ManufacturerFilterService(IQueryRepository<Manufacturer> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}