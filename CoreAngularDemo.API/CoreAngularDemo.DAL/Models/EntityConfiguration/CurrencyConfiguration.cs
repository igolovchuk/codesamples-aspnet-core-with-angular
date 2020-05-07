﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("CURRENCY");

            builder.HasIndex(e => e.ShortName)
                .HasName("UQ__CURRENCY__F4E7E33EEBE730B7")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedById).HasColumnName("CREATE_ID");

            builder.Property(e => e.FullName)
                .IsRequired()
                .HasColumnName("FULL_NAME")
                .HasMaxLength(50);

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("MOD_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedById).HasColumnName("MOD_ID");

            builder.Property(e => e.ShortName)
                .IsRequired()
                .HasColumnName("SHORT_NAME")
                .HasMaxLength(5);

            builder.HasOne(d => d.Create)
                .WithMany(p => p.CurrencyCreate)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK_CREATE_CURRENCY_USER");

            builder.HasOne(d => d.Mod)
                .WithMany(p => p.CurrencyMod)
                .HasForeignKey(d => d.UpdatedById)
                .HasConstraintName("FK_MOD_CURRENCY_USER");
        }
    }
}
