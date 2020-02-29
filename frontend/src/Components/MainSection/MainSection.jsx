import * as React from "react";
import { Box, makeStyles, Grid, List, Card, ListItem } from "@material-ui/core";
import MainRouter from "../Router/MainRouter";
import MainContext from "../../Context/MainContext";
import EventCard from "./EventCard/EventCard";
import eventsMock from "../../MockData/Events";

const useStyles = makeStyles(theme => ({
  root: {
    width: "60%",
    // height: "500px",
    backgroundColor: "white"
  }
}));

const MainSection = () => {
  const classes = useStyles();

  const [context, setContext] = React.useContext(MainContext);
  return (
    <Grid container direction="row" justify="center" alignItems="center">
      <Box m={4} boxShadow={2} className={classes.root}>
        <List>
          {eventsMock.map(eventInfo => {
            console.log("this is event: ", eventInfo);
            return (
              <ListItem key={eventInfo.name}>
                <EventCard eventInfo={eventInfo} />
              </ListItem>
            );
          })}
        </List>
      </Box>
    </Grid>
  );
};

export default MainSection;
