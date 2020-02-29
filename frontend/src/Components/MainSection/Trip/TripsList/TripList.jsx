import React from "react";
import {
  Box,
  Grid,
  List,
  ListItem,
  ListItemText,
  ListItemIcon,
  makeStyles,
  Typography
} from "@material-ui/core";
import InboxIcon from "@material-ui/icons/Inbox";
import TripItem from "../TripItem/TripItem";
import { useHistory } from "react-router-dom";
import PATHS from "../../../Router/RouterPaths";

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%",
    backgroundColor: theme.palette.background.paper
  }
}));

const TripList = ({ trips }) => {
  const classes = useStyles();
  const history = useHistory();
  const onTripSelect = tripId => {
    history.push(PATHS.trip.replace(":tripId", tripId));
  };

  return (
    <Box m={2}>
      <Grid container direction="column" alignItems="flex-start">
        <h2>Trips</h2>
        <div className={classes.root}>
          <List component="nav" aria-label="main mailbox folders">
            {trips.map(trip => {
              return (
                <TripItem
                  key={trip.id}
                  trip={trip}
                  onTripSelect={onTripSelect}
                />
              );
            })}
          </List>
        </div>
      </Grid>
    </Box>
  );
};

export default TripList;
