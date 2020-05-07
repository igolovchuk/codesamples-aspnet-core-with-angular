using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class PartsInRepository : BaseRepository<PartIn>, IPartsInRepository
    {
        public PartsInRepository(CoreAngularDemoDBContext context) : base(context)
        {
        }

        protected override IQueryable<PartIn> ComplexEntities
        {
            get
            {
                return Entities
                    .Include(e => e.Unit)
                    .Include(e => e.Currency)
                    .Include(e => e.Part)
                        .ThenInclude(e => e.Manufacturer)
                    .OrderByDescending(u => u.UpdatedDate)
                    .ThenByDescending(x => x.CreatedDate);
            }
        }

        public override Expression<Func<PartIn, bool>> MakeFilteringExpression(string keyword)
        {
            Expression<Func<PartIn, bool>> expression =
                entity => entity.Batch != null && entity.Batch != string.Empty &&
                           EF.Functions.Like(entity.Batch, '%' + keyword + '%')
                    || entity.Currency.FullName != null && entity.Currency.FullName != string.Empty &&
                           EF.Functions.Like(entity.Currency.FullName, '%' + keyword + '%')
                    || entity.Currency.ShortName != null && entity.Currency.ShortName != string.Empty &&
                           EF.Functions.Like(entity.Currency.ShortName, '%' + keyword + '%');

            if (int.TryParse(keyword, out int integer))
            {
                Expression<Func<PartIn, bool>> integerExpression = 
                    entity => (int)entity.Price == integer
                        || entity.Amount == integer
                        || entity.ArrivalDate.Year == integer
                        || entity.ArrivalDate.Month == integer
                        || entity.ArrivalDate.Day == integer;

                expression = PredicateBuilder.New<PartIn>().And(expression).And(integerExpression);
            }

            return expression;
        }
    }
}
