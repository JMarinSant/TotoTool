using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class RevistaCore
    {
        TotoToolDbContext dbContext;
        public RevistaCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Agregar(Revista revista)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (Validar(revista))
                {
                    dbContext.Add(revista);
                    dbContext.SaveChanges();
                    return resultados.RegistroExitoso();
                }
                return resultados.CorreoElectronicoYaExistente();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Actualizar(Revista revista, int id)
        {
            try
            {
                Resultados resultados = new Resultados();
                Revista revistaAux = dbContext.Revista.FirstOrDefault(x => x.Id == id);
                if (revistaAux != null)
                {
                    if (Validar(revista))
                    {
                        revistaAux.Contenido = revista.Contenido;
                        revistaAux.Imagen = revista.Imagen;
                        dbContext.Update(revista);
                        dbContext.SaveChanges();
                        return resultados.RegistroExitoso();
                    }
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
                Revista revista = dbContext.Revista.FirstOrDefault(x => x.Id == id);
                if (revista != null)
                {
                    dbContext.Remove(revista);
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

        private bool Validar(Revista revista)
        {
            try
            {
                if (string.IsNullOrEmpty(revista.Contenido) || string.IsNullOrEmpty(revista.Imagen))
                    return false;
                return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
