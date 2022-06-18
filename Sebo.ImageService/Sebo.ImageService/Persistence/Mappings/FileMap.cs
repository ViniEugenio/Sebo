using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sebo.ImageService.Persistence.Mappings
{
    public class FileMap : IEntityTypeConfiguration<Entities.File>
    {

        public void Configure(EntityTypeBuilder<Entities.File> builder)
        {

            builder.HasKey(file => file.Id);
            builder.Property(file => file.ChapterId);
            builder.Property(file => file.Url).HasColumnType("VARCHAR(MAX)");
            builder.Property(file => file.Order).HasColumnType("INT");
            builder.Property(file => file.DataCadastro).HasColumnType("SMALLDATETIME");
            builder.Property(file => file.IsDeleted).HasColumnType("BIT");

        }

    }
}
