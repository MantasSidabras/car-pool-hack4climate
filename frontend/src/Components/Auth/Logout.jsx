import * as React from "react";
import MainContext from "../../Context/MainContext";

const Logout = () => {
  const [context, setContext] = React.useContext(MainContext);
  React.useEffect(() => {
    setContext({ ...context, token: "", userDataFetched: false });
  }, []);

  return <></>;
};

export default Logout;
