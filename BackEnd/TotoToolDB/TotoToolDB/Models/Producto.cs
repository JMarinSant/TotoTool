using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public int CategoriaId { get; set; }
        public int DocenteId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Docente Docente { get; set; }
        public virtual ICollection<ProductoCarrito> ProductoCarrito { get; set; }
        public virtual ICollection<ComentarioEnProducto> ComentarioEnProducto { get; set; }
    }
}
