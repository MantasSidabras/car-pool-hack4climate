import { createMuiTheme, ThemeProvider, Grid } from "@material-ui/core";
import {
  lightBlue,
  purple,
  deepPurple,
  green,
  yellow
} from "@material-ui/core/colors";
import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import "./App.css";
import AppBarComponent from "./Components/AppBar/AppBar";
// import MainSection from './Components/MainSection/MainSection';
import MainRouter from "./Components/Router/MainRouter";
import { MainContextProvider } from "./Context/MainContext";

const theme = createMuiTheme({
  palette: {
    primary: lightBlue,
    secondary: yellow
  }
});

const context = {
  loggedIn: false
};

const App = () => {
  return (
    <Router>
      <ThemeProvider theme={theme}>
        <div className="App">
          <MainContextProvider value={context}>
            <AppBarComponent />
            <Grid
              container
              direction="row"
              justify="center"
              alignItems="center"
            >
              <MainRouter />
            </Grid>
          </MainContextProvider>
        </div>
      </ThemeProvider>
    </Router>
  );
};

export default App;
