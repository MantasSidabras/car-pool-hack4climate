import * as React from "react";

import { Switch, Route, Redirect } from "react-router-dom";
import Login from "../Login/Login";
import MainSection from "../MainSection/MainSection";
import PATHS from "./RouterPaths";
import EventDetails from "../MainSection/Event/EventDetails/EventDetails";

const MainRouter = () => {
  return (
    <Switch>
      <Route path={PATHS.login}>
        <Login />
      </Route>
      <Route path={PATHS.event}>
        <EventDetails />
      </Route>
      <Route path={PATHS.home}>
        <MainSection />
      </Route>
      <Route path={"/*"}>
        <Redirect to={PATHS.home} />
      </Route>
    </Switch>
  );
};

export default MainRouter;
