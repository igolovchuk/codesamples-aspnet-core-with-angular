using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class VehicleTypeFilterService : BaseFilterService<VehicleType, VehicleTypeDTO>
    {
        public VehicleTypeFilterService(IQueryRepository<VehicleType> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}