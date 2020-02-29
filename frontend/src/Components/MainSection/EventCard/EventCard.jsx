import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import Card from "@material-ui/core/Card";
import CardActionArea from "@material-ui/core/CardActionArea";
import CardActions from "@material-ui/core/CardActions";
import CardContent from "@material-ui/core/CardContent";
import CardMedia from "@material-ui/core/CardMedia";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";

const useStyles = makeStyles({
  root: {
    width: "100%"
  },
  container: {
    display: "flex"
  },
  image: {
    width: "140px",
    height: "140px"
  }
});

const EventCard = ({ eventInfo }) => {
  const classes = useStyles();
  return (
    <Card className={classes.root}>
      <CardActionArea className={classes.container}>
        <CardMedia
          component="img"
          alt={eventInfo.name}
          image={require("./h4c.jpg")}
          title={eventInfo.name}
          className={classes.image}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            {eventInfo.name}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p">
            {eventInfo.summary}
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
