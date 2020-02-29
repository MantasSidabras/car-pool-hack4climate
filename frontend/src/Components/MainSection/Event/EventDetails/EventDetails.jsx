import React, { useEffect, useState } from "react";
import { Grid, Box, makeStyles, Typography } from "@material-ui/core";
import { useLocation, useParams } from "react-router-dom";
import MainContext from "../../../../Context/MainContext";
import { getEvents, getEventById } from "../../../../services/axios";
import TripList from "../../Trip/TripsList/TripList";
import RoomIcon from "@material-ui/icons/Room";

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
  const { id } = useParams();

  // const [context] = useContext(MainContext);

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
                <Grid container spacing={2}>
                  <Grid item style={{ textAlign: "left" }}>
                    {data.description}
                  </Grid>
                  <Grid item style={{ textAlign: "left", fontWeight: "Bold" }}>
                    <RoomIcon />
                    {data.address}
                  </Grid>
                </Grid>
              </Box>
            </Grid>
            <TripList trips={data.eventTrips} />
          </Box>
        </Grid>
      ) : (
        <h2>No data</h2>
      )}
    </>
  );
};

export default EventDetails;
