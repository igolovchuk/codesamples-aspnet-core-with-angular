using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class CoreAngularDemoionConfiguration : IEntityTypeConfiguration<CoreAngularDemoion>
    {
        public void Configure(EntityTypeBuilder<CoreAngularDemoion> builder)
        {
            builder.ToTable("CoreAngularDemoION");

            builder.HasIndex(e => new { e.FromStateId, e.ActionTypeId, e.ToStateId })
                .HasName("CK_ISSUE_CoreAngularDemoION_UNIQUE")
                .IsUnique();

            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.ActionTypeId).HasColumnName("ACTION_TYPE_ID");

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATE_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.CreatedById).HasColumnName("CREATE_ID");

            builder.Property(e => e.FromStateId).HasColumnName("FROM_STATE_ID");

            builder.Property(e => e.IsFixed).HasColumnName("IS_FIXED");

            builder.Property(e => e.UpdatedDate)
                .HasColumnName("MOD_DATE")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.UpdatedById).HasColumnName("MOD_ID");

            builder.Property(e => e.ToStateId).HasColumnName("TO_STATE_ID");

            builder.HasOne(d => d.ActionType)
                .WithMany(p => p.CoreAngularDemoion)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ACTION_TYPE_ISSUE");

            builder.HasOne(d => d.Create)
                .WithMany(p => p.CoreAngularDemoionCreate)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK_CREATE_ISSUE_CoreAngularDemoION_USER");

            builder.HasOne(d => d.FromState)
                .WithMany(p => p.CoreAngularDemoionFromState)
                .HasForeignKey(d => d.FromStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FROM_STATE");

            builder.HasOne(d => d.Mod)
                .WithMany(p => p.CoreAngularDemoionMod)
                .HasForeignKey(d => d.UpdatedById)
                .HasConstraintName("FK_MOD_ISSUE_CoreAngularDemoION_USER");

            builder.HasOne(d => d.ToState)
                .WithMany(p => p.CoreAngularDemoionToState)
                .HasForeignKey(d => d.ToStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TO_STATE");
        }
    }
}
