using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class TerritorioConfiguration : IEntityTypeConfiguration<Territorio>
    {
        public void Configure(EntityTypeBuilder<Territorio> builder)
        {
            builder.ToTable("Territorios");

            builder.HasKey(t => t.TerritorioId);

            builder.Property(t => t.TerritorioId)
                .HasColumnName("TerritorioId")
                .ValueGeneratedNever();

            builder.Property(t => t.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.UrlImagem)
                .HasMaxLength(100);

            builder.Property(t => t.Local)
                .HasColumnType("int")
                .IsRequired();

            builder.HasMany(t => t.DiasTrabalhados)
                .WithOne(s => s.Territorio);
        }
    }
}
