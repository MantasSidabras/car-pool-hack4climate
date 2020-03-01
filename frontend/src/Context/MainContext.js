import React, { useEffect } from "react";
import { getUserData } from "../services/axios";

const initialState = {};

const MainContext = React.createContext();

export const MainContextProvider = ({ children }) => {
  const [context, setContext] = React.useState({
    token: localStorage.getItem("token"),
    user: {
      name: "",
      surname: "",
      phone: "",
      car: "",
      carPlate: ""
    },
    userDataFetched: false,
    events: []
  });

  useEffect(() => {
    const fetchUserDetails = async () => {
      const {
        data: { name, surname, ...rest }
      } = await getUserData(context.token);
      setContext({
        ...context,
        user: {
          name: name || "",
          surname: surname || "",
          phone: rest.phoneNumber,
          carPlate: rest.carplate,
          car: rest.carModel
        },
        userDataFetched: true
      });
    };

    localStorage.setItem("token", context.token);
    if (context.token && !context.userDataFetched) {
      fetchUserDetails();
    }
  }, [context]);

  return (
    <MainContext.Provider value={[context, setContext]}>
      {children}
    </MainContext.Provider>
  );
};

export const MainContextConsumer = MainContext.Consumer;
export default MainContext;
