using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class ProductoCarrito
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdCarrito { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Carrito Carrito { get; set; }
    }
}
