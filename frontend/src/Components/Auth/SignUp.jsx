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
import { register } from "../../services/axios";
import AuthContainer from "./AuthContainer";
import PATHS from "../Router/RouterPaths";

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
  const [name, setName] = React.useState("");
  const [surname, setSurname] = React.useState("");
  const [phoneNumber, setPhoneNumber] = React.useState("");
  const [carplate, setCarplate] = React.useState("");
  const [carModel, setCarModel] = React.useState("");
  const [pass, setPass] = React.useState("");
  const [error, setError] = React.useState(false);

  const onRegister = async () => {
    const { data, error } = await register(
      name,
      surname,
      phoneNumber,
      pass,
      carplate,
      carModel
    );

    if (data && data.authToken) {
      const { name, surname, phoneNumber, carplate, carModel, id } = data;
      setContext({
        ...context,
        token: data.authToken,
        user: {
          name,
          surname,
          phone: phoneNumber,
          car: carModel,
          carPlate: carplate,
          id
        }
      });
    } else {
      setError(true);
    }
  };

  return (
    <AuthContainer>
      <h3>Sign Up</h3>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          margin: 15,
          alignItems: "center"
        }}
      >
        <InputField
          label="Name*"
          placeholder="Enter name"
          onChange={e => setName(e.target.value)}
        />
        <InputField
          label="Surname*"
          placeholder="Enter surname"
          onChange={e => setSurname(e.target.value)}
        />
        <InputField
          label="Phone Number*"
          placeholder="Enter phone number"
          onChange={e => setPhoneNumber(e.target.value)}
        />
        <InputField
          label="Password*"
          placeholder="Enter password"
          onChange={e => setPass(e.target.value)}
          type="password"
        />
        <InputField
          label="Car model"
          placeholder="Enter car model"
          onChange={e => setCarModel(e.target.value)}
        />
        <InputField
          label="Car plate"
          placeholder="Enter car plate"
          onChange={e => setCarplate(e.target.value)}
        />
        {error && <p style={{ color: "red" }}>Something went wrong..</p>}

        <Button
          variant="contained"
          color="primary"
          style={{ width: "70%", marginTop: 10 }}
          onClick={onRegister}
        >
          Sign Up
        </Button>
      </div>
    </AuthContainer>
  );
};

export default SignUp;
