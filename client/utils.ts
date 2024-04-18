import ax from "axios";
import { getSession } from "next-auth/react";

const baseURL = "https://localhost:7054/api";
// export const version = "v1";
// export const baseURL =
//   process.env.NODE_ENV === "production"
//     ? "https://localhost:7112/api" //'http://lockas-001-site1.dtempurl.com/api'
//     : "https://localhost:7112/api";

export const axios = () => {
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
