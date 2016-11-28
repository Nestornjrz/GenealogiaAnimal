using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Util.Impresion.Web.Entities;

namespace Util.Impresion.Web.Migrations
{
    [DbContext(typeof(GuiaDbContext))]
    [Migration("20161128163742_Creacion inicial")]
    partial class Creacioninicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Util.Impresion.Web.Entities.Guias", b =>
                {
                    b.Property<long>("GuiaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GuiaID");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<long>("Numero");

                    b.HasKey("GuiaId")
                        .HasName("Key1");

                    b.ToTable("Guias","guias");
                });

            modelBuilder.Entity("Util.Impresion.Web.Entities.GuiasDet", b =>
                {
                    b.Property<long>("GuiaDetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GuiaDetID");

                    b.Property<int?>("ClienteId")
                        .HasColumnName("ClienteID");

                    b.Property<long>("GuiaId")
                        .HasColumnName("GuiaID");

                    b.Property<int?>("ImagenId")
                        .HasColumnName("ImagenID");

                    b.HasKey("GuiaDetId")
                        .HasName("Pk_GuiasDet");

                    b.HasIndex("ClienteId")
                        .HasName("IX_GuasDet_ClienteID");

                    b.HasIndex("GuiaId")
                        .HasName("IX_GuiasDet_GuiaID");

                    b.HasIndex("ImagenId")
                        .HasName("IX_GuiasDet_ImagenID");

                    b.ToTable("GuiasDet","guias");
                });

            modelBuilder.Entity("Util.Impresion.Web.Entities.Imagenes", b =>
                {
                    b.Property<int>("ImagenId")
                        .HasColumnName("ImagenID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProveedorId")
                        .HasColumnName("ProveedorID");

                    b.Property<bool>("VigenteSn");

                    b.HasKey("ImagenId")
                        .HasName("pk_Imagenes");

                    b.HasIndex("ProveedorId")
                        .HasName("IX_Imagenes_ProveedorID");

                    b.ToTable("Imagenes","guias");
                });

            modelBuilder.Entity("Util.Impresion.Web.Entities.ProveeClientes", b =>
                {
                    b.Property<int>("ProveeClienteId")
                        .HasColumnName("ProveeClienteID");

                    b.Property<bool>("ClienteSn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("ProveedorSn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("0");

                    b.HasKey("ProveeClienteId")
                        .HasName("pk_Estancias");

                    b.ToTable("ProveeClientes","guias");
                });

            modelBuilder.Entity("Util.Impresion.Web.Entities.GuiasDet", b =>
                {
                    b.HasOne("Util.Impresion.Web.Entities.ProveeClientes", "Cliente")
                        .WithMany("GuiasDet")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Util.Impresion.Web.Entities.Guias", "Guia")
                        .WithMany("GuiasDet")
                        .HasForeignKey("GuiaId")
                        .HasConstraintName("Fk_Guias-GuiasDet");

                    b.HasOne("Util.Impresion.Web.Entities.Imagenes", "Imagen")
                        .WithMany("GuiasDet")
                        .HasForeignKey("ImagenId");
                });

            modelBuilder.Entity("Util.Impresion.Web.Entities.Imagenes", b =>
                {
                    b.HasOne("Util.Impresion.Web.Entities.ProveeClientes", "Proveedor")
                        .WithMany("Imagenes")
                        .HasForeignKey("ProveedorId");
                });
        }
    }
}
