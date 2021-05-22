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
    public class ComentarioEnProductoController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public ComentarioEnProductoController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] ComentarioEnProducto comentarioEnProducto)
        {
            try
            {
                ComentarioEnProductoCore comentarioEnPublicacionCoreCore = new ComentarioEnProductoCore(dbContext);
                Resultado resultado = comentarioEnPublicacionCoreCore.Crear(comentarioEnProducto);
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
        public IActionResult ComentarioEnProducto([FromQuery] int idProducto)
        {
            try
            {
                ComentarioEnProductoCore comentarioEnPublicacionCoreCore = new ComentarioEnProductoCore(dbContext);
                return Ok(comentarioEnPublicacionCoreCore.ComentarioEnProducto(idProducto));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{docenteEnSesion}")]
        public IActionResult Actualizar([FromBody] ComentarioEnProducto comentarioEnProducto, [FromQuery] int id, [FromRoute] int docenteEnSesion)
        {
            try
            {
                ComentarioEnProductoCore comentarioEnPublicacionCoreCore = new ComentarioEnProductoCore(dbContext);
                Resultado resultado = comentarioEnPublicacionCoreCore.Actualizar(comentarioEnProducto, id, docenteEnSesion);
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
                ComentarioEnProductoCore comentarioEnPublicacionCoreCore = new ComentarioEnProductoCore(dbContext);
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
