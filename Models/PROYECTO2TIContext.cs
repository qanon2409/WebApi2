using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi2.Models
{
    public partial class PROYECTO2TIContext : DbContext
    {
        public PROYECTO2TIContext()
        {
        }

        public PROYECTO2TIContext(DbContextOptions<PROYECTO2TIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<AutorEscribeNot> AutorEscribeNots { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Fuente> Fuentes { get; set; }
        public virtual DbSet<Noticia> Noticias { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6BA9ENFJ; Database=PROYECTO2TI; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("AUTOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<AutorEscribeNot>(entity =>
            {
                entity.HasKey(e => new { e.Idautor, e.Idnot2 });

                entity.ToTable("AutorEscribeNot");

                entity.Property(e => e.Idautor).HasColumnName("IDAutor");

                entity.Property(e => e.Idnot2).HasColumnName("IDNOT2");

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.AutorEscribeNots)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTORMOD");

                entity.HasOne(d => d.Idnot2Navigation)
                    .WithMany(p => p.AutorEscribeNots)
                    .HasForeignKey(d => d.Idnot2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTES");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Fuente>(entity =>
            {
                entity.ToTable("FUENTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpais).HasColumnName("IDPAIS");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Fuentes)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_PAIS_FUENTE");
            });

            modelBuilder.Entity<Noticia>(entity =>
            {
                entity.ToTable("NOTICIAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Idcat).HasColumnName("IDCAT");

                entity.Property(e => e.Idfuente).HasColumnName("IDFUENTE");

                entity.Property(e => e.Idpais).HasColumnName("IDPAIS");

                entity.Property(e => e.Titulo)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.Property(e => e.Urlnoticia)
                    .IsUnicode(false)
                    .HasColumnName("URLNOTICIA");

                entity.HasOne(d => d.IdcatNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Idcat)
                    .HasConstraintName("FK_NOT_CAT");

                entity.HasOne(d => d.IdfuenteNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Idfuente)
                    .HasConstraintName("FK_NOT_FUENTE");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.Noticia)
                    .HasForeignKey(d => d.Idpais)
                    .HasConstraintName("FK_NOT_PAIS");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.ToTable("PAIS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
