﻿using AutoMapper;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;

namespace CoreAngularDemo.BLL.Services.FilterServices
{
    public class DocumentFilterService : BaseFilterService<Document, DocumentDTO>
    {
        public DocumentFilterService(IQueryRepository<Document> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
