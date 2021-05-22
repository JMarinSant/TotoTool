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
    }

}
