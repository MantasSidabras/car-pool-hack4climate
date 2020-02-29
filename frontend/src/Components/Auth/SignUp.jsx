import * as React from "react";
import {
  Box,
  Grid,
  Input,
  makeStyles,
  Button,
  FormControlLabel,
  InputLabel
} from "@material-ui/core";
import { useHistory } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import FacebookLogin from "react-facebook-login";
import InputField from "../Other/InputField";

const useStyles = makeStyles(theme => ({
  root: {
    height: "500px"
  },
  col: {
    height: "100%"
  },
  form: {
    width: "40%"
  },
  button: {}
}));

const SignUp = () => {
  const history = useHistory();
  const [context, setContext] = React.useContext(MainContext);
  const [username, setUsername] = React.useState("");
  const [pass, setPass] = React.useState("");

  const onLoginClick = () => {
    setContext({ ...context, loggedIn: true });
    history.push("/");
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        margin: 15,
        alignItems: "center"
      }}
    >
      <InputField
        label="Username"
        placeholder="Enter your username"
        onChange={e => setUsername(e.target.value)}
      />
      <InputField
        label="Password"
        placeholder="Enter your password"
        onChange={e => setPass(e.target.value)}
        type="password"
      />
      <InputField
        label="Repeat Password"
        placeholder="Enter your password again"
        onChange={e => setPass(e.target.value)}
        type="password"
      />

      <Button
        variant="contained"
        color="primary"
        style={{ width: "70%", marginTop: 10 }}
        onClick={() => console.log("US: " + username + " pass: " + pass)}
      >
        Sign Up
      </Button>
    </div>
  );
};

export default SignUp;
