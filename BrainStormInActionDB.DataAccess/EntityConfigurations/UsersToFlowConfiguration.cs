using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // UsersToFlow
    public class UsersToFlowConfiguration : IEntityTypeConfiguration<UsersToFlow>
    {
        public void Configure(EntityTypeBuilder<UsersToFlow> builder)
        {
            builder.ToTable("UsersToFlow", "dbo");
            builder.HasKey(x => new { x.UserId, x.FlowId, x.Priority });

            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FlowId).HasColumnName(@"FlowId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Priority).HasColumnName(@"Priority").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.User).WithMany(b => b.UsersToFlows).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersToFlow_Users");
        }
    }
}
