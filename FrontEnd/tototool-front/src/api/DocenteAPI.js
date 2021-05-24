import { axiosBase as axios } from "./AxiosConfig";

export const Registrar = async (docente) => {
    try{
        await axios.post("/Docente/Crear", docente);
        return true;
    }
    catch (error) {
        console.error(error);
        return false;
    }
}

export const IniciarSesion = async (docente) => {
    try{
        const respuesta = await axios.get("docente/obtenerdocente", {
            params: {
            CorreoElectronico: docente.CorreoElectronico,
            Contraseña: docente.Contraseña
          }});
       return respuesta;
     }
    catch (error) {
        console.error(error);
        return false;
    }
}


export const Modificar = async (docente) => {
    try{
        const respuesta = await axios.put("docente/obtenerdocente", {
            params: {
                docente,
                id: docente.id
          }});
       return respuesta;
     }
    catch (error) {
        console.error(error);
        return false;
    }
}