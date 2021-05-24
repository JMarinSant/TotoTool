import { axiosBase as axios } from "./AxiosConfig";

export const Crear = async (producto) => {
    try{
        const respuesta = await axios.post("/Producto/Crear", producto);
    }
    catch (error) {
        console.error(error);
        return false;
    }
}