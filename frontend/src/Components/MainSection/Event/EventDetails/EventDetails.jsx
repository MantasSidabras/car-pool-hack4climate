import { Box, Button, Grid, makeStyles } from "@material-ui/core";
import RoomIcon from "@material-ui/icons/Room";
import React, { useEffect, useState } from "react";
import { useHistory, useLocation, useParams } from "react-router-dom";
import { getEventById } from "../../../../services/axios";
import PATHS from "../../../Router/RouterPaths";
import TripList from "../../Trip/TripsList/TripList";

const useStyles = makeStyles(theme => ({
  root: {
    maxWidth: "700px"
    // height: "500px"
  },
  image: {
    width: "100%",
    height: "200px"
  },
  content: {
    width: "100%"
  }
}));

const EventDetails = () => {
  const classes = useStyles();
  const location = useLocation();
  const history = useHistory();
  const { id } = useParams();

  const [data, setData] = useState();
  const [error, setError] = useState();

  useEffect(() => {
    const fetchData = async () => {
      const { data, error } = await getEventById(id);
      if (data) {
        setData(data);
      }
      if (error) {
        setError(error);
      }
    };

    fetchData();
  }, []);

  const onCreateTrip = () => {
    history.push(
      PATHS.trip
        .replace(":tripId", "newTrip")
        .replace(":id", id)
        .concat(`?eventName=${data.eventName}`)
    );
  };

  return (
    <>
      {error && <h2>Error</h2>}
      {data ? (
        <Grid container direction="column" alignItems="center">
          <h1>{data.eventName}</h1>
          <Box m={0} boxShadow={2} className={classes.root}>
            <Box component="img" src={data.logoUri} className={classes.image} />
            <Grid container direction="row" justify="flex-start">
              <Box component="div" m={2} className={classes.content}>
                <Grid container justify="space-between" spacing={2}>
                  <Grid item style={{ textAlign: "left" }}>
                    {data.description}
                  </Grid>
                  <Grid item style={{ textAlign: "left", fontWeight: "Bold" }}>
                    <RoomIcon />
                    {data.address}
                  </Grid>
                  <Grid item>
                    <Button
                      variant="contained"
                      color="primary"
                      onClick={onCreateTrip}
                    >
                      Create a trip
                    </Button>
                  </Grid>
                </Grid>
              </Box>
            </Grid>
            {data.eventTrips.length > 0 && (
              <TripList trips={data.eventTrips} eventId={id} />
            )}
          </Box>
        </Grid>
      ) : (
        <h2>No data</h2>
      )}
    </>
  );
};

export default EventDetails;
