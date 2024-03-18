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
  const response = await fetch("https://localhost:7054/api/auth/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userNameOrEmail, password }),
  });
  const data = await response.json();
  return data?.token ? data : null;
}
