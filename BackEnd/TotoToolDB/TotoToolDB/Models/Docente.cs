using System;

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
        public Int64 Telefono { get; set; }
    }
}
