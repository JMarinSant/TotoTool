using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;
using TotoToolDB.Models.ViewModel;

namespace TotoToolDB.Classes.Core
{
    public class ProductoCarritoCore
    {
        TotoToolDbContext dbContext;
        public ProductoCarritoCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ProductoCarritoResponse> ProductosEnCarrito(int docenteEnSesion)
        {
            try
            {
                var consulta = (from doc in dbContext.Docente
                                join ca in dbContext.Carrito on doc.Id equals ca.DocenteId
                                join prca in dbContext.ProductoCarrito on ca.Id equals prca.CarritoId
                                join pr in dbContext.Producto on prca.ProductoId equals pr.Id
                                where doc.Id == docenteEnSesion
                                select new
                                {
                                    Id = prca.Id,
                                    IdProducto = prca.ProductoId,
                                    Nombre = pr.Nombre,
                                    Descripcion = pr.Descripcion,
                                    Precio = pr.Precio,
                                    Imagen = pr.Imagen
                                }).ToList();

                var estructura = consulta.GroupBy(x => (x.Id)).Select(x => new ProductoCarritoResponse
                {
                    ProductosEnCarrito = x.Select(y => new ProductoResponse
                    {
                        IdProducto = y.IdProducto,
                        Nombre = y.Nombre,
                        Descripcion = y.Descripcion,
                        Precio = y.Precio,
                        Imagen = y.Imagen
                    }).ToList()

                });

                return estructura.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Resultado Agregar(int docenteEnSesion, int idProducto)
        {
            try
            {
                Resultados resultados = new Resultados();
                Carrito carrito = dbContext.Carrito.FirstOrDefault(x => x.DocenteId == docenteEnSesion);

                if(carrito != null)
                {
                    ProductoCarrito productoCarrito = new ProductoCarrito();
                    productoCarrito.CarritoId = carrito.Id;
                    productoCarrito.ProductoId = idProducto;
                    if (Validar(productoCarrito))
                    {
                        dbContext.Add(productoCarrito);
                        dbContext.SaveChanges();
                        return resultados.RegistroExitoso();
                    }
                }
                return resultados.SolicitudSinExito();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Eliminar(int docenteEnSesion, int idProducto)
        {
            try
            {
                Resultados resultados = new Resultados();
                Carrito carrito = dbContext.Carrito.FirstOrDefault(x => x.DocenteId == docenteEnSesion);
                if (carrito != null)
                {
                    ProductoCarrito productoCarrito = dbContext.ProductoCarrito.FirstOrDefault(x => x.CarritoId == carrito.Id && x.ProductoId == idProducto);
                    if (productoCarrito != null)
                    {
                        dbContext.Remove(productoCarrito);
                        dbContext.SaveChanges();
                        return resultados.SolicitudExitosa();
                    }
                }
                return resultados.SolicitudSinExito();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado EliminarTodo(int docenteEnSesion)
        {
            try
            {
                Resultados resultados = new Resultados();
                Carrito carrito = dbContext.Carrito.FirstOrDefault(x => x.DocenteId == docenteEnSesion);   
                if (carrito != null)
                {
                    ProductoCarrito productoCarrito;
                    do
                    {
                        productoCarrito = dbContext.ProductoCarrito.FirstOrDefault(x => x.CarritoId == carrito.Id);
                        if (productoCarrito != null)
                        {
                            dbContext.Remove(productoCarrito);
                            dbContext.SaveChanges();
                        }
                    } while (productoCarrito != null);
                    return resultados.SolicitudExitosa();
                }
                return resultados.SolicitudSinExito();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Validar(ProductoCarrito productoCarrito)
        {
            try
            {
                if(productoCarrito.CarritoId < 0 || productoCarrito.ProductoId < 0 )
                {
                    return false;
                }
                return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
