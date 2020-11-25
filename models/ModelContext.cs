using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace registration.models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Transporte> Transporte { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "C##GRANDEMAIPO");

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName)
                    .HasColumnName("fullName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.TipoUsuario)
                    .HasColumnName("TIPO_USUARIO")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContratos);

                entity.ToTable("CONTRATO");

                entity.Property(e => e.IdContratos).HasColumnName("ID_CONTRATOS");

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaInicioContrato)
                    .HasColumnName("FECHA_INICIO_CONTRATO")
                    .HasColumnType("DATE");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("DATE");

                entity.Property(e => e.FechaVencimientoContrato)
                    .HasColumnName("FECHA__VENCIMIENTO_CONTRATO")
                    .HasColumnType("DATE");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.CodProducto);

                entity.ToTable("PRODUCT");

                entity.Property(e => e.CodProducto).HasColumnName("COD_PRODUCTO");

                entity.Property(e => e.Calidad)
                    .HasColumnName("CALIDAD")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_USER")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TipoFruta)
                    .HasColumnName("TIPO_FRUTA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("NUMBER");
            });

            modelBuilder.Entity<Transporte>(entity =>
            {
                entity.HasKey(e => e.IdTransporte);

                entity.ToTable("TRANSPORTE");

                entity.Property(e => e.IdTransporte).HasColumnName("ID_TRANSPORTE");

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdVentas).HasColumnName("ID_VENTAS");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioTrans)
                    .IsRequired()
                    .HasColumnName("USUARIO_TRANS")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.IdVentas);

                entity.ToTable("VENTAS");

                entity.Property(e => e.IdVentas).HasColumnName("ID_VENTAS");

                entity.Property(e => e.Direccion)
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdProducto).HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.NombreComprador)
                    .IsRequired()
                    .HasColumnName("NOMBRE_COMPRADOR")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Transferencia)
                    .HasColumnName("TRANSFERENCIA")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("DBOBJECTID_SEQUENCE");

            modelBuilder.HasSequence("ISEQ$$_75619");

            modelBuilder.HasSequence("ISEQ$$_75622");

            modelBuilder.HasSequence("ISEQ$$_79101");

            modelBuilder.HasSequence("ISEQ$$_84428");

            modelBuilder.HasSequence("ISEQ$$_84430");

            modelBuilder.HasSequence("ISEQ$$_84434");

            modelBuilder.HasSequence("S_USUARIO");
        }
    }
}
