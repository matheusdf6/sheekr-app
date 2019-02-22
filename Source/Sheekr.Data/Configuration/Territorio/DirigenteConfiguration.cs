using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class DirigenteConfiguration : IEntityTypeConfiguration<Dirigente>
    {
        public void Configure(EntityTypeBuilder<Dirigente> builder)
        {
            builder.ToTable("Dirigentes");

            builder.HasKey(d => d.DirigenteId);

            builder.Property(d => d.DirigenteId)
                .HasColumnName("DirigenteId")
                .ValueGeneratedNever();

            builder.HasOne(d => d.DadosPublicador)
                .WithOne(p => p.Dirigente)
                .HasForeignKey<Dirigente>(d => d.PublicadorId)
                .HasConstraintName("FK_Dirigente_Publicador")
                .IsRequired();

            builder.HasMany(d => d.Saidas)
                .WithOne(s => s.Dirigente);
        }
    }
}
