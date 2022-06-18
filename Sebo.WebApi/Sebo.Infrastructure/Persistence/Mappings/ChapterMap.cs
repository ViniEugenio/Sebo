using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sebo.Core.Entities;

namespace Sebo.Infrastructure.Persistence.Mappings
{
    public class ChapterMap : IEntityTypeConfiguration<Chapter>
    {

        public void Configure(EntityTypeBuilder<Chapter> builder)
        {

            builder.HasKey(chapter => chapter.Id);
            builder.HasOne(chapter => chapter.Manga).WithMany(manga => manga.Chapter).HasForeignKey(chapter => chapter.MangaId);

            builder.Property(chapter => chapter.Title).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(chapter => chapter.ProcessingStatus).IsRequired().HasColumnType("INT");
            builder.Property(chapter => chapter.CreatedDate).IsRequired().HasColumnType("SMALLDATETIME");
            builder.Property(chapter => chapter.UpdatedDate).IsRequired().HasColumnType("SMALLDATETIME");
            builder.Property(chapter => chapter.IsDeleted).IsRequired().HasColumnType("BIT");

        }

    }
}
