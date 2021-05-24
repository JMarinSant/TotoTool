import React, { Fragment} from 'react';
import {
    Card,
    CardContent,
    Box,
    TextField,
    Button,
    Container,
    Grid
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import { Modificar } from '../../api/DocenteAPI';
import { useAlert } from 'react-alert';

const useStyles = makeStyles((theme) => ({
    marginForm: {
        marginTop: theme.spacing(3),
    },
}));

const ModificarDocente = (props) => {
    const docenteEnSesion = JSON.parse(localStorage.getItem("token"));
    const classes = useStyles();
    const alert = useAlert();
    const redirigeInicioSesion = () => {
        props.history.push("/docente/IniciarSesion");
    };
   
    return (
        <Fragment>
            <Container maxWidth="sm">
                <Box mt={4}>
                    <Card>
                        <CardContent>
                            {docenteEnSesion ? docenteEnSesion.map((item, index) => (
                                <form>
                                    <TextField
                                        name="nombre"
                                        label="Nombre"
                                        fullWidth
                                        required
                                        inputProps={{ maxLength: 255 }}
                                        value={item.nombre}
                                        className={classes.marginForm}
                                      
                                    />

                                    <TextField
                                        name="correoElectronico"
                                        label="Correo Electrónico"
                                        fullWidth
                                        required
                                        inputProps={{ maxLength: 150 }}
                                        value={item.correoElectronico}
                                        className={classes.marginForm}
                                      
                                    />
                                    <TextField
                                        name="contraseña"
                                        label="Contraseña"
                                        fullWidth
                                        required
                                        inputProps={{ maxLength: 50 }}
                                        value={item.contraseña}
                                        className={classes.marginForm}
                                       
                                    />
                                    <TextField
                                        name="direccion"
                                        label="Dirección"
                                        fullWidth
                                        inputProps={{ maxLength: 255 }}
                                        value={item.direccion}
                                        className={classes.marginForm}
                                       
                                    />

                                    <TextField
                                        name="pais"
                                        label="País"
                                        fullWidth
                                        inputProps={{ maxLength: 50 }}
                                        value={item.pais}
                                        className={classes.marginForm}
                                       
                                    />
                                    <TextField
                                        name="ciudad"
                                        label="Ciudad"
                                        fullWidth
                                        inputProps={{ maxLength: 100 }}
                                        value={item.ciudad}
                                        className={classes.marginForm}
                                       
                                    />
                                    <TextField
                                        name="entidadFederativa"
                                        label="Entidad Federativa"
                                        fullWidth
                                        inputProps={{ maxLength: 75 }}
                                        value={item.entidadFederativa}
                                        className={classes.marginForm}
                                      
                                    />
                                    <TextField
                                        name="paypal"
                                        label="Paypal"
                                        fullWidth
                                        inputProps={{ maxLength: 75 }}
                                        value={item.paypal}
                                        className={classes.marginForm}
                                       
                                    />
                                    <TextField
                                        type="number"
                                        name="telefono"
                                        label="Teléfono"
                                        fullWidth
                                        value={item.telefono}
                                        className={classes.marginForm}
                                       
                                    />
                                    <Grid  
                                        item 
                                        ontainer 
                                        justify="flex-end"
                                    >
                                        <Button
                                            type="submit"
                                            color="primary"
                                            variant="contained"
                                            className={classes.marginForm}
                                           
                                        >
                                            Modificar
                                        </Button>
                                    </Grid>
                                </form>
                            )) : redirigeInicioSesion()}

                        </CardContent>
                    </Card>
                </Box>
            </Container>
        </Fragment>
    );

}

export default ModificarDocente;