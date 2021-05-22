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
    public class ProductoController : ControllerBase
    {

        TotoToolDbContext dbContext;
        public ProductoController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Producto producto)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                Resultado resultado = productoCore.Crear(producto);
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
        public IActionResult Actualizar([FromBody] Producto producto, [FromRoute] int docenteEnSesion)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                Resultado resultado = productoCore.Actualizar(producto, docenteEnSesion);
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
        public IActionResult ObtenerMisProductos([FromRoute] int docenteEnSesion)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                return Ok(productoCore.ObtenerProductosDeUnUsuario(docenteEnSesion));         
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult ProductosPorUsuario([FromQuery] int docente)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                return Ok(productoCore.ObtenerProductosDeUnUsuario(docente));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult BusquedaPorCategoria([FromQuery] int categoria)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                return Ok(productoCore.ObtenerProductosPorCategoria(categoria));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        public IActionResult BusquedaPorNombre([FromQuery] string nombre)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                return Ok(productoCore.ObtenerProductosPorNombre(nombre));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{docenteEnSesion}")]
        public IActionResult Eliminar([FromRoute] int docenteEnSesion, [FromQuery] int id)
        {
            try
            {
                ProductoCore productoCore = new ProductoCore(dbContext);
                Resultado resultado = productoCore.Eliminar(id, docenteEnSesion);
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
