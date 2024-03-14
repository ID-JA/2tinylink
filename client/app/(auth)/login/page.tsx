"use client";
import { GoogleButton } from "@/components/GoogleButton";
import { axios } from "@/utils";
import { Button, Divider, Text, TextInput, Title } from "@mantine/core";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import Link from "next/link";
import { useRouter } from "next/navigation";

const useLogin = () => {
  const router = useRouter();
  const queryClient = useQueryClient();

  const mutation = useMutation({
    mutationKey: ["login"],
    mutationFn: async () => {
      const response = await axios.post("/auth/login", {
        userNameOrEmail: "Jermey78@yahoo.com",
        password: "Pa$$w0rd",
      });
      return response.data;
    },
    onSuccess: (data) => {
      localStorage.setItem("token", data?.token);
      queryClient.setQueryData(["CURRENT_USER"], data);
      router.push("/portal");
    },
  });

  return mutation;
};

function LoginPage() {
  const { mutate, isPending } = useLogin();
  return (
    <>
      <Title ta="center" order={3}>
        Sign in to 2tinyLink
      </Title>
      <Text ta="center" size="sm" mt="xs" c="gray">
        Start creating short links with superpowers
      </Text>
      <GoogleButton mt="lg" fullWidth>
        Google
      </GoogleButton>
      <Divider label="OR" color="gray.5" my="sm" />

      <form
        onSubmit={(e) => {
          e.preventDefault();
          mutate();
        }}
      >
        <TextInput my="sm" label="Email" disabled={isPending} />
        <TextInput mb="sm" label="Password" disabled={isPending} />
        <Text href="/register" size="sm" c="gray" component={Link}>
          Forgot your password ?
        </Text>{" "}
        <Button fullWidth mt="lg" type="submit" loading={isPending}>
          Log in
        </Button>
      </form>
      <Text ta="center" c="gray" mb="lg" size="sm" mt="lg">
        Don&apos;t have an account?{" "}
        <Text
          href="/register"
          c="black"
          fw="bold"
          td="underline"
          component={Link}
        >
          Sign Up
        </Text>{" "}
        for free.
      </Text>
    </>
  );
}

export default LoginPage;
