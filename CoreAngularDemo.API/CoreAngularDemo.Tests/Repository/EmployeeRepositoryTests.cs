using System.Linq;
using System.Threading.Tasks;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.Tests.Helper;
using Xunit;

namespace CoreAngularDemo.Tests.Repository
{
    public class EmployeeRepositoryTests
    {
        [Fact]
        public async Task Employee_Repository_Should_Add_Employee()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new EmployeeRepository(context);
            var expectedEntity = new Employee()
            {
                Post = new Post() { Name = "Big Boss", Id = 5 },
                FirstName = "test",
                LastName = "Maksymiv",
                ShortName = "lv420",
                BoardNumber = 228,
                Id = 20
            };
            // Act
            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();
            var actualEntity = await repository.GetByIdAsync(expectedEntity.Id);
            // Assert
            Assert.Equal(expectedEntity, actualEntity);
        }

        [Fact]
        public async Task Employee_Repository_Should_Get_All()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new EmployeeRepository(context);
            var expectedEntity = new Employee()
            {
                Post = new Post() { Name = "Big Boss", Id = 5 },
                FirstName = "test",
                LastName = "Maksymiv",
                ShortName = "lv420",
                BoardNumber = 228,
                Id = 20
            };
            // Act
            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();
            var entities = await repository.GetAllAsync();
            // Assert
            Assert.Single(entities.ToList());
        }
    }
}
