﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util.Impresion.Web.Entities {
    public class GuiaDbContext : DbContext {
        public GuiaDbContext(DbContextOptions opciones) : base(opciones) {

        }
        public DbSet<Guias> GuiasSet { get; set; }
        public DbSet<GuiasDet> GuiasDetSet { get; set; }
        public DbSet<Imagenes> ImagenesSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Guias>(entity => {
                entity.HasKey(e => e.GuiaId)
                    .HasName("Key1");

                entity.ToTable("Guias", "guias");

                entity.Property(e => e.GuiaId).HasColumnName("GuiaID");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<GuiasDet>(entity => {
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

            modelBuilder.Entity<Imagenes>(entity => {
                entity.HasKey(e => e.ImagenId)
                    .HasName("Key_Imagenes");

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
