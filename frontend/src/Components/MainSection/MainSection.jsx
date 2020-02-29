import { Box, Grid, List, ListItem, makeStyles } from "@material-ui/core";
import React from "react";
import { useHistory } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import eventsMock from "../../MockData/Events";
import EventCard from "./Event/EventCard/EventCard";
import EventList from "./Event/EventList/EventList";
import PATHS from "../Router/RouterPaths";
import { getEvents } from "../../services/axios";

const useStyles = makeStyles(theme => ({
  root: {
    width: "60%",
    backgroundColor: "white"
  }
}));

const MainSection = () => {
  const classes = useStyles();
  const history = useHistory();

  const [context, setContext] = React.useContext(MainContext);
  const [error, setError] = React.useState();

  React.useEffect(() => {
    const fetchData = async () => {
      const { data, error } = await getEvents();
      if (data) {
        setContext({ ...context, events: data });
      }
      if (error) {
        setError(error);
      }
    };

    fetchData();
  }, []);

  const onEventSelect = () => {
    history.push(PATHS.event.replace(":id", 1));
  };

  return (
    <Grid container direction="row" justify="center" alignItems="center">
      <Box m={4} boxShadow={2} className={classes.root}>
        {context.events.length > 0 ? (
          <EventList events={context.events} onEventSelect={onEventSelect} />
        ) : (
          <h2>No data</h2>
        )}
      </Box>
    </Grid>
  );
};

export default MainSection;
