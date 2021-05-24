import React, { Fragment } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import {
  createMuiTheme,
  MuiThemeProvider,
} from '@material-ui/core';

import Index from './componentes/Index';
import AppBarIndex from './componentes/appbar/Index';
import RegistroDocente from './componentes/docente/Registro';
import InicioSesion from './componentes/docente/IniciarSesion';
import Modificar from './componentes/docente/Modificar';

const theme = createMuiTheme({
  palette: {
    primary: {
      main: "#171717"
    },
    secondary: {
      main: "#2d2b2b"
    }
  },
})

function App() {
  return (
    <Fragment>
      <MuiThemeProvider theme={theme}>            
            <Router>
              <Route path="/" component={AppBarIndex} />
              <Route exact path="/" component={Index} />
              <Route exact path="/index" component={Index} />
              <Route exact path="/docente/Registro" component={RegistroDocente} />
              <Route exact path="/docente/IniciarSesion" component={InicioSesion} />
              <Route exact path="/docente/Modificar" component={Modificar} />
            </Router>   
      </MuiThemeProvider>
    </Fragment>
  );
}

export default App;
