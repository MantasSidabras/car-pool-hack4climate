import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import { makeStyles } from "@material-ui/core/styles";
import Typography from "@material-ui/core/Typography";
import React from "react";

const useStyles = makeStyles({
  root: {
    width: "100%"
  },
  container: {
    display: "flex",
    justifyContent: "flex-start"
  },
  image: {
    width: "140px",
    height: "140px"
  }
});

const EventCard = ({ eventInfo, onEventSelect }) => {
  const classes = useStyles();
  return (
    <Card className={classes.root} onClick={onEventSelect}>
      <CardActionArea className={classes.container}>
        <CardMedia
          component="img"
          alt={eventInfo.eventName}
          image={eventInfo.logoUri}
          title={eventInfo.eventName}
          className={classes.image}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            {eventInfo.eventName}
          </Typography>
          <Typography variant="body2" component="p">
            {new Date(eventInfo.eventTime).toDateString()}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p">
            {eventInfo.address}
          </Typography>
        </CardContent>
      </CardActionArea>
      {/* <CardActions>
        <Button size="small" color="primary">
          Learn More
        </Button>
      </CardActions> */}
    </Card>
  );
};

export default EventCard;
