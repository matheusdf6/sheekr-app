using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class LicaoConfiguration : IEntityTypeConfiguration<Licao>
    {
        public void Configure(EntityTypeBuilder<Licao> builder)
        {
            builder.ToTable("Licoes");

            builder.HasKey(l => l.LicaoId);

            builder.Property(l => l.LicaoId)
                .HasColumnName("LicaoId")
                .ValueGeneratedNever();

            builder.Property(l => l.TituloLicao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }


}
