using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Error
{
    public struct Resultado
    {
        public int codigo;
        public string mensaje;
    }
    public class Resultados
    {

        public Resultado CorreoElectronicoYaExistente()
        {
            Resultado resultado;
            resultado.codigo = 400;
            resultado.mensaje = "Este correo electronico ya existe.";
            return resultado;
        }

        public Resultado CorreoElectronicoNoRegistrado()
        {
            Resultado resultado;
            resultado.codigo = 404;
            resultado.mensaje = "Correo electronico incorrecto.";
            return resultado;
        }

        public Resultado ContraseñaIncorrecta()
        {
            Resultado resultado;
            resultado.codigo = 400;
            resultado.mensaje = "Contraseña incorrecta.";
            return resultado;
        }

        public Resultado DatosInexistentes()
        {
            Resultado resultado;
            resultado.codigo = 404;
            resultado.mensaje = "Este dato no existe en la base de datos.";
            return resultado;
        }

        public Resultado SolicitudSinExito()
        {
            Resultado resultado;
            resultado.codigo = 400;
            resultado.mensaje = "Solicitud sin exito.";
            return resultado;
        }

        public Resultado SolicitudExitosa()
        {
            Resultado resultado;
            resultado.codigo = 400;
            resultado.mensaje = "Solicitud realizada con exito.";
            return resultado;
        }
        public Resultado ProcedimientoExitoso()
        {
            Resultado resultado;
            resultado.codigo = 200;
            resultado.mensaje = "Registro exitoso.";
            return resultado;
        }

        public Resultado RegistroExitoso()
        {
            Resultado resultado;
            resultado.codigo = 200;
            resultado.mensaje = "Registro exitoso.";
            return resultado;
        }


        public Resultado ActualizacionExitosa()
        {
            Resultado resultado;
            resultado.codigo = 200;
            resultado.mensaje = "Actualizacion exitosa.";
            return resultado;
        }

    }
}
