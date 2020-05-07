using System.Linq;
using Microsoft.EntityFrameworkCore;
using CoreAngularDemo.DAL.Models;
using CoreAngularDemo.DAL.Models.Entities;
using CoreAngularDemo.DAL.Repositories.InterfacesRepositories;
using System;
using System.Linq.Expressions;

namespace CoreAngularDemo.DAL.Repositories.ImplementedRepositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(CoreAngularDemoDBContext context)
            : base(context)
        {
        }

        public override Expression<Func<Vehicle, bool>> MakeFilteringExpression(string keyword)
        {
            return entity =>
                   entity.Brand != null && entity.Brand != string.Empty &&
                       EF.Functions.Like(entity.Brand, '%' + keyword + '%')
                || entity.RegNum != null && entity.RegNum != string.Empty &&
                       EF.Functions.Like(entity.RegNum, '%' + keyword + '%')
                || entity.InventoryId != null && entity.InventoryId != string.Empty &&
                       EF.Functions.Like(entity.InventoryId, '%' + keyword + '%')
                || entity.Model != null && entity.Model != string.Empty &&
                       EF.Functions.Like(entity.Model, '%' + keyword + '%')
                || entity.Vincode != null && entity.Vincode != string.Empty &&
                       EF.Functions.Like(entity.Vincode, '%' + keyword + '%')
                || entity.VehicleType != null && entity.VehicleType.Name != string.Empty &&
                       EF.Functions.Like(entity.VehicleType.Name, '%' + keyword + '%');
        }

        protected override IQueryable<Vehicle> ComplexEntities => Entities.
                    Include(u => u.VehicleType).
                    Include(u => u.Location).
                    Include(a => a.Create).
                    Include(b => b.Mod).OrderByDescending(u => u.UpdatedDate).ThenByDescending(x => x.CreatedDate);
    }
}
