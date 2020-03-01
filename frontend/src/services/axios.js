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

export const getEvents = async token => {
  try {
    const { data } = await backendHttpClient.get("/events", {
      headers: { Authorization: `Bearer ${token}` }
    });
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};

export const getEventById = async (id, token) => {
  try {
    const { data } = await backendHttpClient.get(`/event/${id}`, {
      headers: { Authorization: `Bearer ${token}` }
    });
    return { data };
  } catch (error) {
    console.error(error);
    return { error };
  }
};

export const getTripById = async (id, token) => {
  try {
    const { data } = await backendHttpClient.get(`/trip/${id}`, {
      headers: { Authorization: `Bearer ${token}` }
    });
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

export const getUserData = async token => {
  try {
    const { data } = await backendHttpClient.get(`/participant`, {
      headers: { Authorization: `Bearer ${token}` }
    });
    return { data };
  } catch (error) {
    return { error };
  }
};

export const createTrip = async (
  token,
  eventId,
  fromAddress,
  departureTime,
  capacity
) => {
  try {
    const { data } = await backendHttpClient.post(
      `/trip/init`,
      {
        eventId: Number(eventId),
        // driverId: 3,
        fromAddress,
        departureTime,
        capacity: Number(capacity)
      },
      {
        headers: { Authorization: `Bearer ${token}` }
      }
    );
    return { data };
  } catch (error) {
    return { error };
  }
};

export const joinTrip = async (token, tripId) => {
  try {
    const { data } = await backendHttpClient.post(
      `/trip/join`,
      {
        tripId: Number(tripId),
        pickUpAddress: "Gabijos 43"
      },
      {
        headers: { Authorization: `Bearer ${token}` }
      }
    );
    return { data };
  } catch (error) {
    return { error };
  }
};

export const approveTrip = async (token, tripJoinRequestId, accept) => {
  try {
    const { data } = await backendHttpClient.post(
      `/trip-request/approve/${tripJoinRequestId}`,
      accept,
      {
        headers: { Authorization: `Bearer ${token}` }
      }
    );
    return { data };
  } catch (error) {
    return { error };
  }
};
