import * as React from "react";

import { Switch, Route, Redirect } from "react-router-dom";
import Auth from "../Auth/Auth";
import MainSection from "../MainSection/MainSection";
import PATHS from "./RouterPaths";
import EventDetails from "../MainSection/Event/EventDetails/EventDetails";
import Logout from "../Auth/Logout";
import MainContext from "../../Context/MainContext";

const MainRouter = () => {
  const [context, setContext] = React.useContext(MainContext);
  const loggedIn = !!context.token;

  return (
    <Switch>
      <Route path={PATHS.auth}>
        {loggedIn ? <Redirect to={PATHS.home} /> : <Auth />}
      </Route>
      <Route path={PATHS.event}>
        {loggedIn ? <EventDetails /> : <Redirect to={PATHS.home} />}
      </Route>
      <Route path={PATHS.home}>
        {loggedIn ? <MainSection /> : <Redirect to={PATHS.home} />}
      </Route>
      <Route path={PATHS.logout}>
        <Logout />
      </Route>
      <Route path={"/*"}>
        {loggedIn ? <Redirect to={PATHS.home} /> : <Redirect to={PATHS.auth} />}
      </Route>
    </Switch>
  );
};

export default MainRouter;
