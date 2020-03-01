import React from "react";
import { ListItem, ListItemIcon, Typography, Grid } from "@material-ui/core";
import DirectionsCarIcon from "@material-ui/icons/DirectionsCar";
import HouseIcon from "@material-ui/icons/House";
import ScheduleIcon from "@material-ui/icons/Schedule";

const TripItem = ({ trip, onTripSelect }) => {
  return (
    <ListItem button onClick={() => onTripSelect(trip.id)}>
      <ListItemIcon>
        <Grid container direction="column">
          <DirectionsCarIcon />
          {`${trip.currentPassengerCount}/${trip.capacity}`}
        </Grid>
      </ListItemIcon>
      <Grid container direction="column">
        <Grid container justify="space-between" style={{ width: "100%" }}>
          <Grid>
            <Typography variant="h6">{trip.driverName}</Typography>
          </Grid>
          <Grid>
            <Grid
              container
              direction="column"
              justify="space-between"
              style={{ height: "100%" }}
            >
              <Grid container>
                <ListItemIcon>
                  <HouseIcon />
                </ListItemIcon>
                <Typography>{trip.address}</Typography>
              </Grid>
            </Grid>
          </Grid>
        </Grid>
        <div
          style={{
            display: "flex",
            width: "100%",
            justifyContent: "space-between"
          }}
        >
          <Typography color="textSecondary" variant="h6">
            {trip.carModel}
          </Typography>
          <div style={{ display: "flex" }}>
            <ListItemIcon>
              <ScheduleIcon />
            </ListItemIcon>
            <Typography color="textSecondary">
              {new Date(trip.departureTime).toLocaleTimeString()}
            </Typography>
          </div>
        </div>
      </Grid>
    </ListItem>
  );
};

export default TripItem;
