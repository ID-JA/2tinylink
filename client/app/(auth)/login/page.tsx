import { GoogleButton } from "@/components/GoogleButton";
import { Button, Divider, Text, TextInput, Title } from "@mantine/core";
import Link from "next/link";
import React from "react";

function LoginPage() {
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
      <form>
        <TextInput my="lg" label="Email" />
        <TextInput mb="lg" label="Password" />
        <Button fullWidth>Log in</Button>
      </form>
      <Text ta="center" c="gray" size="sm" mt="lg">
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
