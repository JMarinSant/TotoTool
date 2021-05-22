using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class ProductoCore
    {
        TotoToolDbContext dbContext;
        public ProductoCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Crear(Producto producto)
        {
            try
            {
                Resultados resultado = new Resultados();
                if(Validar(producto))
                {
                    dbContext.Add(producto);
                    dbContext.SaveChanges();
                    return resultado.ProcedimientoExitoso();
                }
                return resultado.DatosInexistentes();   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Actualizar(Producto producto, int docenteEnSesion) {
            try
            {
                Resultados resultado = new Resultados();
                Producto productoAux = dbContext.Producto.FirstOrDefault(x => x.Id == producto.Id && x.DocenteId == docenteEnSesion);
                if (productoAux != null)
                {
                    if (Validar(producto))
                    {
                        productoAux.Nombre = producto.Nombre;
                        productoAux.Descripcion = producto.Descripcion;
                        productoAux.Precio = producto.Precio;
                        productoAux.Imagen = producto.Imagen;
                        productoAux.Categoria = producto.Categoria;
                        productoAux.DocenteId = docenteEnSesion;
                        dbContext.Update(productoAux);
                        dbContext.SaveChanges();
                        return resultado.ProcedimientoExitoso();
                    }
                }
                return resultado.DatosInexistentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Eliminar(int id, int docenteEnSesion)
        {
            try
            {
                Resultados resultados = new Resultados();
                Producto producto = dbContext.Producto.FirstOrDefault(x => x.Id == id && x.DocenteId == docenteEnSesion);
                if (producto != null)
                {
                    dbContext.Remove(producto);
                    dbContext.SaveChanges();
                    return resultados.SolicitudExitosa();
                }
                return resultados.SolicitudSinExito();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerProductosDeUnUsuario(int id)
        {
            try
            {
                return dbContext.Producto.Where(x => x.DocenteId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerProductosPorNombre(string nombre)
        {
            try
            {
                return dbContext.Producto.Where(x => x.Nombre == nombre).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> ObtenerProductosPorCategoria(int idCategoria)
        {
            try
            {
                return dbContext.Producto.Where(x => x.CategoriaId == idCategoria).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool Validar(Producto producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto.Nombre) || string.IsNullOrEmpty(producto.Descripcion) || producto.Precio < 0 ||
                    string.IsNullOrEmpty(producto.Imagen) || producto.CategoriaId < 0 || producto.DocenteId == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
