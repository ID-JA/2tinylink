import { baseURL } from "@/utils";
import axios from "axios";

export const userService = {
  authenticate,
};

async function authenticate({
  userNameOrEmail,
  password,
}: {
  userNameOrEmail: string;
  password: string;
}) {
  console.log("BASEURL - BASEURL", baseURL);
  const response = await axios.post(
    `${baseURL}/auth/login`,
    {
      userNameOrEmail,
      password,
    },
    {
      method: "POST",
      headers: { "Content-Type": "application/json" },
    }
  );
  const data = response.data;
  return data?.token ? data : null;
}
