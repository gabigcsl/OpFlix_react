using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFilx.WebApi.sln.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Plataformas> Plataformas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_OpFlix;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B222D7C522")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Lancamen__7D8FE3B2E448E242")
                    .IsUnique();

                entity.HasIndex(e => e.Sinopse)
                    .HasName("UQ__Lancamen__F401622528F1670E")
                    .IsUnique();

                entity.Property(e => e.Datal).HasColumnType("datetime");

                entity.Property(e => e.Duracao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Lancament__IdCat__1F98B2C1");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__Lancament__IdPla__208CD6FA");
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Permisso__7D8FE3B2581147D6")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataformas>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B26B5B3650")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105346069F347")
                    .IsUnique();

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Usuarios__7D8FE3B24631892F")
                    .IsUnique();

                entity.HasIndex(e => e.Senha)
                    .HasName("UQ__Usuarios__7ABB973108D23323")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Usuarios__IdPerm__66603565");
            });
        }
    }
}
