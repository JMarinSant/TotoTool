import React, { Fragment, useState } from 'react';
import {
    Typography,
    Card,
    CardContent,
    Box,
    TextField,
    Button
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import {Crear}  from '../../api/CategoriaAPI'


const useStyles = makeStyles((theme) => ({
    marginForm: {
        marginTop: theme.spacing(3),
    },
}));

const CategoriaCrear = (props) => {
    const classes = useStyles();

    const [categoria, setCategoria] = useState({
        nombre: ""
    });

    const categoriaSubmit = async(e) => {
        e.preventDefault();
        await Crear(categoria);
    };

    const handleInputChange = (e) => {
        const {name, value} = e.target;
        setCategoria({
            ...categoria,
            [name]: value
        })
    };

    return (
        <Fragment>
            <Typography variant="h5">
                Crear categoria
            </Typography>
            <Box mt={2}>
                <Card>
                    <CardContent>
                        <form onSubmit={categoriaSubmit}>
                            <TextField
                                name="nombre"
                                label="Nombre"
                                fullWidth
                                required
                                inputProps={{ maxLength: 50 }}
                                value={categoria.nombre}
                                onChange={handleInputChange}
                            />
                            <TextField
                                type="number"
                                name="nombre2"
                                label="Nombre"
                                fullWidth
                                className={classes.marginForm}
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

export default CategoriaCrear;