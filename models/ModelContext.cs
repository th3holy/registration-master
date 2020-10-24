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

        public virtual DbSet<Contrato> Contrato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=xe)));Persist Security Info=True;User Id=c##grandemaipo;Password=1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "C##GRANDEMAIPO");

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

                entity.Property(e => e.Run)
                    .HasColumnName("RUN")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("ISEQ$$_75619");

            modelBuilder.HasSequence("ISEQ$$_75622");

            modelBuilder.HasSequence("ISEQ$$_79101");

            modelBuilder.HasSequence("S_USUARIO");
        }
    }
}
