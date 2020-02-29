import { Input, InputLabel } from "@material-ui/core";
import * as React from "react";

const InputField = ({ label, placeholder, width, onChange, type }) => {
  return (
    <div style={{ width: width || "70%" }}>
      <InputLabel style={{ color: "black", textAlign: "left" }}>
        {label}
      </InputLabel>
      <Input
        onChange={onChange}
        name="Username"
        placeholder={placeholder}
        style={{ marginBottom: 20, width: "100%" }}
        type={type}
      />
    </div>
  );
};

export default InputField;
