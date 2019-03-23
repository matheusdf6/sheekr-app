using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sheekr.Domain.Entities;
using Sheekr.Domain.Enum;

namespace Sheekr.Data.Configuration
{
    public class DesignacoesConfiguration : IEntityTypeConfiguration<Designacao>
    {

        public void Configure(EntityTypeBuilder<Designacao> builder)
        {
            builder.ToTable("Designacoes");

            builder.HasKey(d => d.DesignacaoId);

            builder.Property(d => d.DesignacaoId)
                .HasColumnName("DesignacaoId")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Data)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(d => d.Tipo)
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(d => d.Local)
                .HasColumnType("smallint")
                .HasConversion(new EnumToNumberConverter<LocalDesignacao, int>())
                .IsRequired();

            builder.HasOne(d => d.Licao)
                .WithMany()
                .HasForeignKey(d => d.LicaoId)
                .HasConstraintName("FK_Designacao_Licao")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.AlunoPrincipal)
                .WithMany(a => a.DesignacoesPrincipal)
                .HasForeignKey(d => d.AlunoPrincipalId)
                .HasConstraintName("FK_Designacoes_Aluno_AlunoPrincipal")
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(d => d.AlunoAjudante)
                .WithMany(a => a.DesignacoesAjudante)
                .HasForeignKey(d => d.AlunoAjudanteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Designacoes_Aluno_AlunoAjudante");
        }
    }

}
