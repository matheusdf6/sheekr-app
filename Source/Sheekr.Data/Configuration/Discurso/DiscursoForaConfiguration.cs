using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class DiscursoForaConfiguration : IEntityTypeConfiguration<DiscursoFora>
    {
        public void Configure(EntityTypeBuilder<DiscursoFora> builder)
        {
            builder.ToTable("Discursos_Fora");

            builder.HasKey(d => d.DiscursoForaId);

            builder.Property(d => d.DiscursoForaId)
                .HasColumnName("DiscursoLocalId")
                .ValueGeneratedNever();

            builder.Property(d => d.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(d => d.Tema)
                .WithMany()
                .HasForeignKey(d => d.TemaId)
                .HasConstraintName("FK_DiscursoFora_Tema")
                .IsRequired();

            builder.HasOne(d => d.OradorFora)
                .WithMany()
                .HasForeignKey(d => d.OradorForaId)
                .HasConstraintName("FK_DiscursoFora_OradorFora")
                .IsRequired();
        }
    }

}
