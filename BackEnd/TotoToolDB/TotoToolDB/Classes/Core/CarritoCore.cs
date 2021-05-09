using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class CarritoCore
    {

        TotoToolDbContext dbContext;
        public CarritoCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Actualizar(Carrito carrito, int id)
        {
            try
            {
                Resultados resultados = new Resultados();

                if (Validar(carrito))
                {
                    Carrito carritoAux = dbContext.Carrito.FirstOrDefault(x => x.Id == id);
                    if(carritoAux != null)
                    {
                        carritoAux.Estado = carrito.Estado;
                        dbContext.Update(carritoAux);
                        dbContext.SaveChanges();
                        return resultados.ActualizacionExitosa();
                    }
                }
                return resultados.SolicitudSinExito();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        private bool Validar(Carrito carrito)
        {
            try
            {
                if(carrito.Estado == false)
                {
                    return false;
                }
                return true;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}