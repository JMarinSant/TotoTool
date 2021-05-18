import React, { Fragment } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Container,
  Box,
  createMuiTheme,
  MuiThemeProvider
} from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';

import Index from './componentes/Index';
import CategoriaIndex from './componentes/categoria/Index';
import CategoriaCrear from './componentes/categoria/Crear';

const theme = createMuiTheme({
  palette: {
    primary: {
      main: "#f403fc"
    },
    secondary: {
      main: "#171717"
    }
  },
})

function App() {
  return (
    <Fragment>
      <MuiThemeProvider theme={theme}>
        <AppBar position="static">
          <Toolbar variant="dense">
            <IconButton
              edge="start"
              color="inherit"
              aria-label="menu">
              <MenuIcon />
            </IconButton>
            <Typography variant="h6" color="inherit">
              Tototool
          </Typography>
          </Toolbar>
        </AppBar>
        <Container>
          <Box mt={3}>
            <Router>
              <Route exact path="/" component={Index} />
              <Route exact path="/index" component={Index} />
              <Route exact path="/categoria" component={CategoriaIndex} />
              <Route exact path="/categoria/Crear" component={CategoriaCrear} />
            </Router>
          </Box>
        </Container>
      </MuiThemeProvider>
    </Fragment>
  );
}

export default App;
