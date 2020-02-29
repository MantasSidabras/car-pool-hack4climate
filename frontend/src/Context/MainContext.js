import React, { useEffect } from "react";

const initialState = {};

const MainContext = React.createContext();

export const MainContextProvider = ({ children }) => {
  const [context, setContext] = React.useState({
    token: localStorage.getItem("token"),
    user: {
      name: "",
      surname: "",
      phone: "",
      email: "",
      car: "",
      carPlate: ""
    },
    events: []
  });

  useEffect(() => {
    localStorage.setItem("token", context.token);
  }, [context.token]);

  return (
    <MainContext.Provider value={[context, setContext]}>
      {children}
    </MainContext.Provider>
  );
};

export const MainContextConsumer = MainContext.Consumer;
export default MainContext;
