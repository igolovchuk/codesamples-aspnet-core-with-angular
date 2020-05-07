﻿using System.Linq;
using System.Threading.Tasks;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.Tests.Helper;
using Xunit;

namespace CoreAngularDemo.Tests.Repository
{
    public class UnitRepositoryTests
    {
        [Fact]
        public async Task Unit_Repository_Should_Add_Unit()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new UnitRepository(context);
            var expectedEntity = new Unit()
            {
                Id = 4,
                Name = "TestName",
                ShortName = "TestShortName",
            };

            // Act
            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();
            var actualEntity = await repository.GetByIdAsync(expectedEntity.Id);

            // Assert
            Assert.Equal(expectedEntity, actualEntity);
        }

        [Fact]
        public async Task Unit_Repository_Should_Get_All_Async()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new UnitRepository(context);
            var expectedEntity = new Unit()
            {
                Id = 4,
                Name = "TestName",
                ShortName = "TestShortName",
            };

            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();

            // Act
            var entities = await repository.GetAllAsync();

            // Assert
            Assert.Single(entities.ToList());
        }

        [Fact]
        public async Task Unit_Repository_Should_Remove_Unit_Async()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new UnitRepository(context);
            var expectedEntity = new Unit()
            {
                Id = 4,
                Name = "TestName",
                ShortName = "TestShortName",
            };

            await repository.AddAsync(expectedEntity);
            await context.SaveChangesAsync();

            // Act
            await repository.RemoveAsync(expectedEntity.Id);
            await context.SaveChangesAsync();
            var actualEntity = await repository.GetByIdAsync(expectedEntity.Id);

            // Assert
            Assert.Null(actualEntity);
        }

        [Fact]
        public async Task Unit_Repository_Should_Update_Unit()
        {
            // Arrange
            var context = TestSetUpHelper.CreateDbContext();
            var repository = new UnitRepository(context);
            var oldUnit = new Unit()
            {
                Id = 4,
                Name = "TestName",
                ShortName = "TestShortName",
            };

            var newUnit = new Unit()
            {
                Id = 4,
                Name = "NewTestName",
                ShortName = "NewTestShortName",
            };

            await repository.AddAsync(oldUnit);
            await context.SaveChangesAsync();

            // Act
            oldUnit.Name = newUnit.Name;
            oldUnit.ShortName = newUnit.ShortName;
            repository.Update(oldUnit);
            await context.SaveChangesAsync();

            // Assert
            Assert.Equal(newUnit.Name, oldUnit.Name);
            Assert.Equal(newUnit.ShortName, oldUnit.ShortName);
        }
    }
}