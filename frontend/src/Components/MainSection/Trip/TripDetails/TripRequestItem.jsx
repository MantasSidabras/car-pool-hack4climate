import React from "react";
import { Button, Box } from "@material-ui/core";
import DoneOutlineIcon from "@material-ui/icons/DoneOutline";
import CloseIcon from "@material-ui/icons/Close";
import { approveTrip } from "../../../../services/axios";
const TripRequestItem = ({
  data: { passenger, approved, id, ...rest },
  token,
  refresh
}) => {
  const acceptTrip = async () => {
    const { data } = await approveTrip(token, id, true);
    refresh();
  };

  const dennyTrip = async () => {
    const { data } = await approveTrip(token, id, false);
    refresh();
  };

  return (
    <Box p={2} boxShadow={3} style={{ marginBottom: "10px" }}>
      <div>{`${passenger.name} ${passenger.surname} (${passenger.phoneNumber})`}</div>
      <div style={{ display: "flex", justifyContent: "space-around" }}>
        {approved === null ? (
          <>
            <Button
              variant="contained"
              color="primary"
              size="small"
              onClick={acceptTrip}
            >
              Accept
            </Button>
            <Button
              variant="contained"
              color="secondary"
              size="small"
              onClick={dennyTrip}
            >
              Reject
            </Button>
          </>
        ) : approved ? (
          <DoneOutlineIcon />
        ) : (
          <CloseIcon />
        )}
      </div>
    </Box>
  );
};

export default TripRequestItem;
