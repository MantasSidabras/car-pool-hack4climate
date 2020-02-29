import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";

import AppBarComponent from "./Components/AppBar/AppBar";
import { ThemeProvider, createMuiTheme } from "@material-ui/core";
import { blue, yellow, lightBlue } from "@material-ui/core/colors";
import MainSection from "./Components/MainSection/MainSection";
import { getEvents } from "./services/axios";

const theme = createMuiTheme({
  palette: {
    primary: lightBlue
  }
});

const App = () => {
  // const [data, setData] = useState([]);
  // const [error, setError] = useState();

  // useEffect(() => {
  //   const fetchData = async () => {
  //     const { data, error } = await getEvents();
  //     if (data) {
  //       setData(data);
  //     }
  //     if (error) {
  //       setError(error);
  //     }
  //   };

  //   fetchData();
  // }, []);

  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <AppBarComponent />
        <MainSection />
      </div>
    </ThemeProvider>
  );
};

export default App;
