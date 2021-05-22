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
    public class RevistaController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public RevistaController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("{id}")]
        public IActionResult Crear([FromRoute] int id, [FromBody] Revista revista)
        {
            try
            {
                RevistaCore revistaCore = new RevistaCore(dbContext);
                Resultado resultado = revistaCore.Agregar(revista, id);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{docenteEnSesion}")]
        public IActionResult Actualizar([FromBody] Revista revista, [FromQuery] int id, [FromRoute] int docenteEnSesion)
        {
            try
            {
                RevistaCore RevistaCore = new RevistaCore(dbContext);
                Resultado resultado = RevistaCore.Actualizar(revista, id, docenteEnSesion);
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
        public IActionResult Eliminar([FromQuery] int id, [FromRoute] int docenteEnSesion)
        {
            try
            {
                RevistaCore RevistaCore = new RevistaCore(dbContext);
                Resultado resultado = RevistaCore.Eliminar(id, docenteEnSesion);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{docenteEnSesion}")]
        public IActionResult ObtenerMisRevistas([FromRoute] int docenteEnSesion)
        {
            try
            {
                RevistaCore RevistaCore = new RevistaCore(dbContext);
                return Ok(RevistaCore.ObtenerRevista(docenteEnSesion));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult RevistasDeUnUsuario([FromQuery] int id)
        {
            try
            {
                RevistaCore RevistaCore = new RevistaCore(dbContext);
                return Ok(RevistaCore.ObtenerRevista(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}