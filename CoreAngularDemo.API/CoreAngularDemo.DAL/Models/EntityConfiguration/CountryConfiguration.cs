﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("COUNTRY");

            builder.HasIndex(e => e.Name)
                .HasName("UQ__COUNTRY__D9C1FA008FF4E681")
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
                .WithMany(p => p.CountryCreate)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK_CREATE_COUNTRY_USER");

            builder.HasOne(d => d.Mod)
                .WithMany(p => p.CountryMod)
                .HasForeignKey(d => d.UpdatedById)
                .HasConstraintName("FK_MOD_COUNTRY_USER");
        }
    }
}
