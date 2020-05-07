using System;
using System.Threading.Tasks;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.Tests.Helper;
using Xunit;

namespace CoreAngularDemo.Tests.Repository
{
    public class PartsInRepositoryTests
    {
        [Fact]
        public async Task PartsInRepository_Should_Add_Item()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new PartsInRepository(context);
            

            // Act
            await context.AddAsync(currency);
            await context.AddAsync(unit);
            await context.AddAsync(part);
            await context.AddAsync(part.Manufacturer);
            await context.SaveChangesAsync();
            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();
            var actualEntity = await repository.GetByIdAsync(expectedEntity.Id);

            // Assert
            Assert.Equal(expectedEntity, actualEntity);
        }

        [Fact]
        public async Task PartsInRepository_Should_Update_Item()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new PartsInRepository(context);
            var currency = new Currency()
            
            // Act
            await context.AddAsync(manufacturer);
            await context.AddRangeAsync(new Currency[] { currency, newCurrency });
            await context.AddRangeAsync(new Unit[] { unit, newUnit });
            await context.AddRangeAsync(new Part[] { part, newPart });
            await context.SaveChangesAsync();

            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();

            expectedEntity.Price = 10;
            expectedEntity.UnitId = newUnit.Id;
            expectedEntity.CurrencyId = newCurrency.Id;
            expectedEntity.PartId = newPart.Id;

            repository.Update(expectedEntity);

            await context.SaveChangesAsync();

            var actualEntity = await repository.GetByIdAsync(expectedEntity.Id);

            // Assert
            Assert.Equal(expectedEntity, actualEntity);
        }
    }
}
