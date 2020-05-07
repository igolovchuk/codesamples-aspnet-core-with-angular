using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class StateRepository : BaseRepository<State>, IStateRepository
    {
        public StateRepository(CoreAngularDemoDBContext context)
               : base(context)
        {
        }

        public override Expression<Func<State, bool>> MakeFilteringExpression(string keyword)
        {
            return entity => entity.TransName != null &&
                             entity.TransName != string.Empty &&
                             EF.Functions.Like(entity.TransName, '%' + keyword + '%');
        }
    }
}
