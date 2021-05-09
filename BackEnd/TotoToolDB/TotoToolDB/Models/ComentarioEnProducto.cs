using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class ComentarioEnProducto
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public float Valoracion { get; set; }
        public int ProductoId { get; set; }
        public int DocenteId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Docente Docente { get; set; }
    }
}
