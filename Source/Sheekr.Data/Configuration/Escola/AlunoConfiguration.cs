using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sheekr.Domain.Entities;

namespace Sheekr.Data.Configuration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.AlunoId);

            builder.Property(a => a.AlunoId)
                .HasColumnName("AlunoId")
                .ValueGeneratedNever();

            builder.Property(a => a.FazDemonstracao)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(a => a.FazLeitura)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(a => a.FazDiscurso)
                .HasColumnType("bit")
                .IsRequired();

            builder.HasOne(a => a.DadosPublicador)
                .WithOne(p => p.Aluno)
                .HasForeignKey<Aluno>(a => a.PublicadorId)
                .HasConstraintName("FK_Aluno_Publicador")
                .IsRequired();

            builder.HasMany(a => a.DesignacoesPrincipal)
                .WithOne(d => d.AlunoPrincipal);

            builder.HasMany(a => a.DesignacoesAjudante)
                .WithOne(d => d.AlunoAjudante);
        }
    }


}
