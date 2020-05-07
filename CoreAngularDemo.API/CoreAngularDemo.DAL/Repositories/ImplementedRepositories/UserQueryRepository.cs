using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class UserQueryRepository : IQueryRepository<User>
    {
        private readonly CoreAngularDemoDBContext _CoreAngularDemoDBContext;
        private IQueryable<User> _users;

        public UserQueryRepository(CoreAngularDemoDBContext CoreAngularDemoDBContext)
        {
            _CoreAngularDemoDBContext = CoreAngularDemoDBContext;
            _users = _CoreAngularDemoDBContext.Set<User>()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .AsQueryable();
        }

        public IQueryable<User> GetQueryable()
        {
            return _users;
        }

        public Task<IQueryable<User>> SearchAsync(IEnumerable<string> strs)
        {
            var predicate = PredicateBuilder.New<User>();
            var secondPredicate = PredicateBuilder.New<UserRole>();

            foreach (string keyword in strs)
            {
                string temp = keyword;

                predicate = predicate.And(entity =>
                       entity.FirstName != null && entity.FirstName != string.Empty &&
                           EF.Functions.Like(entity.FirstName, '%' + temp + '%')
                    || entity.MiddleName != null && entity.MiddleName != string.Empty &&
                           EF.Functions.Like(entity.MiddleName, '%' + temp + '%')
                    || entity.LastName != null && entity.LastName != string.Empty &&
                           EF.Functions.Like(entity.LastName, '%' + temp + '%')
                    || entity.NormalizedUserName != null && entity.NormalizedUserName != string.Empty &&
                           EF.Functions.Like(entity.NormalizedUserName, '%' + temp + '%')
                    || entity.NormalizedEmail != null && entity.NormalizedEmail != string.Empty &&
                           EF.Functions.Like(entity.NormalizedEmail, '%' + temp + '%')
                    || entity.PhoneNumber != null && entity.PhoneNumber != string.Empty &&
                           EF.Functions.Like(entity.PhoneNumber, '%' + temp + '%'));
            }
            return Task.FromResult(
                GetQueryable()
                .AsExpandable()
                .Where(predicate)
            );
        }

    }
}
