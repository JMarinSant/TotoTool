using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Categoria> GetAll()
        {
            List<Categoria> categoria = dbContext.Categoria.ToList();
            return categoria;
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
