import ax from "axios";
import { getSession } from "next-auth/react";

// export const version = "v1";
export const baseURL =
  process.env.NODE_ENV === "production"
    ? process.env.NEXT_PUBLIC_SERVER_API_URL_PROD
    : process.env.NEXT_PUBLIC_SERVER_API_URL_DEV;

export const axios = () => {
  console.log("BASEURL", baseURL);
  const defaultOptions = {
    baseURL,
  };

  const instance = ax.create(defaultOptions);

  instance.interceptors.request.use(async (request) => {
    const session = await getSession();
    if (session) {
      request.headers.Authorization = `Bearer ${session.user.token}`;
    }
    return request;
  });

  instance.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      console.log(`error`, error);
    }
  );

  return instance;
};
