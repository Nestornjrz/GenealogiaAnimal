using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegGen.Web.Models
{
    public partial class RegGeneologicoContext : DbContext
    {
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Establecimientos> Establecimientos { get; set; }
        public virtual DbSet<Generaciones> Generaciones { get; set; }
        public virtual DbSet<GradoSangres> GradoSangres { get; set; }
        public virtual DbSet<Origenes> Origenes { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pelajes> Pelajes { get; set; }
        public virtual DbSet<Propietarios> Propietarios { get; set; }
        public virtual DbSet<Razas> Razas { get; set; }
        public virtual DbSet<RegistroZootecnicos> RegistroZootecnicos { get; set; }
        public virtual DbSet<VacunoCaracteristicas> VacunoCaracteristicas { get; set; }
        public virtual DbSet<VacunoHembras> VacunoHembras { get; set; }
        public virtual DbSet<VacunoMachos> VacunoMachos { get; set; }
        public virtual DbSet<Vacunos> Vacunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=RegGeneologico;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => e.CiudadId)
                    .HasName("pk_CiudadSet");

                entity.ToTable("Ciudades", "RegG");

                entity.Property(e => e.CiudadId).HasColumnName("CiudadID");

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.NombreCiudad)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Ciudades-Departamentos");
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Pk_Compras");

                entity.ToTable("Compras", "RegG");

                entity.HasIndex(e => e.OrigenId)
                    .HasName("IX_Compras_Origenes");

                entity.Property(e => e.VacunoId)
                    .HasColumnName("VacunoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Observacion).HasColumnType("text");

                entity.Property(e => e.OrigenId).HasColumnName("OrigenID");

                entity.Property(e => e.PrecioCompra).HasColumnType("money");

                entity.HasOne(d => d.Origen)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.OrigenId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pk_Compras-Origenes");

                entity.HasOne(d => d.Vacuno)
                    .WithOne(p => p.Compras)
                    .HasForeignKey<Compras>(d => d.VacunoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pk_VacunoCaracteristicas-Compras");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.DepartamentoId)
                    .HasName("pk_DepartamentoSet");

                entity.ToTable("Departamentos", "RegG");

                entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");

                entity.Property(e => e.NombreDepartamento)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PaisId).HasColumnName("PaisID");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Departamentos-Paises");
            });

            modelBuilder.Entity<Establecimientos>(entity =>
            {
                entity.HasKey(e => e.EstablecimientoId)
                    .HasName("pk_Establecimientos");

                entity.ToTable("Establecimientos", "RegG");

                entity.HasIndex(e => e.PropietarioId)
                    .HasName("IX_Establecimientos_PropietarioID");

                entity.Property(e => e.EstablecimientoId).HasColumnName("EstablecimientoID");

                entity.Property(e => e.CiudadId).HasColumnName("CiudadID");

                entity.Property(e => e.NombreEstablecimiento)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Establecimientos)
                    .HasForeignKey(d => d.CiudadId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Fk-Establecimientos-Ciudades");

                entity.HasOne(d => d.Propietario)
                    .WithMany(p => p.Establecimientos)
                    .HasForeignKey(d => d.PropietarioId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_Estable-Propie");
            });

            modelBuilder.Entity<Generaciones>(entity =>
            {
                entity.HasKey(e => e.GeneracionId)
                    .HasName("pk_GeneracionSet");

                entity.ToTable("Generaciones", "RegG");

                entity.HasIndex(e => new { e.RazaId, e.NombreGeneracion })
                    .HasName("Index_GeneracionSet_Raza_NombreGeneracion")
                    .IsUnique();

                entity.Property(e => e.GeneracionId).HasColumnName("GeneracionID");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(max)");

                entity.Property(e => e.NombreGeneracion)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RazaId).HasColumnName("RazaID");

                entity.HasOne(d => d.Raza)
                    .WithMany(p => p.Generaciones)
                    .HasForeignKey(d => d.RazaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_GeneracionSet-RazaSet");
            });

            modelBuilder.Entity<GradoSangres>(entity =>
            {
                entity.HasKey(e => e.GradoSangreId)
                    .HasName("pk_CategoriaSet");

                entity.ToTable("GradoSangres", "RegG");

                entity.HasIndex(e => new { e.RazaId, e.NombreGradoSangre })
                    .HasName("Index_GradoSangreSet_Raza_NombreGradoSangre")
                    .IsUnique();

                entity.Property(e => e.GradoSangreId).HasColumnName("GradoSangreID");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(max)");

                entity.Property(e => e.NombreGradoSangre)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.RazaId).HasColumnName("RazaID");

                entity.HasOne(d => d.Raza)
                    .WithMany(p => p.GradoSangres)
                    .HasForeignKey(d => d.RazaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_GradoSangreSet-RazaSet");
            });

            modelBuilder.Entity<Origenes>(entity =>
            {
                entity.HasKey(e => e.OrigenId)
                    .HasName("pk_OrigenSet");

                entity.ToTable("Origenes", "RegG");

                entity.HasIndex(e => e.NombreOrigen)
                    .HasName("Index_OrigenSet_NombreOrigen")
                    .IsUnique();

                entity.Property(e => e.OrigenId).HasColumnName("OrigenID");

                entity.Property(e => e.NombreOrigen)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("pk_PaisSet");

                entity.ToTable("Paises", "RegG");

                entity.Property(e => e.PaisId).HasColumnName("PaisID");

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Pelajes>(entity =>
            {
                entity.HasKey(e => e.PelajeId)
                    .HasName("pk_PelajeSet");

                entity.ToTable("Pelajes", "RegG");

                entity.Property(e => e.PelajeId).HasColumnName("PelajeID");

                entity.Property(e => e.ColorPelaje)
                    .IsRequired()
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<Propietarios>(entity =>
            {
                entity.HasKey(e => e.PropietarioId)
                    .HasName("Pk_Propietarios");

                entity.ToTable("Propietarios", "RegG");

                entity.Property(e => e.PropietarioId).HasColumnName("PropietarioID");

                entity.Property(e => e.NombrePropietario)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RucCi)
                    .IsRequired()
                    .HasColumnName("Ruc_Ci")
                    .HasColumnType("varchar(11)");

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Razas>(entity =>
            {
                entity.HasKey(e => e.RazaId)
                    .HasName("pk_RazaSet");

                entity.ToTable("Razas", "RegG");

                entity.HasIndex(e => e.NombreRaza)
                    .HasName("Index_RazaSet_NombreRaza")
                    .IsUnique();

                entity.Property(e => e.RazaId).HasColumnName("RazaID");

                entity.Property(e => e.NombreRaza)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<RegistroZootecnicos>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Key3");

                entity.ToTable("RegistroZootecnicos", "RegG");

                entity.HasIndex(e => e.GeneracionId)
                    .HasName("IX_RegistroZootecnicos_GeneracionID");

                entity.HasIndex(e => e.GradoSangreId)
                    .HasName("IX_RegistroZootecnicos_GradoSangreID");

                entity.Property(e => e.VacunoId)
                    .HasColumnName("VacunoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.GeneracionId).HasColumnName("GeneracionID");

                entity.Property(e => e.GradoSangreId).HasColumnName("GradoSangreID");

                entity.Property(e => e.Hbp)
                    .HasColumnName("HBP")
                    .HasColumnType("varchar(12)");

                entity.HasOne(d => d.Generacion)
                    .WithMany(p => p.RegistroZootecnicos)
                    .HasForeignKey(d => d.GeneracionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_RegistroZootecnicos-Generaciones");

                entity.HasOne(d => d.GradoSangre)
                    .WithMany(p => p.RegistroZootecnicos)
                    .HasForeignKey(d => d.GradoSangreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_RegistroZootecnicos-GradoSangres");

                entity.HasOne(d => d.Vacuno)
                    .WithOne(p => p.RegistroZootecnicos)
                    .HasForeignKey<RegistroZootecnicos>(d => d.VacunoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pk_VacunoCaracteristicas-RegistroZootecnicos");
            });

            modelBuilder.Entity<VacunoCaracteristicas>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Pk_VacunoCaracteristicas");

                entity.ToTable("VacunoCaracteristicas", "RegG");

                entity.HasIndex(e => e.EstablecimientoId)
                    .HasName("IX_VacunoCaracteristicas_EstablecimientoID");

                entity.HasIndex(e => e.PelajeId)
                    .HasName("IX_VacunoCaracteristicas_PelajeID");

                entity.HasIndex(e => e.RazaId)
                    .HasName("IX_VacunoCaracteristicas_RazaID");

                entity.Property(e => e.VacunoId)
                    .HasColumnName("VacunoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstablecimientoId).HasColumnName("EstablecimientoID");

                entity.Property(e => e.PelajeId).HasColumnName("PelajeID");

                entity.Property(e => e.RazaId).HasColumnName("RazaID");

                entity.HasOne(d => d.Establecimiento)
                    .WithMany(p => p.VacunoCaracteristicas)
                    .HasForeignKey(d => d.EstablecimientoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_VacunoCaracteristicas-Establecimientos");

                entity.HasOne(d => d.Pelaje)
                    .WithMany(p => p.VacunoCaracteristicas)
                    .HasForeignKey(d => d.PelajeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_VacunoCaracteristicas-Pelajes");

                entity.HasOne(d => d.Raza)
                    .WithMany(p => p.VacunoCaracteristicas)
                    .HasForeignKey(d => d.RazaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_VacunoCaracteristicas-Razas");

                entity.HasOne(d => d.Vacuno)
                    .WithOne(p => p.VacunoCaracteristicas)
                    .HasForeignKey<VacunoCaracteristicas>(d => d.VacunoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pk_Vacunos-VacunoCaracteristicas");
            });

            modelBuilder.Entity<VacunoHembras>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Key4");

                entity.ToTable("VacunoHembras", "RegG");

                entity.Property(e => e.VacunoId)
                    .HasColumnName("VacunoID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Vacuno)
                    .WithOne(p => p.VacunoHembras)
                    .HasForeignKey<VacunoHembras>(d => d.VacunoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Pfk_VacunosHembras-Vacunos");
            });

            modelBuilder.Entity<VacunoMachos>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Key5");

                entity.ToTable("VacunoMachos", "RegG");

                entity.Property(e => e.VacunoId)
                    .HasColumnName("VacunoID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Vacuno)
                    .WithOne(p => p.VacunoMachos)
                    .HasForeignKey<VacunoMachos>(d => d.VacunoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Pfk_VacunoMachos-Vacunos");
            });

            modelBuilder.Entity<Vacunos>(entity =>
            {
                entity.HasKey(e => e.VacunoId)
                    .HasName("Key1");

                entity.ToTable("Vacunos", "RegG");

                entity.Property(e => e.VacunoId).HasColumnName("VacunoID");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RpTemporal).HasColumnName("Rp_temporal");
            });
        }
    }
}