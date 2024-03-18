import ax from "axios";

// export const version = "v1";
// export const baseURL =
//   process.env.NODE_ENV === "production"
//     ? "https://localhost:7112/api" //'http://lockas-001-site1.dtempurl.com/api'
//     : "https://localhost:7112/api";

export const axios = ax.create({
  baseURL: "https://localhost:7054/api",
  headers: { "Content-Type": "application/json", charset: "utf-8" },
});

// Set the AUTH token for any request
axios.interceptors.request.use((config) => {
  const token = localStorage.getItem("token");
  if (config.headers && token) {
    config.headers.Authorization = token ? `Bearer ${token}` : "";
  }

  return config;
});
