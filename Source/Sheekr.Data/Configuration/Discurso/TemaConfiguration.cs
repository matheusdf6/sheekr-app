using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class TemaConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");

            builder.HasKey(t => t.TemaId);

            builder.Property(t => t.TemaId)
                .ValueGeneratedNever();

            builder.Property(t => t.TituloTema)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
