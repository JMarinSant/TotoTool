using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class DocenteCore
    {
        TotoToolDbContext dbContext;
        public DocenteCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public Resultado ObtenerDocente(string correoElectronico, string contraseña, List<Docente> docente)
        {
            try
            {
                docente.Add(dbContext.Docente.FirstOrDefault(x => x.CorreoElectronico == correoElectronico));
                Resultados resultados = new Resultados();
                if (docente.First() != null)
                {
                    if (docente.First().Contraseña == contraseña)
                    {
                        return resultados.RegistroExitoso();
                    }
                    return resultados.ContraseñaIncorrecta();
                }
                return resultados.CorreoElectronicoNoRegistrado();
            } catch(Exception ex)
            {
                throw ex;
            }
        }
        public Resultado Crear(Docente docente)
        {
            try
            {
                Resultados resultados = new Resultados();
                if (ValidarCorreoElectronicoUnico(docente))
                {
                    bool validarDocente = Validar(docente);
                    if (validarDocente)
                    {
                        dbContext.Add(docente);
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

        private bool ValidarCorreoElectronicoUnico(Docente docente)
        {
            Docente docenteAux = dbContext.Docente.FirstOrDefault(x => x.CorreoElectronico == docente.CorreoElectronico);
            if (docenteAux == null)
                return true;
            return false;
        }


        public bool Validar(Docente docente)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(docente.Nombre) || docente.Nombre.Length > 255 ||
                    string.IsNullOrEmpty(docente.CorreoElectronico) || docente.CorreoElectronico.Length > 150 ||
                    string.IsNullOrEmpty(docente.Contraseña) || docente.Contraseña.Length > 50 ||
                    (docente.Direccion != null && docente.Direccion.Length > 255) ||
                    (docente.Ciudad != null && docente.Ciudad.Length > 100) ||
                    (docente.EntidadFederativa != null && docente.EntidadFederativa.Length > 75) ||
                    (docente.Pais != null && docente.Pais.Length > 50) ||
                    (docente.Paypal != null && docente.Paypal.Length > 50) ||
                    (docente.Telefono != null && docente.Telefono < 1000000000))
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

        public Resultado Actualizar(Docente docente, int id)
        {
            try
            {
                Resultados resultados  = new Resultados();
                Docente docenteAux = dbContext.Docente.FirstOrDefault(x => x.Id == id);
                if (docenteAux != null)
                {
                    if (docenteAux.CorreoElectronico != docente.CorreoElectronico)
                    {
                        if (ValidarCorreoElectronicoUnico(docente))
                        {
                            bool validarDocente = Validar(docente);
                            if (validarDocente)
                            {
                                docenteAux.Nombre = docente.Nombre;
                                docenteAux.CorreoElectronico = docente.CorreoElectronico;
                                docenteAux.Contraseña = docente.Contraseña;
                                docenteAux.Direccion = docente.Direccion;
                                docenteAux.Ciudad = docente.Ciudad;
                                docenteAux.EntidadFederativa = docente.EntidadFederativa;
                                docenteAux.Pais = docente.Pais;
                                docenteAux.Paypal = docente.Paypal;
                                docenteAux.Telefono = docente.Telefono;
                                dbContext.Update(docenteAux);
                                dbContext.SaveChanges();
                                return resultados.ActualizacionExitosa();
                            }
                        }
                        else
                            return resultados.CorreoElectronicoYaExistente();
                    }
                    else
                    {
                        bool validarDocente = Validar(docente);
                        if (validarDocente)
                        {
                            docenteAux.Nombre = docente.Nombre;
                            docenteAux.CorreoElectronico = docente.CorreoElectronico;
                            docenteAux.Contraseña = docente.Contraseña;
                            docenteAux.Direccion = docente.Direccion;
                            docenteAux.Ciudad = docente.Ciudad;
                            docenteAux.EntidadFederativa = docente.EntidadFederativa;
                            docenteAux.Pais = docente.Pais;
                            docenteAux.Paypal = docente.Paypal;
                            docenteAux.Telefono = docente.Telefono;
                            dbContext.Update(docenteAux);
                            dbContext.SaveChanges();
                            return resultados.ActualizacionExitosa();
                        }
                    }
                }
                return resultados.DatosInexistentes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
