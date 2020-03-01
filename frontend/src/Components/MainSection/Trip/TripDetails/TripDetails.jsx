import React, { useState, useEffect, useContext } from "react";
import { useParams, useLocation, useHistory } from "react-router-dom";
import { Grid, Box, makeStyles, Button, ListItemIcon } from "@material-ui/core";
import { getTripById, createTrip, joinTrip } from "../../../../services/axios";
import InputField from "../../../Other/InputField";
import DirectionsCarIcon from "@material-ui/icons/DirectionsCar";
import MainContext from "../../../../Context/MainContext";
import TripRequestItem from "./TripRequestItem";

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
  const location = useLocation();
  const history = useHistory();
  const [trip, setTrip] = useState();
  const [error, setError] = useState();
  const { id, tripId } = useParams();
  const isNewTrip = tripId === "newTrip";
  const [context, setContext] = useContext(MainContext);
  React.useEffect(() => {
    const fetchData = async () => {
      const { data, error } = await getTripById(tripId);
      if (data) {
        setTrip({
          ...data,
          departureTime: data.departureTime
          // departureTime: `${new Date(
          //   data.departureTime
          // ).toLocaleDateString()} ${new Date(
          //   data.departureTime
          // ).toLocaleTimeString()}`
        });
      }
      if (error) {
        setError(error);
      }
    };

    if (!isNewTrip) {
      fetchData();
    } else {
      setTrip({
        eventName: new URLSearchParams(location.search).get("eventName") || "",
        departureAddress: "",
        departureTime: "",
        capacity: 0,
        driver: {
          id: context.id,
          carModel: "",
          carplate: "",
          phoneNumber: ""
        },
        tripJoinRequests: []
      });
    }
  }, []);

  const onSubmit = async () => {
    const { data } = await createTrip(
      context.token,
      id,
      trip.departureAddress,
      trip.departureTime,
      trip.capacity
    );
    if (data) {
      history.push(`/events/${id}/tripRedirect/${data}`);
    }
  };

  const onJoin = async () => {
    const { data } = await joinTrip(context.token, tripId);
    if (data) {
      console.log(data);
      history.push(`/events/${id}/tripRedirect/${tripId}`);
    }
  };

  const refresh = () => {
    console.log("refresh");
    history.push(`/events/${id}/tripRedirect/${tripId}`);
  };

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
                    onChange={e =>
                      setTrip({ ...trip, departureAddress: e.target.value })
                    }
                    readOnly={!isNewTrip}
                  />
                  <InputField
                    label="Leave time"
                    width="100%"
                    type="datetime-local"
                    value={trip.departureTime}
                    onChange={e =>
                      setTrip({ ...trip, departureTime: e.target.value })
                    }
                    // type="date"
                    readOnly={!isNewTrip}
                  />
                  <InputField
                    label="Car"
                    width="100%"
                    value={trip.driver.carModel}
                    onChange={e =>
                      setTrip({
                        ...trip,
                        driver: { ...trip.driver, carModel: e.target.value }
                      })
                    }
                    readOnly={!isNewTrip}
                  />
                  <InputField
                    label="Car plate"
                    width="100%"
                    value={trip.driver.carplate}
                    onChange={e =>
                      setTrip({
                        ...trip,
                        driver: { ...trip.driver, carplate: e.target.value }
                      })
                    }
                    readOnly={!isNewTrip}
                  />
                  <InputField
                    label="Phone number"
                    width="100%"
                    value={trip.driver.phoneNumber}
                    onChange={e =>
                      setTrip({
                        ...trip,
                        driver: { ...trip.driver, phoneNumber: e.target.value }
                      })
                    }
                    readOnly={!isNewTrip}
                  />
                  {isNewTrip ? (
                    <InputField
                      label="Capacity"
                      width="100%"
                      value={trip.capacity}
                      onChange={e =>
                        setTrip({
                          ...trip,
                          capacity: e.target.value
                        })
                      }
                      readOnly={!isNewTrip}
                    />
                  ) : (
                    <ListItemIcon>
                      <DirectionsCarIcon />
                      <Box style={{ textAlign: "left", width: "100%" }}>{`${
                        trip.tripJoinRequests.filter(t => t.approved).length
                      } / ${trip.capacity}`}</Box>
                    </ListItemIcon>
                  )}
                  <div style={{ marginTop: "15px" }}>
                    {isNewTrip ? (
                      <Button
                        variant="contained"
                        color="primary"
                        fullWidth
                        onClick={onSubmit}
                      >
                        Submit
                      </Button>
                    ) : (
                      context.user.id !== trip.driver.id && (
                        <Button
                          variant="contained"
                          color="primary"
                          fullWidth
                          onClick={onJoin}
                        >
                          Request a seat
                        </Button>
                      )
                    )}
                    {!isNewTrip && (
                      <div
                        style={{
                          marginTop: "20px",
                          display: "flex",
                          flexDirection: "column"
                        }}
                      >
                        {trip.tripJoinRequests.map(data => {
                          return (
                            <TripRequestItem
                              data={data}
                              token={context.token}
                              refresh={refresh}
                            />
                          );
                        })}
                      </div>
                    )}
                  </div>
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
