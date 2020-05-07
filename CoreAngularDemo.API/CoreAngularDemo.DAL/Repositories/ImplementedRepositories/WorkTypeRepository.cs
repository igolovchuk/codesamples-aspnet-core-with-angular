using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class WorkTypeRepository :BaseRepository<WorkType>,IWorkTypeRepository
    {
        public WorkTypeRepository(CoreAngularDemoDBContext context) : base(context)
        {
        }

        public override Expression<Func<WorkType, bool>> MakeFilteringExpression(string keyword)
        {
            return workType => EF.Functions.Like(workType.Name, '%' + keyword + '%') || 
                           EF.Functions.Like(workType.EstimatedCost.ToString(), '%' + keyword + '%') || 
                           EF.Functions.Like(workType.EstimatedTime.ToString(), '%' + keyword + '%');
        }

        protected override IQueryable<WorkType> ComplexEntities
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
