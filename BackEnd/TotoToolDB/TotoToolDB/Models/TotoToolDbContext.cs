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

        public DbSet<ProductoCarrito> ProductoCarrito { get; set; }
        public DbSet<DocenteDocente> DocenteDocente { get; set; }
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
               /* entity.HasOne(e => e.Docente)
                    .WithOne(y => y.Carrito)
                    .HasConstraintName("FK_Carrito_IdDocente");*/
                          
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
               /* entity.HasOne(e => e.Docente)
                    .WithOne(y => y.ComentarioEnProducto)
                    .HasConstraintName("FK_ComentarioEnPublicacion_IdDocente");*/
                entity.HasOne(e => e.Producto)
                    .WithMany(y => y.ComentarioEnProducto)
                    .HasConstraintName("FK_ComentarioEnProducto_IdProducto");
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
                    .HasConstraintName("FK_ComentarioEnPublicacion_IdDocente");
                entity.HasOne(e => e.Revista)
                    .WithMany(y => y.ComentarioEnPublicacion)
                    .HasConstraintName("FK_ComentarioEnPublicacion_IdRevista");
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
                entity.Property(e => e.DocenteASeguirId)
                    .IsRequired();
                entity.Property(e => e.DocenteEnSesionId)
                    .IsRequired();
                entity.HasOne(e => e.DocenteEnSesion)
                     .WithMany(y => y.DocenteEnSesionCollection)
                     .HasConstraintName("FK_IdDocenteEnSesion");
                entity.HasOne(e => e.DocenteASeguir)
                    .WithMany(y => y.DocenteASeguirCollection)
                    .HasConstraintName("FK_IdDocenteASeguir");
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
                  .HasConstraintName("FK_IdHistorialDocente");
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
                entity.Property(e => e.CategoriaId)
                    .IsRequired();
                entity.HasOne(e => e.Categoria)
                    .WithMany(y => y.Producto)
                    .HasConstraintName("FK_IdCategoria");
            });

            modelBuilder.Entity<ProductoCarrito>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.IdCarrito)
                    .IsRequired();
                entity.Property(e => e.IdProducto)
                    .IsRequired();
                entity.HasOne(e => e.Carrito)
                     .WithMany(y => y.ProductoCarrito)
                     .HasConstraintName("FK_ProductoCarrito_IdCarrito");
                entity.HasOne(e => e.Producto)
                    .WithMany(y => y.ProductoCarrito)
                    .HasConstraintName("FK_ProductoCarrito_IdProducto");

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
                    .HasConstraintName("FK_Revista_IdDocente");
            });
        }
    }
}
