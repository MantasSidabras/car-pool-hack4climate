import * as React from 'react';

import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Login from '../Login/Login';
import MainSection from '../MainSection/MainSection';
import PATHS from './RouterPaths';

const MainRouter = () => {
    return (

        <Switch>
            {/* <Route path="/main">
                <About />
            </Route> */}
            <Route path={PATHS.login}>
                <Login />
            </Route>
            <Route path={PATHS.home}>
                <MainSection />
            </Route>
        </Switch>
    )
}

export default MainRouter;