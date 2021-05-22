using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TotoToolDB.Classes.Core;
using TotoToolDB.Classes.Error;
using TotoToolDB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TotoToolDB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComentarioEnPublicacionController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public ComentarioEnPublicacionController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] ComentarioEnPublicacion comentarioEnPublicacion)
        {
            try
            {
                ComentarioEnPublicacionCore comentarioEnPublicacionCoreCore = new ComentarioEnPublicacionCore(dbContext);
                Resultado resultado = comentarioEnPublicacionCoreCore.Agregar(comentarioEnPublicacion);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult ComentarioEnPublicacion([FromQuery] int idRevista)
        {
            try
            {
                ComentarioEnPublicacionCore comentarioEnPublicacionCoreCore = new ComentarioEnPublicacionCore(dbContext);
                return Ok(comentarioEnPublicacionCoreCore.ComentarioEnPublicacion(idRevista));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{docenteEnSesion}")]
        public IActionResult Actualizar([FromBody] ComentarioEnPublicacion comentarioEnPublicacion, [FromQuery] int id,[FromRoute] int docenteEnSesion)
        {
            try
            {
                ComentarioEnPublicacionCore comentarioEnPublicacionCoreCore = new ComentarioEnPublicacionCore(dbContext);
                Resultado resultado = comentarioEnPublicacionCoreCore.Actualizar(comentarioEnPublicacion, id, docenteEnSesion);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{docenteEnSesion}")]
        public IActionResult Eliminar([FromRoute] int id, int docenteEnSesion)
        {
            try
            {
                ComentarioEnPublicacionCore comentarioEnPublicacionCoreCore = new ComentarioEnPublicacionCore(dbContext);
                Resultado resultado = comentarioEnPublicacionCoreCore.Eliminar(id, docenteEnSesion);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
