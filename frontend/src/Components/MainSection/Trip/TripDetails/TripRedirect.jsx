import React, { useState, useEffect, useContext } from "react";
import { useParams, useLocation, useHistory } from "react-router-dom";
import { Grid, Box, makeStyles, Button, ListItemIcon } from "@material-ui/core";
import { getTripById, createTrip, joinTrip } from "../../../../services/axios";
import InputField from "../../../Other/InputField";
import DirectionsCarIcon from "@material-ui/icons/DirectionsCar";
import MainContext from "../../../../Context/MainContext";
import TripRequestItem from "./TripRequestItem";

const TripRedirect = () => {
  const { id, tripId } = useParams();
  const history = useHistory();

  useEffect(() => {
    history.push(`/events/${id}/trip/${tripId}`);
  }, []);

  return <>Loading...</>;
};

export default TripRedirect;
