﻿using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class SupplierFilterService : BaseFilterService<Supplier, SupplierDTO>
    {
        public SupplierFilterService(IQueryRepository<Supplier> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
