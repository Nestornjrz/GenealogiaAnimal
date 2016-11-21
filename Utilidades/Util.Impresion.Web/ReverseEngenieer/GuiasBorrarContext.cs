using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Util.Impresion.Web.ReverseEngenieer
{
    public partial class GuiasBorrarContext : DbContext
    {
        public virtual DbSet<Guias> Guias { get; set; }
        public virtual DbSet<GuiasDet> GuiasDet { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=GuiasBorrar;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guias>(entity =>
            {
                entity.HasKey(e => e.GuiaId)
                    .HasName("Key1");

                entity.ToTable("Guias", "guias");

                entity.Property(e => e.GuiaId).HasColumnName("GuiaID");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<GuiasDet>(entity =>
            {
                entity.HasKey(e => e.GuiaDetId)
                    .HasName("Pk_GuiasDet");

                entity.ToTable("GuiasDet", "guias");

                entity.HasIndex(e => e.GuiaId)
                    .HasName("IX_GuiasDet_GuiaID");

                entity.HasIndex(e => e.ImagenId)
                    .HasName("IX_GuiasDet_ImagenID");

                entity.Property(e => e.GuiaDetId).HasColumnName("GuiaDetID");

                entity.Property(e => e.GuiaId).HasColumnName("GuiaID");

                entity.Property(e => e.ImagenId).HasColumnName("ImagenID");

                entity.HasOne(d => d.Guia)
                    .WithMany(p => p.GuiasDet)
                    .HasForeignKey(d => d.GuiaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Fk_Guias-GuiasDet");

                entity.HasOne(d => d.Imagen)
                    .WithMany(p => p.GuiasDet)
                    .HasForeignKey(d => d.ImagenId)
                    .HasConstraintName("fk_GuiasDet-Imagenes");
            });

            modelBuilder.Entity<Imagenes>(entity =>
            {
                entity.HasKey(e => e.ImagenId)
                    .HasName("Key2");

                entity.ToTable("Imagenes", "guias");

                entity.Property(e => e.ImagenId)
                    .HasColumnName("ImagenID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });
        }
    }
}