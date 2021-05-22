using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotoToolDB.Models
{
    public class Docente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string EntidadFederativa { get; set; }
        public string Pais { get; set; }
        public string Paypal { get; set; }
        public Int64? Telefono { get; set; }
           
        public virtual Carrito Carrito { get; set; }
        public virtual ComentarioEnProducto ComentarioEnProducto { get; set; }
        public virtual ICollection<ComentarioEnPublicacion> ComentarioEnPublicacion { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<DocenteDocente> DocenteASeguirCollection { get; set; }
        public virtual ICollection<DocenteDocente> DocenteEnSesionCollection { get; set; }
        public virtual ICollection<Revista> Revista { get; set; }
        public virtual ICollection<Historial> Historial { get; set; }
    }
}
