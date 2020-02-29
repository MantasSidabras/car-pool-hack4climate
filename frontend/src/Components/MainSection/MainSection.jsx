import * as React from 'react'
import { Box, makeStyles, Grid } from '@material-ui/core';
import MainRouter from '../Router/MainRouter';

const useStyles = makeStyles(theme => ({
    root: {
        width: '60%',
        height: '500px',
        backgroundColor: 'white'
    },
}));

const MainSection = () => {
    const classes = useStyles();


    return (
        <Grid container
            direction="row"
            justify="center"
            alignItems="center"
        >
            <Box m={4} boxShadow={0} className={classes.root}>
                <MainRouter />
            </Box >
        </Grid>
    )
}

export default MainSection;