using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class PartRepository : BaseRepository<Part>, IPartRepository
    {
        public PartRepository(CoreAngularDemoDBContext context)
               : base(context)
        {
        }
        
        public override Expression<Func<Part, bool>> MakeFilteringExpression(string keyword)
        {
            return part => EF.Functions.Like(part.Name, '%' + keyword + '%');
        }

        protected override IQueryable<Part> ComplexEntities => Entities.
           Include(p => p.Create).
           Include(p => p.Mod).
           Include(p => p.Unit).
           Include(p => p.Manufacturer).
           Include(p => p.SupplierParts).
           ThenInclude(x => x.Supplier).
           OrderByDescending(u => u.UpdatedDate).ThenByDescending(x => x.CreatedDate);
    }
}
