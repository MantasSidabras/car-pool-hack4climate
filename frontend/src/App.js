import { createMuiTheme, ThemeProvider } from "@material-ui/core";
import { lightBlue } from "@material-ui/core/colors";
import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import "./App.css";
import AppBarComponent from "./Components/AppBar/AppBar";
// import MainSection from './Components/MainSection/MainSection';
import MainRouter from "./Components/Router/MainRouter";
import { MainContextProvider } from "./Context/MainContext";

const theme = createMuiTheme({
  palette: {
    primary: lightBlue
  }
});

const context = {
  loggedIn: false
};

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
};

export default App;
