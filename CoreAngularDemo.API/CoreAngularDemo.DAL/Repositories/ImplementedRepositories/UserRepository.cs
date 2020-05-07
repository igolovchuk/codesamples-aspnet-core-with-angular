using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CoreAngularDemoDBContext _dbContext;

        public UserRepository(CoreAngularDemoDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrentUserId
        {
            get => _dbContext.CurrentUserId;
            set => _dbContext.CurrentUserId = value;
        }
    }
}
