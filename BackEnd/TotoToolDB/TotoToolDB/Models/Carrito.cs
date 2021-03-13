using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public int IdDocente { get; set; }
        public bool Estado { get; set; }

        public virtual Docente Docente { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
