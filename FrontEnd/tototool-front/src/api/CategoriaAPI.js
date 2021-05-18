import { axiosBase as axios } from "./AxiosConfig";

export const GetAll = async () => {
    try {
        const response = await axios.get("/Categoria/GetAll");
        return response.data;
    }
    catch (error) {
        console.error(error);
        return error;
    }
}

export const Crear = async (categoria) => {
    try {
        const response = await axios.post("/Categoria/Create", categoria);
        console.log("crearCategoria", response);
    }
    catch (error) {
        console.error(error);
        return error;
    }
}