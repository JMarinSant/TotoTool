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
    public class DocenteController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public DocenteController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult ObtenerDocente(string correoElectronico, string contraseña)
        {
            try
            {
                DocenteCore docenteCore = new DocenteCore(dbContext);
                List<Docente> docente = new List<Docente>();
                Resultado resultado = docenteCore.ObtenerDocente(correoElectronico, contraseña, docente);
                if(resultado.codigo == 200)
                    return Ok(docente);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Docente docente)
        {
            try
            {
                DocenteCore docenteCore = new DocenteCore(dbContext);
                Resultado resultado = docenteCore.Crear(docente);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar([FromBody] Docente docente, [FromRoute] int id)
        {
            try
            {
                DocenteCore docenteCore = new DocenteCore(dbContext);
                Resultado resultado = docenteCore.Actualizar(docente, id);
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
