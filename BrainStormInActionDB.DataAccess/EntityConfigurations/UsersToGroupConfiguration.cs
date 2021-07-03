using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // UsersToGroup
    public class UsersToGroupConfiguration : IEntityTypeConfiguration<UsersToGroup>
    {
        public void Configure(EntityTypeBuilder<UsersToGroup> builder)
        {
            builder.ToTable("UsersToGroup", "dbo");
            builder.HasKey(x => new { x.UserId, x.GroupId });

            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.GroupId).HasColumnName(@"GroupId").HasColumnType("int").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Group).WithMany(b => b.UsersToGroups).HasForeignKey(c => c.GroupId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersToGroup_Groups");
            builder.HasOne(a => a.User).WithMany(b => b.UsersToGroups).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersToGroup_Users");
        }
    }
}
