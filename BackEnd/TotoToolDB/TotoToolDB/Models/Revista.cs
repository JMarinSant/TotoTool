using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class Revista
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public string Imagen { get; set; }
        public int IdDocente { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual ICollection<ComentarioEnPublicacion> ComentarioEnPublicacion { get; set; }
    }
}
