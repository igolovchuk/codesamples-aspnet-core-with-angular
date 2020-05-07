using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreAngularDemo.DAL.Exceptions;
using CoreAngularDemo.DAL.FileStorage;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories;
using CoreAngularDemo.DAL.Repositories.ImplementedRepositories;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;
using CoreAngularDemo.DAL.UnitOfWork;

namespace CoreAngularDemo.DAL
{
    public static class ConfigureDALExtension
    {
        public static void ConfigureDAL(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostingEnvironment environment)
        {
            services.ConfigureRepositories();
            services.ConfigureQueryRepositories();
            services.ConfigureDbContext(configuration);
            services.ConfigureIdentity();
            services.ConfigureFileStorage(configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

        private static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IActionTypeRepository, ActionTypeRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueLogRepository, IssueLogRepository>();
            services.AddScoped<IMalfunctionRepository, MalfunctionRepository>();
            services.AddScoped<IMalfunctionGroupRepository, MalfunctionGroupRepository>();
            services.AddScoped<IMalfunctionSubgroupRepository, MalfunctionSubgroupRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPartRepository, PartRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICoreAngularDemoionRepository, CoreAngularDemoionRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPartsInRepository, PartsInRepository>();
            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
        }

        private static void ConfigureQueryRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQueryRepository<ActionType>, ActionTypeRepository>();
            services.AddScoped<IQueryRepository<Bill>, BillRepository>();
            services.AddScoped<IQueryRepository<Document>, DocumentRepository>();
            services.AddScoped<IQueryRepository<Issue>, IssueRepository>();
            services.AddScoped<IQueryRepository<IssueLog>, IssueLogRepository>();
            services.AddScoped<IQueryRepository<Malfunction>, MalfunctionRepository>();
            services.AddScoped<IQueryRepository<MalfunctionGroup>, MalfunctionGroupRepository>();
            services.AddScoped<IQueryRepository<MalfunctionSubgroup>, MalfunctionSubgroupRepository>();
            services.AddScoped<IQueryRepository<State>, StateRepository>();
            services.AddScoped<IQueryRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IQueryRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IQueryRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IQueryRepository<Currency>, CurrencyRepository>();
            services.AddScoped<IQueryRepository<Country>, CountryRepository>();
            services.AddScoped<IQueryRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IQueryRepository<Part>, PartRepository>();
            services.AddScoped<IQueryRepository<Post>, PostRepository>();
            services.AddScoped<IQueryRepository<CoreAngularDemoion>, CoreAngularDemoionRepository>();
            services.AddScoped<IQueryRepository<Location>, LocationRepository>();
            services.AddScoped<IQueryRepository<User>, UserQueryRepository>();
            services.AddScoped<IQueryRepository<PartIn>, PartsInRepository>();
            services.AddScoped<IQueryRepository<Unit>, UnitRepository>();
            services.AddScoped<IQueryRepository<Manufacturer>, ManufacturerRepository>();
            services.AddScoped<IQueryRepository<WorkType>, WorkTypeRepository>();
        }

        private static void ConfigureDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            void ConfigureConnection(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CoreAngularDemo.API"));
            }

            services.AddDbContext<CoreAngularDemoDBContext>(ConfigureConnection);
        }

        private static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<CoreAngularDemoDBContext>()
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<UserManager<User>>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }

        private static void ConfigureFileStorage(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var fileStorage = configuration.GetSection("FileStorage");
            switch (fileStorage["Type"].ToLower())
            {
                case "azure":
                    services.AddScoped<IFileStorage, AzureFileStorage>();
                    services.Configure<AzureStorageOptions>((options) =>
                    {
                        var azureOptions = fileStorage.GetSection(nameof(AzureStorageOptions));

                        options.AccountName = azureOptions[nameof(AzureStorageOptions.AccountName)];
                        options.AccountKey = azureOptions[nameof(AzureStorageOptions.AccountKey)];
                        options.ConnectionString = azureOptions[nameof(AzureStorageOptions.ConnectionString)];
                    });
                    break;
                case "local":
                    services.AddScoped<IFileStorage, LocalFileStorage>();

                    services.Configure<LocalStorageOptions>((options) =>
                    {
                        var localOptions = fileStorage.GetSection(nameof(LocalStorageOptions));

                        options.FolderPath = localOptions[nameof(LocalStorageOptions.FolderPath)];
                    });
                    break;
                default:
                    throw new InvalidStorageTypeException($"{fileStorage["Type"]} isn't valid file storage type");
            }
        }
    }
}