using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Mappings
{
    public class RoomsMap : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            //tabela
            builder.ToTable("TB_ROOMS");

            //Chave primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // identiti de 1 a 1

            //Propriedades
            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasColumnName("Name")
                 .HasColumnType("VARCHAR")
                 .HasMaxLength(50);

            builder.Property(x => x.Seats)
                .IsRequired()
                .HasColumnName("Seats")
                .HasColumnType("TINYINT");
        }
    }
}