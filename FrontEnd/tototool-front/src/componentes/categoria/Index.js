import React, { useEffect, useState, Fragment } from 'react';
import { GetAll } from '../../api/CategoriaAPI';
import {
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper,
    Typography,
    Box,
    Button,
    Grid
} from '@material-ui/core';

const CategoriaIndex = (props) => {
    const [categoria, setCategoria] = useState([]);

    //se ejecuanta cuando algo cambia en el componente
    useEffect(() => {
        async function fetchData() {
            const categoriaRes = await GetAll();
            setCategoria(categoriaRes);
        }

        fetchData();
    }, []);

    return (
        <Fragment>
            <Grid container>
                <Grid item xs={8}>
                    <Typography variant="h5">
                        Categorias
                    </Typography>
                </Grid>
                <Grid item container xs={4} justify="flex-end" alignItems="center">
                    <Button variant="outlined" color="secondary" href="/categoria/Crear">
                        Crear
                    </Button>
                </Grid>
            </Grid>
            <Box mt={1}>
                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell> Id </TableCell>
                                <TableCell> Nombre </TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {categoria.map((item, index) => (
                                <TableRow key={index}>
                                    <TableCell>{item.id}</TableCell>
                                    <TableCell>{item.nombre}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Box>
        </Fragment>

    );
};

export default CategoriaIndex;