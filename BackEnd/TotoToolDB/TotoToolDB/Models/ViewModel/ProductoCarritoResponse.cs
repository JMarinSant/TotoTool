using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models.ViewModel
{
    public class ProductoCarritoResponse
    {
        public int Id { get; set; }
        public List<ProductoResponse> ProductosEnCarrito { get; set; }
    }

    public class ProductoResponse
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }

    }
}
