using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class ComentarioEnPublicacion
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdDocente { get; set; }
        public int IdRevista { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual Revista Revista { get; set; }
    }
}
