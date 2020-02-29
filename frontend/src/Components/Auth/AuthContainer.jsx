import { Box, Grid, makeStyles } from "@material-ui/core";
import * as React from "react";

const AuthContainer = ({ children }) => {
  return (
    <Grid container direction="column" justify="center" alignItems="center">
      <p style={{ fontSize: 20, color: "#4f4f4f" }}>
        Welcome traveler, <br />
        please log in or register to continue
      </p>
      <Box m={4} boxShadow={2} style={{ maxWidth: "500px", width: "100%" }}>
        {children}
      </Box>
    </Grid>
  );
};

export default AuthContainer;
