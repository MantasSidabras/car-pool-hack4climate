import React from "react";
import { ListItem, ListItemIcon, Typography, Grid } from "@material-ui/core";
import DirectionsCarIcon from "@material-ui/icons/DirectionsCar";

const TripItem = ({ trip }) => {
  return (
    <ListItem button>
      <ListItemIcon>
        <DirectionsCarIcon />
      </ListItemIcon>
      <Typography container direction="column">
        <Grid container style={{ width: "100%" }}>
          <Typography>{trip.driverName}</Typography>
          <Typography>{trip.address}</Typography>
        </Grid>
        <Typography color="textSecondary">
          Dragons are better than carpool
        </Typography>
      </Typography>
    </ListItem>
  );
};

export default TripItem;
