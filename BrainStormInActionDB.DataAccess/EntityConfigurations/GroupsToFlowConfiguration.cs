using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // GroupsToFlow
    public class GroupsToFlowConfiguration : IEntityTypeConfiguration<GroupsToFlow>
    {
        public void Configure(EntityTypeBuilder<GroupsToFlow> builder)
        {
            builder.ToTable("GroupsToFlow", "dbo");
            builder.HasKey(x => new { x.GroupId, x.FlowId, x.Priority });

            builder.Property(x => x.GroupId).HasColumnName(@"GroupId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.FlowId).HasColumnName(@"FlowId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Priority).HasColumnName(@"Priority").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Flow).WithMany(b => b.GroupsToFlows).HasForeignKey(c => c.FlowId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupsToFlow_Flow");
            builder.HasOne(a => a.Group).WithMany(b => b.GroupsToFlows).HasForeignKey(c => c.GroupId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupsToFlow_Groups");
        }
    }
}
