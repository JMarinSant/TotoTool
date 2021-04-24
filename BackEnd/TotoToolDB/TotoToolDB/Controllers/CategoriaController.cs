using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TotoToolDB.Classes.Core;
using TotoToolDB.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TotoToolDB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        TotoToolDbContext dbContext;

        public CategoriaController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                CategoriaCore categoriaCore = new CategoriaCore(dbContext);
                return Ok(categoriaCore.GetAll());
            } catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]Categoria categoria)
        {
            try
            {
                CategoriaCore categoriaCore = new CategoriaCore(dbContext);
                categoriaCore.Create(categoria);
                return Ok("Categoria agregada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Categoria categoria,[FromRoute] int id)
        {
            try
            {
                CategoriaCore categoriaCore = new CategoriaCore(dbContext);
                categoriaCore.Update(categoria, id);
                return Ok("Categoria actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                CategoriaCore categoriaCore = new CategoriaCore(dbContext);
                //categoriaCore.Update(categoria, id);
                return Ok("Categoria actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
