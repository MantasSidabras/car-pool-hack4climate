import { Input, InputLabel } from "@material-ui/core";
import * as React from "react";

const InputField = ({ label, width, ...props }) => {
  return (
    <div style={{ width: width || "70%" }}>
      <InputLabel
        style={{ color: "black", textAlign: "left", fontSize: "12px" }}
      >
        {label}
      </InputLabel>
      <Input style={{ marginBottom: 20, width: "100%" }} {...props} />
    </div>
  );
};

export default InputField;
