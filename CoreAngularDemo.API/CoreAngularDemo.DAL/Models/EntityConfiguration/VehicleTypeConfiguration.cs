﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("VEHICLE_TYPE");

            builder.HasIndex(e => e.Name)
                .HasName("UQ__VEHICLE___D9C1FA0095358636")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedById).HasColumnName("CREATE_ID");

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("MOD_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedById).HasColumnName("MOD_ID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasMaxLength(50);

            builder.HasOne(d => d.Create)
                .WithMany(p => p.VehicleTypeCreate)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK_MOD_VEHICLE_TYPE_USER");

            builder.HasOne(d => d.Mod)
                .WithMany(p => p.VehicleTypeMod)
                .HasForeignKey(d => d.UpdatedById)
                .HasConstraintName("FK_MOD_VEHICLE_TYPE_ROLE");
        }
    }
}
