import axios from "axios";
import { BACKEND_URL } from "../Config";

if (!BACKEND_URL) {
  console.log("backend URL missing");
}

export const backendHttpClient = axios.create({
  baseURL: BACKEND_URL,
  headers: { "content-type": "application/json" },
  timeout: 10 * 1000
});

export const getEvents = async () => {
  try {
    const { data } = await backendHttpClient.get("/events");
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};

export const getEventById = async id => {
  try {
    const { data } = await backendHttpClient.get(`/event/${id}`);
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};

export const register = async (
  name,
  surname,
  phoneNumber,
  password,
  carplate,
  carModel
) => {
  try {
    const { data } = await backendHttpClient.post(`/participant/register`, {
      name,
      surname,
      phoneNumber,
      password,
      carplate,
      carModel
    });
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};

export const login = async (phoneNumber, password) => {
  try {
    const { data } = await backendHttpClient.post(`/participant/login`, {
      phoneNumber,
      password
    });
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};
