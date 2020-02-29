import React from 'react';
import logo from './logo.svg';
import './App.css';


import AppBarComponent from './Components/AppBar/AppBar';
import { ThemeProvider, createMuiTheme } from '@material-ui/core';
import { blue, yellow, lightBlue } from '@material-ui/core/colors';
// import MainSection from './Components/MainSection/MainSection';
import MainRouter from './Components/Router/MainRouter';
import {
  BrowserRouter as Router
} from "react-router-dom";
import { MainContextProvider } from './Context/MainContext';

const theme = createMuiTheme({
  palette: {
    primary: lightBlue
  },
});

const context = {
  loggedIn: false,

}

const App = () => {
  return (
    <Router>
      <ThemeProvider theme={theme}>
        <div className="App">
          <MainContextProvider value={context}>
            <AppBarComponent />
            <MainRouter />
          </MainContextProvider>
        </div>
      </ThemeProvider>
    </Router>
  );
}

export default App;
