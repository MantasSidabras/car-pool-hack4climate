import { Button, makeStyles } from "@material-ui/core";
import * as React from "react";
import { useHistory } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import { login } from "../../services/axios";
import InputField from "../Other/InputField";
import AuthContainer from "./AuthContainer";

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

    if (data && data.authToken) {
      const { name, surname, phoneNumber, carplate, carModel } = data;
      setContext({
        ...context,
        token: data.authToken,
        user: {
          name,
          surname,
          phone: phoneNumber,
          car: carModel,
          carPlate: carplate
        }
      });
    } else {
      setError(true);
    }
  };

  return (
    <AuthContainer>
      <h3>Log In</h3>
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
    </AuthContainer>
  );
};

export default Login;
