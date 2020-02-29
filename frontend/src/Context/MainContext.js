import React from "react";

const initialState = {};

const MainContext = React.createContext();

export const MainContextProvider = ({ children }) => {
  const [context, setContext] = React.useState({
    token: "123",
    user: {
      name: "Jonas Motiejauskas",
      phone: "",
      email: "",
      car: {}
    },
    events: []
  });

  return (
    <MainContext.Provider value={[context, setContext]}>
      {children}
    </MainContext.Provider>
  );
};

export const MainContextConsumer = MainContext.Consumer;
export default MainContext;
