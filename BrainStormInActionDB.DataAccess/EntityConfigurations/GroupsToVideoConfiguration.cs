using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // GroupsToVideo
    public class GroupsToVideoConfiguration : IEntityTypeConfiguration<GroupsToVideo>
    {
        public void Configure(EntityTypeBuilder<GroupsToVideo> builder)
        {
            builder.ToTable("GroupsToVideo", "dbo");
            builder.HasKey(x => new { x.GroupId, x.VideoId, x.Priority });

            builder.Property(x => x.GroupId).HasColumnName(@"GroupId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.VideoId).HasColumnName(@"VideoId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Priority).HasColumnName(@"Priority").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Group).WithMany(b => b.GroupsToVideos).HasForeignKey(c => c.GroupId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupsToVideo_Groups");
            builder.HasOne(a => a.Video).WithMany(b => b.GroupsToVideos).HasForeignKey(c => c.VideoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_GroupsToVideo_Video");
        }
    }
}
