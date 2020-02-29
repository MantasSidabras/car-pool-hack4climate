import * as React from 'react';

import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link
} from "react-router-dom";
import Login from '../MainSection/Login/Login';

const MainRouter = () => {
    return (
        <Router>

            <Switch>
                {/* <Route path="/main">
                <About />
            </Route> */}
                {/* <Route path="/login">
                <login />
            </Route> */}
                <Route path="/">
                    <Login />
                </Route>
            </Switch>
        </Router>
    )
}

export default MainRouter;