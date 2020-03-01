import * as React from "react";
import { Redirect, Route, Switch } from "react-router-dom";
import MainContext from "../../Context/MainContext";
import Login from "../Auth/Login";
import Logout from "../Auth/Logout";
import SignUp from "../Auth/SignUp";
import EventDetails from "../MainSection/Event/EventDetails/EventDetails";
import MainSection from "../MainSection/MainSection";
import PATHS from "./RouterPaths";
import TripDetails from "../MainSection/Trip/TripDetails/TripDetails";
import TripRedirect from "../MainSection/Trip/TripDetails/TripRedirect";

const MainRouter = () => {
  const [context, setContext] = React.useContext(MainContext);
  const loggedIn = !!context.token;
  return (
    <Switch>
      <Route path={PATHS.login}>
        {loggedIn ? <Redirect to={PATHS.home} /> : <Login />}
      </Route>
      <Route path={PATHS.signup}>
        {loggedIn ? <Redirect to={PATHS.home} /> : <SignUp />}
      </Route>
      <Route path={PATHS.tripRedirect}>
        {loggedIn ? <TripRedirect /> : <Redirect to={PATHS.login} />}
      </Route>
      <Route path={PATHS.trip}>
        {loggedIn ? <TripDetails /> : <Redirect to={PATHS.login} />}
      </Route>
      <Route path={PATHS.event}>
        {loggedIn ? <EventDetails /> : <Redirect to={PATHS.home} />}
      </Route>
      <Route path={PATHS.home}>
        {loggedIn ? <MainSection /> : <Redirect to={PATHS.login} />}
      </Route>
      <Route path={PATHS.logout}>
        {loggedIn ? <Logout /> : <Redirect to={PATHS.login} />}
      </Route>
      <Route path={"/*"}>
        {loggedIn ? (
          <Redirect to={PATHS.home} />
        ) : (
          <Redirect to={PATHS.login} />
        )}
      </Route>
    </Switch>
  );
};

export default MainRouter;
