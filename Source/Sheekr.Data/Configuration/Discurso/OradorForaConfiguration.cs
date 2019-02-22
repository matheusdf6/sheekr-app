using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;
using System.Collections.Generic;

namespace Sheekr.Data.Configuration
{
    public class OradorForaConfiguration : IEntityTypeConfiguration<OradorFora>
    {
        public void Configure(EntityTypeBuilder<OradorFora> builder)
        {
            builder.ToTable("Oradores_Fora");

            builder.HasKey(o => o.OradorId);

            builder.Property(o => o.OradorId)
                .HasColumnName("OradorId")
                .ValueGeneratedNever(); 

            builder.Property(o => o.PrimeiroNome)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(o => o.UltimoNome)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(o => o.Telefone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.Property(o => o.Email)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(o => o.EscolhaContato)
                .HasColumnType("smallint")
                .IsRequired();

            builder.HasOne(o => o.Congregacao)
                .WithMany()
                .HasForeignKey(o => o.CongregacaoId)
                .HasConstraintName("FK_OradorFora_Congregacao")
                .IsRequired();                 
        }
    }
}
