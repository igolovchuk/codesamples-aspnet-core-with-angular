using System;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;

namespace CoreAngularDemo.Tests.Helper
{
    public static class TestSetUpHelper
    {
        public static CoreAngularDemoDBContext CreateDbContext()
        {
            return new CoreAngularDemoDBContext(
                new DbContextOptionsBuilder<CoreAngularDemoDBContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .EnableSensitiveDataLogging()
                    .Options
            );
        }
    }
}