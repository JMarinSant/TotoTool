using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class TotoToolDbContext : DbContext
    {
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<ComentarioEnPublicacion> ComentarioEnPublicacion { get; set; }
        public DbSet<ComentarioEnProducto> ComentarioEnProducto { get; set; }
        public DbSet<Docente> Docente { get; set; }
        public DbSet<Historial> Historial { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Revista> Revista { get; set; }

        public TotoToolDbContext() { }
        public TotoToolDbContext(DbContextOptions<TotoToolDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdDocente)
                    .IsRequired();
                entity.Property(e=> e.Estado)
                    .IsRequired();
                entity.HasOne(e => e.Docente)
                    .WithOne(y => y.Carrito)
                    .HasForeignKey("FK_Carrito_IdDocente");
                          
            });

        
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                    .IsRequired();               
            });

            modelBuilder.Entity<ComentarioEnProducto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();
                entity.Property(e => e.Hora)
                    .HasColumnType("datetime")
                    .IsRequired();
                entity.Property(e => e.Valoracion)
                    .IsRequired();
                entity.Property(e => e.IdProducto)
                    .IsRequired();
                entity.Property(e => e.IdDocente)
                    .IsRequired();
                entity.HasOne(e => e.Docente)
                    .WithOne(y => y.ComentarioEnProducto)
                    .HasForeignKey("FK_ComentarioEnPublicacion_IdDocente");
                entity.HasOne(e => e.Producto)
                    .WithMany(y => y.ComentarioEnProducto)
                    .HasForeignKey("FK_ComentarioEnProducto_IdProducto");
            });

            modelBuilder.Entity<ComentarioEnPublicacion>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Contenido)
                     .HasMaxLength(255)
                     .IsRequired();
                entity.Property(e => e.Fecha)
                     .HasColumnType("datetime")
                     .IsRequired();
                entity.Property(e => e.IdDocente)
                     .IsRequired();
                entity.Property(e => e.IdRevista)
                     .IsRequired();

                entity.HasOne(e => e.Docente)
                    .WithMany(y => y.ComentarioEnPublicacion)
                    .HasForeignKey("FK_ComentarioEnPublicacion_IdDocente");
                entity.HasOne(e => e.Revista)
                    .WithMany(y => y.ComentarioEnPublicacion)
                    .HasForeignKey("FK_ComentarioEnPublicacion_IdRevista");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                     .HasMaxLength(255)
                     .IsRequired();
                entity.Property(e => e.CorreoElectronico)
                     .HasMaxLength(150)
                     .IsRequired();
                entity.Property(e => e.Contraseña)
                     .HasMaxLength(50)
                     .IsRequired();
                entity.Property(e => e.Direccion)
                     .HasMaxLength(255)
                     .IsRequired(false);
                entity.Property(e => e.Ciudad)
                     .HasMaxLength(100)
                     .IsRequired(false);
                entity.Property(e => e.EntidadFederativa)
                     .HasMaxLength(75)
                     .IsRequired(false);
                entity.Property(e => e.Pais)
                     .HasMaxLength(50)
                     .IsRequired(false);
                entity.Property(e => e.Paypal)
                     .HasMaxLength(50)
                     .IsRequired(false);
                entity.Property(e => e.Telefono)
                     .IsRequired(false);
            });

            modelBuilder.Entity<DocenteDocente>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdDocenteASeguir)
                    .IsRequired();
                entity.Property(e => e.IdDocenteEnSesion)
                    .IsRequired();
                entity.HasOne(e => e.DocenteEnSesion)
                     .WithMany(y => y.DocenteEnSesionCollection)
                     .HasForeignKey("FK_IdDocenteEnSesion");
                entity.HasOne(e => e.DocenteASeguir)
                    .WithMany(y => y.DocenteASeguirCollection)
                    .HasForeignKey("FK_IdDocenteASeguir");
            });

            modelBuilder.Entity<Historial>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .IsRequired();
                entity.Property(e => e.NombreDelProducto)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.NombreDelVendedor)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.MontoExtraido)
                    .HasColumnType("float")
                    .IsRequired();
                entity.Property(e => e.Paypal)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.HasOne(e => e.Docente)
                  .WithMany(y => y.Historial)
                  .HasForeignKey("FK_IdHistorialDocente");
            });

            modelBuilder.Entity<Producto>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(e => e.Descripcion)
                    .IsRequired();
                entity.Property(e => e.Precio)
                    .HasColumnType("float")
                    .IsRequired();
                entity.Property(e => e.Imagen)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.IdCategoria)
                    .IsRequired();
                entity.HasOne(e => e.Categoria)
                    .WithMany(y => y.Producto)
                    .HasForeignKey("FK_IdCategoria");
            });

            modelBuilder.Entity<ProductoCarrito>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdCarrito)
                    .IsRequired();
                entity.Property(e => e.IdProducto)
                    .IsRequired();
                entity.HasOne(e => e.Carrito)
                     .WithMany(y => y.ProductoCarrito)
                     .HasForeignKey("FK_ProductoCarrito_IdCarrito");
                entity.HasOne(e => e.Producto)
                    .WithMany(y => y.ProductoCarrito)
                    .HasForeignKey("FK_ProductoCarrito_IdProducto");

            });

            modelBuilder.Entity<Revista>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Contenido)
                    .HasMaxLength(255)
                    .IsRequired();
                entity.Property(e => e.Imagen)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(e => e.IdDocente)
                    .IsRequired();
                entity.HasOne(e => e.Docente)
                    .WithMany(y => y.Revista)
                    .HasForeignKey("FK_Revista_IdDocente");
            });
        }
    }
}
