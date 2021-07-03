using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // UsersToVideo
    public class UsersToVideoConfiguration : IEntityTypeConfiguration<UsersToVideo>
    {
        public void Configure(EntityTypeBuilder<UsersToVideo> builder)
        {
            builder.ToTable("UsersToVideo", "dbo");
            builder.HasKey(x => new { x.UserId, x.VideoId, x.Priority });

            builder.Property(x => x.UserId).HasColumnName(@"UserId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.VideoId).HasColumnName(@"VideoId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Priority).HasColumnName(@"Priority").HasColumnType("varchar(50)").IsRequired().IsUnicode(false).HasMaxLength(50).ValueGeneratedNever();

            // Foreign keys
            builder.HasOne(a => a.User).WithMany(b => b.UsersToVideos).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersToVideo_Users");
            builder.HasOne(a => a.Video).WithMany(b => b.UsersToVideos).HasForeignKey(c => c.VideoId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UsersToVideo_Video");
        }
    }
}
