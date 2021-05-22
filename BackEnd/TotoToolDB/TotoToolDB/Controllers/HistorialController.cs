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
    public class HistorialController : ControllerBase
    {
        TotoToolDbContext dbContext;
        public HistorialController(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerHistorial([FromRoute] int id)
        {
            try
            {
                HistorialCore historialCore = new HistorialCore(dbContext);
                return Ok(historialCore.ObtenerHistorial(id));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
