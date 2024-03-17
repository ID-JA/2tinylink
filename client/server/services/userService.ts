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
  const data = (await response.json()) as { token: string };

  if (data?.token) {
    return {
      name: "Jamal Id AIssa",
      email: "jamal@idaissa.io",
      id: "0",
      token: data.token,
    };
  }
  return null;
}
