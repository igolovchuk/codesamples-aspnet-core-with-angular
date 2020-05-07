﻿using CoreAngularDemo.BLL.Services.Interfaces;

namespace CoreAngularDemo.BLL.Factories
{
    public interface IServiceFactory
    {
        IAuthenticationService AuthenticationService { get; }

        IActionTypeService ActionTypeService { get; }

        IBillService BillService { get; }

        ICountryService CountryService { get; }

        ICurrencyService CurrencyService { get; }

        IDocumentService DocumentService { get; }

        IEmployeeService EmployeeService { get; }

        IIssueLogService IssueLogService { get; }

        IIssueService IssueService { get; }

        ILocationService LocationService { get; }

        IMalfunctionGroupService MalfunctionGroupService { get; }

        IMalfunctionService MalfunctionService { get; }

        IMalfunctionSubgroupService MalfunctionSubgroupService { get; }

        IPartService PartService { get; }

        IPostService PostService { get; }

        IStateService StateService { get; }

        IStatisticsService StatisticService { get; }

        ISupplierService SupplierService { get; }

        ICoreAngularDemoionService CoreAngularDemoionService { get; }

        IUserService UserService { get; }

        IVehicleService VehicleService { get; }

        IVehicleTypeService VehicleTypeService { get; }

        IPartsInService PartsInService { get; }

        IUnitService UnitService { get; }

        IWorkTypeService WorkTypeService { get; }

        IManufacturerService ManufacturerService { get; }
    }
}