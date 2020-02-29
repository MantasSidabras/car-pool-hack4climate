import { List, ListItem } from "@material-ui/core";
import React from "react";
import EventCard from "../EventCard/EventCard";

const EventList = ({ events, onEventSelect }) => {
  return (
    <List>
      {events.map((event, id) => {
        return (
          <ListItem key={id}>
            <EventCard eventInfo={event} onEventSelect={onEventSelect} />
          </ListItem>
        );
      })}
    </List>
  );
};

export default EventList;
