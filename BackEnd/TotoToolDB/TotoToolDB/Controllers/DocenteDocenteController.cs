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
    public class DocenteDocenteController : ControllerBase
    {

        TotoToolDbContext dbContext;
        public DocenteDocenteController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ObtenerListaDeDocentesSeguidos([FromQuery] int docenteEnSesion)
        {
            try
            {
                DocenteDocenteCore docenteDocenteCore = new DocenteDocenteCore(dbContext);          
                return Ok(docenteDocenteCore.ObtenerListaDeDocentesSeguidos(docenteEnSesion));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult SeguirDocente([FromBody]DocenteDocente docenteDocente)
        {
            try
            {
                DocenteDocenteCore docenteDocenteCore = new DocenteDocenteCore(dbContext);
                Resultado resultado = docenteDocenteCore.SeguirDocente(docenteDocente);
                if(resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]

        public IActionResult DejarDeSeguir([FromQuery] int docenteEnSesion, [FromQuery] int docenteASeguir)
        {
            try
            {
                DocenteDocenteCore docenteDocenteCore = new DocenteDocenteCore(dbContext);
                Resultado resultado = docenteDocenteCore.DejarDeSeguir(docenteEnSesion, docenteASeguir);
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
