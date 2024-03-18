"use client";
import { GoogleButton } from "@/components/GoogleButton";
import { axios } from "@/utils";
import { Button, Divider, Text, TextInput, Title } from "@mantine/core";
import { useMutation } from "@tanstack/react-query";
import Link from "next/link";
import { useRouter, useSearchParams } from "next/navigation";
import { signIn } from "next-auth/react";

const useLogin = () => {
  const router = useRouter();
  const searchParams = useSearchParams();

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
      if (searchParams.get("redirect")) {
        router.push(searchParams.get("redirect") as string);
      } else {
        router.push("/portal");
      }
    },
  });

  return mutation;
};

function LoginPage() {
  const { mutate, isPending } = useLogin();
  const handleLogin = async () => {
    await signIn("credentials", {
      username: "Jermey78@yahoo.com",
      password: "Pa$$w0rd",
      callbackUrl: "/portal",
    });
  };
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
          handleLogin();
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
