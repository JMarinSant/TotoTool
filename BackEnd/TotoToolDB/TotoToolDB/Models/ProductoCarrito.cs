using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class ProductoCarrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CarritoId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Carrito Carrito { get; set; }
    }
}
