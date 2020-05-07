﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public LocationRepository(CoreAngularDemoDBContext context)
            : base(context)
        {
        }

        public override Expression<Func<Location, bool>> MakeFilteringExpression(string keyword)
        {
            return entity =>
                   entity.Name != null && entity.Name != string.Empty &&
                       EF.Functions.Like(entity.Name, '%' + keyword + '%')
                || entity.Description != null && entity.Description != string.Empty &&
                       EF.Functions.Like(entity.Description, '%' + keyword + '%');
        }

        protected override IQueryable<Location> ComplexEntities => Entities.
            Include(a => a.Create).
            Include(b => b.Mod).OrderByDescending(u => u.UpdatedDate).ThenByDescending(x => x.CreatedDate);
    }
}
