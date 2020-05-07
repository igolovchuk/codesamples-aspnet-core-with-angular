using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class CoreAngularDemoionRepository:BaseRepository<CoreAngularDemoion>, ICoreAngularDemoionRepository
    {
        public CoreAngularDemoionRepository(CoreAngularDemoDBContext context)
               : base(context)
        {
        }

        public override Expression<Func<CoreAngularDemoion, bool>> MakeFilteringExpression(string keyword)
        {
            return entity =>
                   entity.FromState.TransName != null && entity.FromState.TransName != string.Empty &&
                       EF.Functions.Like(entity.FromState.TransName, '%' + keyword + '%')
                || entity.ToState.TransName != null && entity.ToState.TransName != string.Empty &&
                       EF.Functions.Like(entity.ToState.TransName, '%' + keyword + '%')
                || entity.ActionType.Name != null && entity.ActionType.Name != string.Empty &&
                       EF.Functions.Like(entity.ActionType.Name, '%' + keyword + '%');
        }

        protected override IQueryable<CoreAngularDemoion> ComplexEntities => Entities.
           Include(u => u.ActionType).
           Include(u => u.FromState).
           Include(u => u.ToState).
           Include(t => t.Create).
           Include(w => w.Mod).OrderByDescending(u => u.UpdatedDate).ThenByDescending(x => x.CreatedDate);
    }
}
