using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(CoreAngularDemoDBContext context) : base(context)
        {
        }

        public override Expression<Func<Unit, bool>> MakeFilteringExpression(string keyword)
        {
            return entity =>
                   EF.Functions.Like(entity.Name, '%' + keyword + '%') ||
                   EF.Functions.Like(entity.ShortName, "%" + keyword + "%");
        }

        protected override IQueryable<Unit> ComplexEntities
        {
            get
            {
                return Entities.Include(u => u.Create)
                    .Include(u => u.Mod)
                    .OrderByDescending(u => u.UpdatedDate)
                    .ThenByDescending(u => u.CreatedDate);
            }
        }
    }
}