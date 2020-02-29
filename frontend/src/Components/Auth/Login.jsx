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
import { login } from "../../services/axios";

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

const Login = () => {
  const history = useHistory();
  const [context, setContext] = React.useContext(MainContext);
  const [username, setUsername] = React.useState("");
  const [pass, setPass] = React.useState("");
  const [error, setError] = React.useState(false);

  const onLogin = async () => {
    const { data, error } = await login(username, pass);

    if (data && data.token) {
      setContext({ ...context, token: data.token });
    } else {
      setError(true);
    }
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
        label="Phone Number"
        placeholder="Enter phone number"
        onChange={e => {
          setUsername(e.target.value);
          setError(false);
        }}
      />
      <InputField
        label="Password"
        placeholder="Enter password"
        onChange={e => {
          setPass(e.target.value);
          setError(false);
        }}
        type="password"
      />
      {error && (
        <p style={{ color: "red" }}>Incorrect phone number or password.</p>
      )}

      <Button
        variant="contained"
        color="primary"
        style={{ width: "70%", marginTop: 10 }}
        onClick={onLogin}
      >
        Sign Up
      </Button>
    </div>
  );
};

export default Login;
