using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;
using System.Collections.Generic;

namespace Sheekr.Data.Configuration
{
    public class OradorLocalConfiguration : IEntityTypeConfiguration<OradorLocal>
    {
        public void Configure(EntityTypeBuilder<OradorLocal> builder)
        {
            builder.ToTable("Oradores_Locais");

            builder.HasKey(o => o.OradorId);

            builder.Property(o => o.OradorId)
                .HasColumnName("OradorId")
                .ValueGeneratedNever();

            builder.HasOne(o => o.DadosPublicador)
                .WithOne(p => p.Orador)
                .HasForeignKey<OradorLocal>(o => o.PublicadorId)
                .HasConstraintName("FK_OradorLocal_Publicador")
                .IsRequired();

            builder.HasOne(o => o.Congregacao)
                .WithMany(c => c.OradoresLocais)
                .HasForeignKey(o => o.CongregacaoId)
                .HasConstraintName("FK_OradorLocal_Congregacao")
                .IsRequired();

            builder.HasMany(o => o.DiscursosFeitos)
                .WithOne(d => d.OradorLocal);
                
            builder.Ignore(o => o.PrimeiroNome);
            builder.Ignore(o => o.UltimoNome);
        }
    }
}
