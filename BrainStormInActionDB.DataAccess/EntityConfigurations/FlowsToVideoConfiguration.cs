using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // FlowsToVideo
    public class FlowsToVideoConfiguration : IEntityTypeConfiguration<FlowsToVideo>
    {
        public void Configure(EntityTypeBuilder<FlowsToVideo> builder)
        {
            builder.ToTable("FlowsToVideo", "dbo");
            builder.HasKey(x => new { x.FlowId, x.VideoId });

            builder.Property(x => x.FlowId).HasColumnName(@"FlowId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.VideoId).HasColumnName(@"VideoId").HasColumnType("int").IsRequired().ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.Video).WithMany(b => b.FlowsToVideos).HasForeignKey(c => c.VideoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FlowsToVideo_Video");
        }
    }
}
