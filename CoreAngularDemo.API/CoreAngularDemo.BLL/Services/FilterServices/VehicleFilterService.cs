﻿using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class VehicleFilterService : BaseFilterService<Vehicle, VehicleDTO>
    {
        public VehicleFilterService(IQueryRepository<Vehicle> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}