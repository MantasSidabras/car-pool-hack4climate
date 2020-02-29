import React from 'react';
import logo from './logo.svg';
import './App.css';


import AppBarComponent from './Components/AppBar/AppBar';
import { ThemeProvider, createMuiTheme } from '@material-ui/core';
import { blue, yellow, lightBlue } from '@material-ui/core/colors';

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

        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <p>
            Edit <code>src/App.js</code> and save to reload.
        </p>
          <a
            className="App-link"
            href="https://reactjs.org"
            target="_blank"
            rel="noopener noreferrer"
          >
            Learn React
        </a>
        </header>
      </div >
    </ThemeProvider>
  );
}

export default App;
