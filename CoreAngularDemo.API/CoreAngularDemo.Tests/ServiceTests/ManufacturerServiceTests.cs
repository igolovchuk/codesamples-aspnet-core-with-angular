using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using CoreAngularDemo.BLL.DTOs;
using CoreAngularDemo.BLL.Services.ImplementedServices;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.DAL.UnitOfWork;
using CoreAngularDemo.Tests.Helper;
using Xunit;

namespace CoreAngularDemo.Tests.ServiceTests
{
    public class ManufacturerServiceTests : IClassFixture<MapperFixture>
    {
        private readonly IMapper _mapper;

        private Mock<IUnitOfWork> _unitOfWork;

        public ManufacturerServiceTests(MapperFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task ManufacturerService_Should_Get_Null_When_Manufacturer_Not_Exist()
        {
            // Arrange
            SetUpUnitOfWork();
            var service = new ManufacturerService(_unitOfWork.Object, _mapper);

            // Act
            var entity = await service.GetAsync((new Random()).Next());

            // Assert
            Assert.Null(entity);
        }

        [Fact]
        public async Task ManufacturerService_Should_Create_Manufacturer_Async()
        {
            // Arrange
            SetUpUnitOfWork();
            var service = new ManufacturerService(_unitOfWork.Object, _mapper);
            var expectedEntity = new ManufacturerDTO()
            {
                Name = "TestName",
            };

            // Act
            var actualEntity = await service.CreateAsync(expectedEntity);
            await _unitOfWork.Object.SaveAsync();

            // Assert
            Assert.NotNull(actualEntity);
            Assert.Equal(expectedEntity.Name, actualEntity.Name);
        }

        [Fact]
        public async Task ManufacturerService_Should_Update_Manufacturer()
        {
            // Arrange
            SetUpUnitOfWork();
            var service = new ManufacturerService(_unitOfWork.Object, _mapper);
            var entity = new ManufacturerDTO()
            {
                Name = "TestName",
            };

            var newEntity = new ManufacturerDTO()
            {
                Name = "NewTestName",
            };

            await service.CreateAsync(entity);
            await _unitOfWork.Object.SaveAsync();

            // Act
            entity.Name = newEntity.Name;
            await service.UpdateAsync(entity);
            await _unitOfWork.Object.SaveAsync();

            // Assert
            Assert.NotNull(entity);
            Assert.Equal(newEntity.Name, entity.Name);
        }

        [Fact]
        public async Task ManufacturerService_Should_Delete_Manufacturer_Async()
        {
            // Arrange
            SetUpUnitOfWork();
            var service = new ManufacturerService(_unitOfWork.Object, _mapper);
            var entity = new ManufacturerDTO()
            {
                Name = "TestName",
            };

            entity = await service.CreateAsync(entity);
            await _unitOfWork.Object.SaveAsync();

            // Act
            await service.DeleteAsync(entity.Id);
            await _unitOfWork.Object.SaveAsync();

            // Assert
            Assert.Null(await service.GetAsync(entity.Id));
        }

        private void SetUpUnitOfWork()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            SetUpManufacturerRepository(TestSetUpHelper.CreateDbContext());
        }

        private void SetUpManufacturerRepository(CoreAngularDemoDBContext context)
        {
            var manufacturerRepository = new ManufacturerRepository(context);

            _unitOfWork.Setup(u => u.SaveAsync()).Returns(() => context.SaveChangesAsync());
            _unitOfWork.Setup(u => u.ManufacturerRepository).Returns(() => manufacturerRepository);
        }
    }
}