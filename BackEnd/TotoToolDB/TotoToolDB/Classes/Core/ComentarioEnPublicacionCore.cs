using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class ComentarioEnPublicacionCore
    {

        TotoToolDbContext dbContext;
        public ComentarioEnPublicacionCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Agregar(ComentarioEnPublicacion comentarioEnPublicacion)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (Validar(comentarioEnPublicacion))
                {
                    dbContext.Add(comentarioEnPublicacion);
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

        public Resultado Actualizar(ComentarioEnPublicacion comentarioEnPublicacion, int id)
        {
            try
            {
                Resultados resultados = new Resultados();
                ComentarioEnPublicacion comentarioEnPublicacionAux = dbContext.ComentarioEnPublicacion.FirstOrDefault(x => x.Id == id);
                if (comentarioEnPublicacionAux != null)
                {
                    if (Validar(comentarioEnPublicacion))
                    {
                        comentarioEnPublicacionAux.Contenido = comentarioEnPublicacion.Contenido;
                        comentarioEnPublicacionAux.Fecha = comentarioEnPublicacion.Fecha;
                        dbContext.Update(comentarioEnPublicacionAux);
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

        public Resultado Eliminar (int id)
        {
            try
            {
                Resultados resultados = new Resultados();
                ComentarioEnPublicacion comentarioEnPublicacion = dbContext.ComentarioEnPublicacion.FirstOrDefault(x => x.Id == id);
                if (comentarioEnPublicacion != null)
                {
                    dbContext.Remove(comentarioEnPublicacion);
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
        private bool Validar(ComentarioEnPublicacion comentarioEnPublicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(comentarioEnPublicacion.Contenido) || comentarioEnPublicacion.Fecha == null)
                    return false;
                return true;

            } catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
