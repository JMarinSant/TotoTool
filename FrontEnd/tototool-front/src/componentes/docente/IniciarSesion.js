import React, { Fragment, useState } from 'react';
import {
    Card,
    CardContent,
    Box,
    TextField,
    Button,
    Typography,
    Container,
    Grid
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';

import { IniciarSesion } from '../../api/DocenteAPI';
import { useAlert } from 'react-alert';

const useStyles = makeStyles((theme) => ({
    marginForm: {
        marginTop: theme.spacing(3),
    },
    colorForm: {
        backgroundColor: '#171717',
    }
}));

const InicioSesion = (props) => {
    const classes = useStyles();
    const alert = useAlert();
    const [docente, setDocente] = useState({
        CorreoElectronico: "",
        Contraseña: "",
    });

    const docenteSubmit = async (e) => {
        e.preventDefault();
        var token = await IniciarSesion(docente);
        if (token) {
            localStorage.setItem('token', JSON.stringify(token.data));
            alert.success("Inicio de sesión comletado con éxito");
            props.history.push("/");
        } else {
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
                            <form onSubmit={docenteSubmit} >
                                <TextField
                                    name="CorreoElectronico"
                                    label="Correo Electrónico"
                                    fullWidth
                                    required
                                    className={classes.marginForm} 
                                    inputProps={{ maxLength: 150 }}
                                    value={docente.CorreoElectronico}
                                    onChange={handleInputChange}
                                />
                                <TextField
                                    type="password"
                                    name="Contraseña"
                                    label="Contraseña"
                                    fullWidth
                                    required
                                    className={classes.marginForm} 
                                    inputProps={{ maxLength: 50 }}
                                    value={docente.Contraseña}
                                    onChange={handleInputChange}                                    
                                />
                                <Grid container>
                                    <Grid item xs={6}>
                                        <Button                                           
                                            variant="outlined"
                                            color="secondary"
                                            href="/docente/Registro"
                                            className={classes.marginForm}
                                        >
                                            Registrarse
                                        </Button>
                                    </Grid>
                                    <Grid item container xs={6} justify="flex-end" alignItems="center">
                                        <Button
                                            type="submit"
                                            variant="outlined"
                                            color="primary"                                            
                                            className={classes.marginForm}  
                                        >
                                          Iniciar Sesión
                                            
                                        </Button>
                                    </Grid>
                                </Grid>

                            </form>
                        </CardContent>
                    </Card>
                </Box>
            </Container>
        </Fragment>
    );

}

export default InicioSesion;