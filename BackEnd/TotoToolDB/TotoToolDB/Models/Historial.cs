using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreDelProducto { get; set; }
        public string NombreDelVendedor { get; set; }
        public float MontoExtraido { get; set; }
        public string Paypal { get; set; }
    }
}
