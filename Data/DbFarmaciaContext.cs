using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaDeFarmacia.Models
{
    public partial class DbFarmaciaContext : DbContext
    {
        public DbFarmaciaContext()
        {
        }

        public DbFarmaciaContext(DbContextOptions<DbFarmaciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaMedicamento> CategoriaMedicamento { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<DetalleCompras> DetalleCompras { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Medicamentos> Medicamentos { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<PresentacionMedicamento> PresentacionMedicamento { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=ENDERSSONMENDOZ; initial catalog=DbFarmacia; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("Categoria_Medicamento");

                entity.Property(e => e.IdCategoria).HasColumnName("id_Categoria");

                entity.Property(e => e.DescripcionCategoria)
                    .IsRequired()
                    .HasColumnName("descripcion_Categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasColumnName("nombre_Categoria")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.CodCompras);

                entity.Property(e => e.CodCompras).HasColumnName("cod_Compras");

                entity.Property(e => e.FechaCompra)
                    .HasColumnName("fecha_Compra")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdLaboratorio).HasColumnName("Id_Laboratorio");

                entity.Property(e => e.IdPersonal).HasColumnName("Id_Personal");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdLaboratorioNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Laboratorio");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Compras_Personal");
            });

            modelBuilder.Entity<DetalleCompras>(entity =>
            {
                entity.HasKey(e => e.IdDetalleCompra);

                entity.ToTable("detalle_Compras");

                entity.Property(e => e.IdDetalleCompra).HasColumnName("id_DetalleCompra");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodCompras).HasColumnName("cod_Compras");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.CodComprasNavigation)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.CodCompras)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Detalle_Compras_Compras");
            });

            modelBuilder.Entity<DetalleVenta>(entity =>
            {
                entity.HasKey(e => e.CodDetalleVenta);

                entity.ToTable("detalle_Venta");

                entity.Property(e => e.CodDetalleVenta).HasColumnName("cod_DetalleVenta");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasColumnName("cliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodVentas).HasColumnName("cod_Ventas");

                entity.Property(e => e.Descuento).HasColumnName("descuento");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.CodVentasNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.CodVentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_Venta_Ventas");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario);

                entity.Property(e => e.IdInventario).HasColumnName("id_Inventario");

                entity.Property(e => e.CostoPreventa).HasColumnName("Costo_Preventa");

                entity.Property(e => e.FechaEntradaInventario)
                    .HasColumnName("fechaEntrada_Inventario")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCompra).HasColumnName("id_Compra");

                entity.Property(e => e.IdLaboratorio).HasColumnName("id_Laboratorio");

                entity.Property(e => e.IdPresentacionMed).HasColumnName("id_Presentacion_Med");

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasColumnName("nombreComercial")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioPreventa).HasColumnName("Precio_Preventa");

                entity.Property(e => e.StockActual).HasColumnName("Stock_Actual");

                entity.Property(e => e.StockInicial).HasColumnName("Stock_Inicial");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Compras");

                entity.HasOne(d => d.IdLaboratorioNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdLaboratorio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Laboratorio");

                entity.HasOne(d => d.IdPresentacionMedNavigation)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.IdPresentacionMed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario_Presentacion_Medicamento");
            });

            modelBuilder.Entity<Laboratorio>(entity =>
            {
                entity.HasKey(e => e.IdLaboratorio);

                entity.Property(e => e.IdLaboratorio).HasColumnName("id_laboratorio");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailLab)
                    .IsRequired()
                    .HasColumnName("email_Lab")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreLaboratorio)
                    .IsRequired()
                    .HasColumnName("nombre_Laboratorio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PoliticasDeVencimiento)
                    .IsRequired()
                    .HasColumnName("politicasDeVencimiento")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoLaboratorio)
                    .IsRequired()
                    .HasColumnName("telefono_Laboratorio")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicamentos>(entity =>
            {
                entity.HasKey(e => e.CodMedicamentos);

                entity.Property(e => e.CodMedicamentos).HasColumnName("cod_Medicamentos");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdCategoria).HasColumnName("id_Categoria");

                entity.Property(e => e.IdInventario).HasColumnName("id_Inventario");

                entity.Property(e => e.NombreGenerico)
                    .IsRequired()
                    .HasColumnName("nombreGenerico")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ViaAdministracion)
                    .IsRequired()
                    .HasColumnName("viaAdministracion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicamentos_Categoria_Medicamento");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicamentos_Inventario");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal);

                entity.Property(e => e.IdPersonal).HasColumnName("id_Personal");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PresentacionMedicamento>(entity =>
            {
                entity.HasKey(e => e.IdPresentacionMed);

                entity.ToTable("Presentacion_Medicamento");

                entity.Property(e => e.IdPresentacionMed).HasColumnName("id_PresentacionMed");

                entity.Property(e => e.ConcentracionMgMl)
                    .HasColumnName("concentracion(mg/ml)")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormaPresentacion)
                    .IsRequired()
                    .HasColumnName("formaPresentacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubUnidades)
                    .IsRequired()
                    .HasColumnName("subUnidades")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadEnvasado)
                    .IsRequired()
                    .HasColumnName("unidadEnvasado")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnidadMedidaPresentacion)
                    .IsRequired()
                    .HasColumnName("unidadMedidaPresentacion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unidades)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.CodVentas);

                entity.Property(e => e.CodVentas).HasColumnName("cod_Ventas");

                entity.Property(e => e.FechaVentas)
                    .HasColumnName("fecha_Ventas")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdInventario).HasColumnName("id_Inventario");

                entity.Property(e => e.IdPersonal).HasColumnName("id_Personal");

                entity.Property(e => e.Iva).HasColumnName("iva");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdInventario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Inventario");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_Personal");
            });
        }
    }
}
