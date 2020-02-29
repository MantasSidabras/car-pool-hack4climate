import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid, Box, makeStyles } from "@material-ui/core";
import { getTripById } from "../../../../services/axios";
import InputField from "../../../Other/InputField";

const useStyles = makeStyles(theme => ({
  root: {
    width: "100%",
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

const TripDetails = () => {
  const classes = useStyles();

  const [trip, setTrip] = useState();
  const [error, setError] = useState();
  const { tripId } = useParams();

  React.useEffect(() => {
    const fetchData = async () => {
      const { data, error } = await getTripById(tripId);
      if (data) {
        setTrip(data);
      }
      if (error) {
        setError(error);
      }
    };

    fetchData();
  }, []);

  return (
    <>
      {trip ? (
        <Grid container direction="column" alignItems="center">
          <h1>{trip.eventName}</h1>
          <Box m={0} boxShadow={2} className={classes.root}>
            <Grid container direction="column">
              <Grid container direction="row" justify="center">
                <Box p={3} style={{ width: "50%" }}>
                  <InputField
                    label="From"
                    // width="40%"
                    width="100%"
                    value={trip.departureAddress}
                  />
                  <InputField
                    label="Leave time"
                    width="100%"
                    value={`${new Date(
                      trip.departureTime
                    ).toLocaleDateString()} ${new Date(
                      trip.departureTime
                    ).toLocaleTimeString()}`}
                  />
                  <InputField
                    label="Car"
                    width="100%"
                    value={trip.driver.carModel}
                  />
                  <InputField
                    label="Car plate"
                    width="100%"
                    value={trip.driver.carplate}
                  />
                  <InputField
                    label="Phone number"
                    width="100%"
                    value={trip.driver.phoneNumber}
                  />
                </Box>
              </Grid>
            </Grid>
          </Box>
        </Grid>
      ) : (
        <h2>No Data</h2>
      )}
    </>
  );
};

export default TripDetails;
