using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;
using System.Collections.Generic;

namespace Sheekr.Data.Configuration
{
    public class CongregacoesConfiguration : IEntityTypeConfiguration<Congregacao>
    {
        public void Configure(EntityTypeBuilder<Congregacao> builder)
        {
            builder.ToTable("Congregacoes");

            builder.HasKey(c => c.CongregacaoId);

            builder.Property(c => c.CongregacaoId)
                .HasColumnName("CongregacaoId")
                .ValueGeneratedNever();

            builder.OwnsOne(c => c.NomeCongregacao);

            builder.HasMany(c => c.OradoresLocais)
                .WithOne(o => o.Congregacao);
        }
    }

}
