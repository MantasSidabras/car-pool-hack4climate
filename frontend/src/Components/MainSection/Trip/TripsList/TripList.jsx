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

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%",
    // maxWidth: 360,
    backgroundColor: theme.palette.background.paper
  }
}));

const TripList = ({ trips }) => {
  const classes = useStyles();

  return (
    <Box m={2}>
      <Grid container direction="column" alignItems="flex-start">
        <h2>Trips</h2>
        <div className={classes.root}>
          <List component="nav" aria-label="main mailbox folders">
            {trips.map(trip => {
              // TODO change to id
              return <TripItem key={trip.address} trip={trip} />;
            })}
          </List>
        </div>
        {JSON.stringify(trips)}
      </Grid>
    </Box>
  );
};

export default TripList;
