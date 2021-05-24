import React, { Fragment, useState } from 'react';
import {
    Card,
    CardContent,
    Box,
    TextField,
    Button
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import { Crear } from '../../api/ProductoAPI';
import { useAlert } from 'react-alert';

const useStyles = makeStyles((theme) => ({
    marginForm: {
        marginTop: theme.spacing(3),
    },
}));

const CrearProducto = (props) => {
    const classes = useStyles();
    const alert = useAlert();
    const [producto, setProducto] = useState({
        nombre: "",
        descripcion: "",
        precio: "",
        imagen: "",
        categoria: "",
        docenteId: "",    
    });

    const productoSubmit = async (e) => {
        e.preventDefault();
        const token = await Crear(producto);
        if(token){
            alert.success("Producto agregado con éxito");
            props.history.push("/");
        }else{
            alert.error("Algo salió mal");
        }
        
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setDocente({
            ...producto,
            [name]: value
        })
    };

    return (
        <Fragment>
            <Box>
                <Card>
                    <CardContent>
                        <form onSubmit={productoSubmit}>
                            <TextField
                                name="nombre"
                                label="Nombre"
                                fullWidth
                                required
                                inputProps={{ maxLength: 100 }}
                                value={producto.nombre}
                                onChange={handleInputChange}
                            />
                            <TextField
                                name="descripcion"
                                label="Descripción"
                                fullWidth
                                required
                                inputProps={{ maxLength: 150 }}
                                value={producto.descripcion}
                                onChange={handleInputChange}
                            />
                            <TextField
                                type="number"
                                name="precio"
                                label="Precio"
                                fullWidth
                                required
                                value={producto.precio}
                                onChange={handleInputChange}
                            />
                          
                              <Button
                                type="submit"
                                color="primary"
                                variant="contained"
                                className={classes.marginForm}
                            >
                                Guardar
                            </Button>
                        </form>
                    </CardContent>
                </Card>
            </Box>
        </Fragment>
    );

}

export default CrearProducto;