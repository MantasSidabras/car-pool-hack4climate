import React from 'react';
import logo from './logo.svg';
import './App.css';


import AppBarComponent from './Components/AppBar/AppBar';
import { ThemeProvider, createMuiTheme } from '@material-ui/core';
import { blue, yellow, lightBlue } from '@material-ui/core/colors';
import MainSection from './Components/MainSection/MainSection';

const theme = createMuiTheme({
  palette: {
    primary: lightBlue
  },
});

const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <AppBarComponent />
        <MainSection />
      </div>
    </ThemeProvider>
  );
}

export default App;
