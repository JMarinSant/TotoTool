using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class DocenteDocente
    {
        public int Id { get; set; }
        public int DocenteEnSesionId { get; set; }
        public int DocenteASeguirId { get; set; }

        public virtual Docente DocenteEnSesion { get; set; }
        public virtual Docente DocenteASeguir { get; set; }
    }
}
