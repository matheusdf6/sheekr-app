using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Enum;

namespace Sheekr.Data.Configuration
{
    public class PublicadorConfiguration : IEntityTypeConfiguration<Publicador>
    {
        public void Configure(EntityTypeBuilder<Publicador> builder)
        {
            builder.ToTable("Publicadores");

            builder.HasKey(p => p.PublicadorId);

            builder.Property(p => p.PublicadorId)
                .HasColumnName("PublicadorId")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Sexo)
                .HasConversion(new EnumToNumberConverter<Genero, int>())
                .IsRequired();

            builder.Property(p => p.Privilegio)
                .HasConversion(new EnumToNumberConverter<Privilegio, int>())
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasMaxLength(11);

            builder.Property(p => p.Email)
                .HasMaxLength(60);

            builder.Property(p => p.PrimeiroNome)
                .IsRequired();

            builder.Property(p => p.UltimoNome)
                .IsRequired();

            builder.Ignore(p => p.NomeCompleto);

            builder.HasOne(p => p.Aluno)
                .WithOne(a => a.DadosPublicador);

            builder.HasOne(p => p.Orador)
                .WithOne(o => o.DadosPublicador);

            builder.HasOne(p => p.Dirigente)
                .WithOne(d => d.DadosPublicador);
        }
    }
}
