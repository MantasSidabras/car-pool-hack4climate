import * as React from "react";
import { Box, Grid, Input, makeStyles, Button } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import FacebookLogin from "react-facebook-login";
import Login from "./Login";
import SignUp from "./SignUp";

const useStyles = makeStyles(theme => ({
  root: {
    // height: "500px"
  },
  col: {
    height: "100%"
  },
  form: {
    maxWidth: "500px",
    width: "100%"
  },
  button: {}
}));

const Auth = () => {
  const history = useHistory();
  const [context, setContext] = React.useContext(MainContext);
  const [isLogin, setIsLogin] = React.useState(true);

  const classes = useStyles();

  const onLoginClick = () => {
    setContext({ ...context, loggedIn: true });
    history.push("/");
  };

  return (
    <Grid
      container
      direction="column"
      justify="center"
      alignItems="center"
      className={classes.root}
    >
      <p style={{ fontSize: 20, color: "#4f4f4f" }}>
        Welcome traveler, <br />
        please log in or register to continue
      </p>
      <div style={{ display: "flex", flexDirection: "row" }}>
        <Button
          variant="contained"
          color="primary"
          size="large"
          onClick={() => setIsLogin(true)}
        >
          Log In
        </Button>
        <div style={{ width: 10 }}></div>
        <Button
          variant="contained"
          color="primary"
          size="large"
          onClick={() => setIsLogin(false)}
        >
          Sign Up
        </Button>
      </div>
      <Box m={4} boxShadow={2} className={classes.form}>
        <h3>{isLogin ? <>Log In</> : <>Sign Up</>}</h3>
        {isLogin ? <Login /> : <SignUp />}
      </Box>
    </Grid>
  );
};

export default Auth;
