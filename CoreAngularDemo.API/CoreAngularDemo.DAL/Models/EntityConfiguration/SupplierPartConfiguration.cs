using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class SupplierPartConfiguration : IEntityTypeConfiguration<SupplierPart>
    {
        public void Configure(EntityTypeBuilder<SupplierPart> builder)
        {
            builder.HasKey(ur => new { ur.SupplierId, ur.PartId });

            builder.HasOne(ur => ur.Supplier)
                .WithMany(r => r.SupplierParts)
                .HasForeignKey(ur => ur.SupplierId)
                .IsRequired();

            builder.HasOne(ur => ur.Part)
                .WithMany(r => r.SupplierParts)
                .HasForeignKey(ur => ur.PartId)
                .IsRequired();
        }
    }
}
