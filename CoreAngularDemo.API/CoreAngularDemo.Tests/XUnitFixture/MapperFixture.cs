﻿using System;
using AutoMapper;
using CoreAngularDemo.BLL.Mappings;

namespace CoreAngularDemo.Tests
{
    public class MapperFixture : IDisposable
    {
        /// <summary>
        /// Automapper configuration
        /// </summary>
        public IMapper Mapper { get; } = new MapperConfiguration(c =>
        {
            c.AddProfile(new RoleProfile());
            c.AddProfile(new UserProfile());
            c.AddProfile(new VehicleTypeProfile());
            c.AddProfile(new VehicleProfile());
            c.AddProfile(new RoleProfile());
            c.AddProfile(new MalfunctionGroupProfile());
            c.AddProfile(new MalfunctionSubgroupProfile());
            c.AddProfile(new MalfunctionProfile());
            c.AddProfile(new StateProfile());
            c.AddProfile(new ActionTypeProfile());
            c.AddProfile(new IssueProfile());
            c.AddProfile(new IssueLogProfile());
            c.AddProfile(new DocumentProfile());
            c.AddProfile(new SupplierProfile());
            c.AddProfile(new CurrencyProfile());
            c.AddProfile(new CountryProfile());
            c.AddProfile(new PartProfile());
            c.AddProfile(new PostProfile());
            c.AddProfile(new EmployeeProfile());
            c.AddProfile(new CoreAngularDemoionProfile());
            c.AddProfile(new LocationProfile());
            c.AddProfile(new UnitProfile());
            c.AddProfile(new ManufacturerProfile());
        }).CreateMapper();

        public void Dispose()
        {
        }
    }
}
