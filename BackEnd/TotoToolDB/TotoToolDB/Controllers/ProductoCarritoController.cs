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
    public class ProductoCarritoController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public ProductoCarritoController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] ProductoCarrito productoCarrito)
        {
            try
            {
                ProductoCarritoCore productoCarritoCore = new ProductoCarritoCore(dbContext);
                Resultado resultado = productoCarritoCore.Agregar(productoCarrito);
                if (resultado.codigo == 200)
                    return Ok(resultado.mensaje);
                return StatusCode(resultado.codigo, resultado.mensaje);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

      
        [HttpDelete]
        public IActionResult Eliminar([FromQuery] int id)
        {
            try
            {
                ProductoCarritoCore productoCarritoCore = new ProductoCarritoCore(dbContext);
                Resultado resultado = productoCarritoCore.Eliminar(id);
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
