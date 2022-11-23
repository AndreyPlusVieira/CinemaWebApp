using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Mappings
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //tabela
            builder.ToTable("TB_MOVIE");

            //Chave primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // identiti de 1 a 1

            //Propriedades
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Image)
               .IsRequired()
               .HasColumnName("Image")
               .HasColumnType("VARCHAR")
               .HasMaxLength(255);

            builder.Property(x => x.Duration)
               .IsRequired()
               .HasColumnName("Duration")
               .HasColumnType("SMALLINT");

            builder.Property(x => x.Active)
               .IsRequired()
               .HasColumnName("Active")
               .HasColumnType("BIT");
        }
    }
}