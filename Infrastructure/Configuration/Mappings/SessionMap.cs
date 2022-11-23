using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration.Mappings
{
    public class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            //tabela
            builder.ToTable("TB_SESSION");

            //Chave primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); // identiti de 1 a 1

            //Propriedades
            builder.Property(x => x.StartTime)
                .IsRequired()
                .HasColumnName("Start_Time")
                .HasColumnType("DATETIME");

            builder.Property(x => x.EndTIme)
                .IsRequired()
                .HasColumnName("End_TIme")
                .HasColumnType("DATETIME");

            builder.Property(x => x.EntryValue)
              .IsRequired()
              .HasColumnName("Entry_Value")
              .HasColumnType("DECIMAL");

            builder.Property(x => x.AnimationType)
              .IsRequired()
              .HasColumnName("Animation_Type");

            builder.Property(x => x.AudioType)
              .IsRequired()
              .HasColumnName("Audio_Type");

            // relaçao
            builder.HasOne(x => x.Rooms) // uma sessao tem uma sala
                .WithMany(x => x.Sessions) // que tem muitas sessoes
                .HasConstraintName("FK_Session_Rooms")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Movie) // uma sessao tem uma sala
                .WithMany(x => x.Sessions) // que tem muitas sessoes
                .HasConstraintName("FK_Session_Movie")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}