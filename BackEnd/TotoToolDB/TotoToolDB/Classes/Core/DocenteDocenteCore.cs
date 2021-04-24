using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class DocenteDocenteCore
    {

        TotoToolDbContext dbContext;
        public DocenteDocenteCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado SeguirDocente(DocenteDocente docenteDocente)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (ValidarIds(docenteDocente.DocenteEnSesionId, docenteDocente.DocenteASeguirId))
                {
                    dbContext.Add(docenteDocente);
                    dbContext.SaveChanges();
                    return resultados.SolicitudExitosa();
                }
                return resultados.SolicitudSinExito();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarIds(int id1, int id2)
        {
            Docente docente = dbContext.Docente.FirstOrDefault(x => x.Id == id1);
            if (docente != null)
            {
                docente = dbContext.Docente.FirstOrDefault(x => x.Id == id2);
                DocenteDocente docenteDocente = dbContext.DocenteDocente.FirstOrDefault(x => x.DocenteEnSesionId == id1 && x.DocenteASeguirId == id2);
                if (docente != null && docenteDocente == null && id1 != id2)
                    return true;
                return false;
            }
            return false;
        }

        public Resultado DejarDeSeguir(int docenteEnSesion, int docenteASeguir)
        {
            try
            {
                Resultados resultados = new Resultados();
                DocenteDocente docenteDocente = dbContext.DocenteDocente.FirstOrDefault(x => x.DocenteEnSesionId == docenteEnSesion && x.DocenteASeguirId == docenteASeguir);
                if(docenteDocente != null)
                {
                    dbContext.Remove(docenteDocente);
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

        public List<DocenteDocente> ObtenerListaDeDocentesSeguidos(int docenteEnSesion)
        {
            try
            {
                return  dbContext.DocenteDocente.Where(x => x.DocenteEnSesionId == docenteEnSesion).ToList();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

