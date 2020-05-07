﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("LOCATION");

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedById).HasColumnName("CREATE_ID");

            builder.Property(e => e.Description).HasColumnName("DESCRIPTION");

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("MOD_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedById).HasColumnName("MOD_ID");

            builder.Property(e => e.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50);

            builder.HasOne(d => d.Create)
                .WithMany(p => p.LocationCreate)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK_CREATE_LOCATION_USER");

            builder.HasOne(d => d.Mod)
                .WithMany(p => p.LocationMod)
                .HasForeignKey(d => d.UpdatedById)
                .HasConstraintName("FK_MOD_LOCATION_USER");
        }
    }
}
