using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreAngularDemo.DAL.Models.Entities;

namespace CoreAngularDemo.DAL.Models
{
    public class IssueLogPartConfiguration : IEntityTypeConfiguration<IssueLogPart>
    {
        public void Configure(EntityTypeBuilder<IssueLogPart> builder)
        {
            builder.HasKey(ur => new { ur.IssueLogId, ur.PartId });

            builder.HasOne(ur => ur.IssueLog)
                .WithMany(r => r.IssueLogParts)
                .HasForeignKey(ur => ur.IssueLogId)
                .IsRequired();

            builder.HasOne(ur => ur.Part)
                .WithMany(r => r.IssueLogParts)
                .HasForeignKey(ur => ur.PartId)
                .IsRequired();
        }
    }
}
