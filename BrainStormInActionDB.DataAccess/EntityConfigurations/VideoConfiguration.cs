using BrainStormInActionDB.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrainStormInActionDB.DataAccess.EntityConfigurations
{
    // Video
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Video", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_Video").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("varchar(150)").IsRequired(false).IsUnicode(false).HasMaxLength(150);
        }
    }
}
