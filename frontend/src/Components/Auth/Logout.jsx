import * as React from "react";
import MainContext from "../../Context/MainContext";

const Logout = () => {
  const [context, setContext] = React.useContext(MainContext);

  React.useEffect(() => {
    setContext({ ...context, token: "" });
  }, []);

  return <></>;
};

export default Logout;
