using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;
using System;

namespace Sheekr.Data.Configuration
{
    public class DiscursoLocalConfiguration : IEntityTypeConfiguration<DiscursoLocal>
    {
        public void Configure(EntityTypeBuilder<DiscursoLocal> builder)
        {
            builder.ToTable("Discursos_Locais");

            builder.HasKey(d => d.DiscursoLocalId);

            builder.Property(d => d.DiscursoLocalId)
                .HasColumnName("DiscursoLocalId")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(d => d.Congregacao)
                .WithMany()
                .HasForeignKey(d => d.CongregacaoId)
                .HasConstraintName("FK_DiscursoLocal_Congregacao")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.Tema)
                .WithMany()
                .HasForeignKey(d => d.TemaId)
                .HasConstraintName("FK_DiscursoLocal_Tema")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.OradorLocal)
                .WithMany(o => o.DiscursosFeitos)
                .HasForeignKey(d => d.OradorId)
                .HasConstraintName("FK_DiscursoLocal_OradorLocal")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

        }
    }

}
