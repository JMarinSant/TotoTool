import React, { Fragment, useState } from 'react';
import {
    Typography,
    Card,
    CardContent,
    Box,
    TextField,
    Button,
    Container,
    Grid
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import { Registrar } from '../../api/DocenteAPI';
import { useAlert } from 'react-alert';

const useStyles = makeStyles((theme) => ({
    marginForm: {
        marginTop: theme.spacing(3),
    },
}));

const RegistroDocente = (props) => {
    const classes = useStyles();
    const alert = useAlert();
    const [docente, setDocente] = useState({
        nombre: "",
        correoElectronico: "",
        contraseña: "",
        direccion: "",
        ciudad: "",
        entidadFederativa: "",
        pais: "",
        paypal: "",
        telefono: "",
    });

    const docenteSubmit = async (e) => {
        e.preventDefault();
        const token = await Registrar(docente);
        if(token){
            alert.success("Registro comletado con éxito");
            props.history.push("/docente/IniciarSesion");
        }else{
            alert.error("Algo salió mal");
        }
       
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setDocente({
            ...docente,
            [name]: value
        })
    };

    return (
        <Fragment>
            <Container maxWidth="sm">
                <Box mt={4}>
                    <Card>
                        <CardContent>
                            <form onSubmit={docenteSubmit}>
                                <TextField
                                    name="nombre"
                                    label="Nombre"
                                    fullWidth
                                    required
                                    inputProps={{ maxLength: 255 }}
                                    value={docente.nombre}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    name="correoElectronico"
                                    label="Correo Electrónico"
                                    fullWidth
                                    required
                                    inputProps={{ maxLength: 150 }}
                                    value={docente.correoElectronico}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    type="password"
                                    name="contraseña"
                                    label="Contraseña"
                                    fullWidth
                                    required
                                    inputProps={{ maxLength: 50 }}
                                    value={docente.contraseña}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    name="direccion"
                                    label="Dirección"
                                    fullWidth
                                    inputProps={{ maxLength: 255 }}
                                    value={docente.direccion}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />

                                <TextField
                                    name="pais"
                                    label="País"
                                    fullWidth
                                    inputProps={{ maxLength: 50 }}
                                    value={docente.pais}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    name="ciudad"
                                    label="Ciudad"
                                    fullWidth
                                    inputProps={{ maxLength: 100 }}
                                    value={docente.ciudad}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    name="entidadFederativa"
                                    label="Entidad Federativa"
                                    fullWidth
                                    inputProps={{ maxLength: 75 }}
                                    value={docente.entidadFederativa}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    name="paypal"
                                    label="Paypal"
                                    fullWidth
                                    inputProps={{ maxLength: 75 }}
                                    value={docente.paypal}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <TextField
                                    type="number"
                                    name="telefono"
                                    label="Teléfono"
                                    fullWidth
                                    value={docente.telefono}
                                    onChange={handleInputChange}
                                    className={classes.marginForm}
                                />
                                <Grid 
                                    item 
                                    container 
                                    justify="flex-end"
                                > 
                                    <Button
                                        type="submit"
                                        color="primary"
                                        variant="contained"                                        
                                        className={classes.marginForm}
                                    >
                                        Registrarse
                            </Button>
                                </Grid>

                            </form>
                        </CardContent>
                    </Card>
                </Box>
            </Container>

        </Fragment>
    );

}

export default RegistroDocente;