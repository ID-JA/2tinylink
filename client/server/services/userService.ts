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
  const response = await fetch("http://localhost:5132/api/auth/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ userNameOrEmail, password }),
  });
  console.log({
    response,
  });
  const data = await response.json();
  return data?.token ? data : null;
}
