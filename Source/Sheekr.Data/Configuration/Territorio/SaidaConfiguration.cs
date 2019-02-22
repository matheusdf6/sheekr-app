using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class SaidaConfiguration : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.ToTable("Saidas");

            builder.HasKey(s => s.SaidaId);

            builder.Property(s => s.SaidaId)
                .HasColumnName("SaidaId")
                .ValueGeneratedNever();

            builder.Property(s => s.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(s => s.Dirigente)
                .WithMany(d => d.Saidas)
                .HasForeignKey(s => s.DirigenteId)
                .HasConstraintName("FK_Saida_Dirigente")
                .IsRequired();

            builder.HasOne(s => s.Territorio)
                .WithMany(t => t.DiasTrabalhados)
                .HasForeignKey(s => s.TerritorioId)
                .HasConstraintName("FK_Saida_Territorio")
                .IsRequired();
        }
    }
}
