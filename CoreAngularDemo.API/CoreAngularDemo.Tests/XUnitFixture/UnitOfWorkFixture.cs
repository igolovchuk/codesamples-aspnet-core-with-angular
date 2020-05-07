using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Test;
using Microsoft.EntityFrameworkCore;
using Moq;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.DAL.UnitOfWork;

namespace CoreAngularDemo.Tests
{
    /// <summary>
    /// A fixture containing all dependencies for services.
    /// </summary>
    public class UnitOfWorkFixture : IDisposable
    {
        private class UserStore : UserStore<User, Role, CoreAngularDemoDBContext, string, IdentityUserClaim<string>,
            UserRole, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>
        {
            public UserStore(CoreAngularDemoDBContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }
        }

        private class RoleStore : RoleStore<Role, CoreAngularDemoDBContext, string, UserRole, IdentityRoleClaim<string>>
        {
            public RoleStore(CoreAngularDemoDBContext context, IdentityErrorDescriber describer = null) : base(context, describer)
            {
            }
        }

        /// <summary>
        /// Creates a <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <returns>A new object each time.</returns>
        public IUnitOfWork CreateMockUnitOfWork()
        {
            CoreAngularDemoDBContext CoreAngularDemoDBContext = new CoreAngularDemoDBContext(
                new DbContextOptionsBuilder<CoreAngularDemoDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging()
                    .Options
            );

            IUserStore<User> userStore = new UserStore(CoreAngularDemoDBContext);
            IRoleStore<Role> roleStore = new RoleStore(CoreAngularDemoDBContext);

            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(ActionTypeRepository))).Returns(new ActionTypeRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(CountryRepository))).Returns(new CountryRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(CurrencyRepository))).Returns(new CurrencyRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(BillRepository))).Returns(new BillRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(DocumentRepository))).Returns(new DocumentRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(IssueRepository))).Returns(new IssueRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(IssueLogRepository))).Returns(new IssueLogRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(MalfunctionRepository))).Returns(new MalfunctionRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(MalfunctionGroupRepository))).Returns(new MalfunctionGroupRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(MalfunctionSubgroupRepository))).Returns(new MalfunctionSubgroupRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(StateRepository))).Returns(new StateRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(SupplierRepository))).Returns(new SupplierRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(VehicleRepository))).Returns(new VehicleRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(VehicleTypeRepository))).Returns(new VehicleTypeRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(EmployeeRepository))).Returns(new EmployeeRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(PartRepository))).Returns(new PartRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(PostRepository))).Returns(new PostRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(CoreAngularDemoionRepository))).Returns(new CoreAngularDemoionRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(PartsInRepository))).Returns(new UserRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(PartsInRepository))).Returns(new PartsInRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(RoleManager<Role>))).Returns(MockHelpers.TestRoleManager(roleStore));
            serviceProvider.Setup(x => x.GetService(typeof(UserManager<User>))).Returns(MockHelpers.TestUserManager(userStore));
            serviceProvider.Setup(x => x.GetService(typeof(UnitRepository))).Returns(new UnitRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(WorkTypeRepository))).Returns(new WorkTypeRepository(CoreAngularDemoDBContext));
            serviceProvider.Setup(x => x.GetService(typeof(ManufacturerRepository))).Returns(new ManufacturerRepository(CoreAngularDemoDBContext));

            var unitOfWork = new UnitOfWork(CoreAngularDemoDBContext, serviceProvider.Object);

            unitOfWork.RoleManager.CreateAsync(new Role { Name = "ADMIN", TransName = "Адмін" }).Wait();
            unitOfWork.RoleManager.CreateAsync(new Role { Name = "WORKER", TransName = "Працівник" }).Wait();
            unitOfWork.RoleManager.CreateAsync(new Role { Name = "ENGINEER", TransName = "Інженер" }).Wait();
            unitOfWork.RoleManager.CreateAsync(new Role { Name = "REGISTER", TransName = "Реєстратор" }).Wait();
            unitOfWork.RoleManager.CreateAsync(new Role { Name = "ANALYST", TransName = "Аналітик" }).Wait();

            return unitOfWork;
        }

        public void Dispose()
        {
        }
    }
}