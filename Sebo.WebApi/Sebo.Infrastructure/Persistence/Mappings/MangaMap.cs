using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sebo.Core.Entities;

namespace Sebo.Infrastructure.Persistence.Mappings
{
    public class MangaMap : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {

            builder.HasKey(manga => manga.Id);
            builder.HasOne(manga => manga.User).WithMany(user => user.Mangas).HasForeignKey(manga => manga.UserId);
            builder.HasMany(manga => manga.Chapter).WithOne(chapter => chapter.Manga);

            builder.Property(manga => manga.Title).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(manga => manga.Description).IsRequired().HasColumnType("VARCHAR(MAX)");
            builder.Property(manga => manga.Author).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(manga => manga.Designer).IsRequired().HasColumnType("VARCHAR(100)");
            builder.Property(manga => manga.Status).IsRequired().HasColumnType("SMALLINT");

            builder.Property(manga => manga.CreatedDate).IsRequired().HasColumnType("SMALLDATETIME");
            builder.Property(manga => manga.UpdatedDate).IsRequired().HasColumnType("SMALLDATETIME");
            builder.Property(manga => manga.IsDeleted).IsRequired().HasColumnType("BIT");

        }
    }
}
