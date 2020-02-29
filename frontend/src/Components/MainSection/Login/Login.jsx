import * as React from 'react'
import { Box, Grid, Input, makeStyles, Button } from '@material-ui/core'


const useStyles = makeStyles(theme => ({
    root: {
        // width: '50%',
        height: '100%'
    },
}));

const Login = () => {
    const classes = useStyles();

    return (
        <Box m={3}>
            <Grid container direction="column" justify="center" className={classes.root}>
                {/* <h2>Login</h2> */}
                <Button variant="contained">
                    Sign in with facebook
                </Button>
            </Grid>
        </Box>
    )
}

export default Login;