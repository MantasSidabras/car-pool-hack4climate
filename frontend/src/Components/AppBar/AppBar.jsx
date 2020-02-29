import AppBar from '@material-ui/core/AppBar';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import React, { useContext } from 'react';
import { useHistory } from "react-router-dom";
import MainContext from '../../Context/MainContext';
import PATHS from '../Router/RouterPaths';

const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
        height: 50
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
    },
}));


const AppBarComponent = () => {
    const classes = useStyles();
    const history = useHistory();
    const [context, setContext] = useContext(MainContext);
    const onLoginClick = () => {
        history.push(PATHS.login);
    }
    return (
        <AppBar position="sticky" className={classes.root}>
            <Toolbar>
                {/* <IconButton className={classes.menuButton} edge="start" color="inherit" aria-label="menu">
                        <MenuIcon />
                    </IconButton> */}
                <Typography className={classes.title} variant="h6" >
                    Cool car pool
                </Typography>
                {!context.loggedIn ?

                    <Button color="inherit" onClick={onLoginClick}>Login</Button> : <div />}
            </Toolbar>
        </AppBar>

    )
}

export default AppBarComponent;