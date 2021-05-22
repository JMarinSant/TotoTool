using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class ComentarioEnProductoCore
    {

        TotoToolDbContext dbContext;
        public ComentarioEnProductoCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Resultado Crear(ComentarioEnProducto comentarioEnProducto)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (Validar(comentarioEnProducto))
                {
                    dbContext.Add(comentarioEnProducto);
                    dbContext.SaveChanges();
                    return resultados.SolicitudExitosa();
                }
                return resultados.SolicitudSinExito();
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ComentarioEnProducto> ComentarioEnProducto(int id)
        {
            try
            {
                return dbContext.ComentarioEnProducto.Where(x => x.ProductoId == id).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Resultado Actualizar(ComentarioEnProducto comentarioEnProducto, int id, int docenteEnSesion)
        {
            try
            {
                Resultados resultados = new Resultados();
                ComentarioEnProducto comentarioEnProductoAux = dbContext.ComentarioEnProducto.FirstOrDefault(x => x.Id == id && x.DocenteId == docenteEnSesion);
                if (comentarioEnProducto != null)
                {
                    if (Validar(comentarioEnProducto))
                    {
                        comentarioEnProductoAux.Contenido = comentarioEnProducto.Contenido;
                       // comentarioEnProductoAux.Fecha = comentarioEnProducto.Fecha;
                       // comentarioEnProductoAux.Hora = comentarioEnProducto.Hora;
                        comentarioEnProductoAux.Valoracion = comentarioEnProducto.Valoracion;
                        dbContext.Update(comentarioEnProductoAux);
                        dbContext.SaveChanges();
                        return resultados.DatosInexistentes();
                    }
                }
                return resultados.DatosInexistentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Resultado Eliminar(int id, int docenteEnSesion) {
            try
            {
                Resultados resultados = new Resultados();
                ComentarioEnProducto comentarioEnProducto = dbContext.ComentarioEnProducto.FirstOrDefault(x => x.Id == id && x.DocenteId == docenteEnSesion);
                if (comentarioEnProducto != null)
                {
                    dbContext.Remove(comentarioEnProducto);
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

        private bool Validar(ComentarioEnProducto comentarioEnProducto)
        {
            try
            {
                if (string.IsNullOrEmpty(comentarioEnProducto.Contenido) || comentarioEnProducto.Fecha == null || comentarioEnProducto.Hora == null ||
                    comentarioEnProducto.Valoracion < 0)
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
