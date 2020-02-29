import React, { useEffect, useState } from "react";
import { Grid, Box, makeStyles } from "@material-ui/core";
import { useLocation, useParams } from "react-router-dom";
import MainContext from "../../../../Context/MainContext";
import { getEvents, getEventById } from "../../../../services/axios";

const useStyles = makeStyles(theme => ({
  root: {
    width: "60%",
    height: "500px"
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
    <Box m={3} boxShadow={2} className={classes.root}>
      {error && <h2>Error</h2>}
      {data ? (
        <div>
          <h1>{data.eventName}</h1>
          <Grid content direction="column">
            {JSON.stringify(data)}
          </Grid>
        </div>
      ) : (
        <h2>No data</h2>
      )}
    </Box>
  );
};

export default EventDetails;
