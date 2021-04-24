using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{

    public class HistorialCore
    {
        TotoToolDbContext dbContext;
        public HistorialCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public  List<Historial> ObtenerHistorial(int docenteEnSesion)
        {
            try
            {
                return dbContext.Historial.Where(x => x.HistorialDocenteId == docenteEnSesion).ToList();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Crear(Historial historial)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (Validar(historial))
                {
                    dbContext.Add(historial);
                    dbContext.SaveChanges();
                    return resultados.SolicitudExitosa();
                }
                return resultados.SolicitudSinExito();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool Validar(Historial historial)
        {
            if(historial.Fecha == null || string.IsNullOrEmpty(historial.NombreDelProducto) || string.IsNullOrEmpty(historial.NombreDelVendedor) ||
                historial.MontoExtraido < 0 || string.IsNullOrEmpty(historial.Paypal) || historial.HistorialDocenteId < 0)
            {
                return false;
            }
            return true;
        }
    }

}
