import { baseURL } from "@/utils";

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
  const response = await fetch(`${baseURL}/auth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userNameOrEmail, password }),
  });
  const data = await response.json();
  return data?.token ? data : null;
}
