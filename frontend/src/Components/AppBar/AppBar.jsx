import AppBar from "@material-ui/core/AppBar";
import Button from "@material-ui/core/Button";
import { makeStyles } from "@material-ui/core/styles";
import Toolbar from "@material-ui/core/Toolbar";
import Typography from "@material-ui/core/Typography";
import React, { useContext } from "react";
import { useHistory } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import PATHS from "../Router/RouterPaths";
import { Box } from "@material-ui/core";

const useStyles = makeStyles(theme => ({
  root: {
    // flexGrow: 1
    // height: 50
  },
  menuButton: {
    marginRight: theme.spacing(2)
  },
  title: {
    // flexGrow: 1
  },
  spacer: {
    flexGrow: 1
  }
}));

const AppBarComponent = () => {
  const classes = useStyles();
  const history = useHistory();
  const [context, setContext] = useContext(MainContext);

  const isLoggedIn = !!context.token;
  const onLoginClick = () => {
    history.push(PATHS.login);
  };

  const onTitleClick = () => {
    history.push(PATHS.home);
  };

  return (
    <AppBar position="sticky" className={classes.root}>
      <Toolbar variant="dense">
        <Button className={classes.title} onClick={onTitleClick} size="large">
          Home
        </Button>
        <div className={classes.spacer} />
        {!isLoggedIn ? (
          <>
            <Button color="inherit" onClick={onLoginClick}>
              Log In
            </Button>
            <Button color="inherit" onClick={() => history.push(PATHS.signup)}>
              Sign Up
            </Button>
          </>
        ) : (
          <Button color="inherit" onClick={() => history.push(PATHS.logout)}>
            Log Out
          </Button>
        )}
      </Toolbar>
    </AppBar>
  );
};

export default AppBarComponent;
