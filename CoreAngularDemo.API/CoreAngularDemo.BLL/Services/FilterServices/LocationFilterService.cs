using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class LocationFilterService : BaseFilterService<Location, LocationDTO>
    {
        public LocationFilterService(IQueryRepository<Location> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
