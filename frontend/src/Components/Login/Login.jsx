import * as React from 'react'
import { Box, Grid, Input, makeStyles, Button } from '@material-ui/core'
import { useHistory } from "react-router-dom";
import MainContext from '../../Context/MainContext';



const useStyles = makeStyles(theme => ({
    root: {
        height: '500px',
    },
    col: {
        height: '100%'
    },
    button: {
    }
}));



const Login = () => {
    const history = useHistory();
    const [context, setContext] = React.useContext(MainContext);

    const classes = useStyles();

    const onLoginClick = () => {
        setContext({ ...context, loggedIn: true });
        history.push("/");
    }
    return (
        <Grid container
            direction="row"
            justify="center"
            alignItems="center"
            className={classes.root}
        >
            <Grid container direction="column" justify='center' alignItems="center" className={classes.col}>
                {/* <h2>Login</h2> */}

                <Button variant="contained" size="medium" className={classes.button} onClick={onLoginClick}>
                    Sign in with facebook
                </Button>
            </Grid>
        </Grid>
    )
}

export default Login;