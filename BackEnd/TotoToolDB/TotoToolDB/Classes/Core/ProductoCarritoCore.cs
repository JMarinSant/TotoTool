using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class ProductoCarritoCore
    {
        TotoToolDbContext dbContext;
        public ProductoCarritoCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Agregar(ProductoCarrito productoCarrito)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (Validar(productoCarrito))
                {
                    dbContext.Add(productoCarrito);
                    dbContext.SaveChanges();
                    return resultados.RegistroExitoso();
                }
                return resultados.CorreoElectronicoYaExistente();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Eliminar(int id)
        {
            try
            {
                Resultados resultados = new Resultados();
                ProductoCarrito productoCarrito = dbContext.ProductoCarrito.FirstOrDefault(x => x.Id == id);
                if (productoCarrito != null)
                {
                    dbContext.Remove(productoCarrito);
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

        private bool Validar(ProductoCarrito productoCarrito)
        {
            try
            {
                if(productoCarrito.IdCarrito < 0 || productoCarrito.IdProducto < 0 )
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
