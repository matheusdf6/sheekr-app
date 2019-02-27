using Microsoft.EntityFrameworkCore;
using Sheekr.Domain.Entities;
using Sheekr.Data.Configuration;
using System;

namespace Sheekr.Data
{
    public class SheekrDbContext : DbContext
    {
        public SheekrDbContext(DbContextOptions<SheekrDbContext> options)
            : base(options)
        {
        }

        public DbSet<Publicador> Publicadores { get; set; }
        public DbSet<Congregacao> Congregacoes { get; set; }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Designacao> Designacoes { get; set; }
        public DbSet<Licao> Licoes { get; set; }

        public DbSet<Territorio> Territorios { get; set; }
        public DbSet<Dirigente> Dirigentes { get; set; }
        public DbSet<Saida> Saidas { get; set; }

        public DbSet<OradorLocal> OradoresLocais { get; set; }
        public DbSet<OradorFora> OradoresFora { get; set; }
        public DbSet<Tema> Temas { get; set; }
        public DbSet<DiscursoFora> DiscursosFora { get; set; }
        public DbSet<DiscursoLocal> DiscursosLocal { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<InfoTables> Informacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PublicadorConfiguration());
            modelBuilder.ApplyConfiguration(new CongregacoesConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new DesignacoesConfiguration());
            modelBuilder.ApplyConfiguration(new LicaoConfiguration());
            modelBuilder.ApplyConfiguration(new TerritorioConfiguration());
            modelBuilder.ApplyConfiguration(new DirigenteConfiguration());
            modelBuilder.ApplyConfiguration(new SaidaConfiguration());
            modelBuilder.ApplyConfiguration(new OradorForaConfiguration());
            modelBuilder.ApplyConfiguration(new OradorLocalConfiguration());
            modelBuilder.ApplyConfiguration(new TemaConfiguration());
            modelBuilder.ApplyConfiguration(new DiscursoForaConfiguration());
            modelBuilder.ApplyConfiguration(new DiscursoLocalConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.Ignore<InfoTables>();
        }
    }
}
