import { GoogleButton } from "@/components/GoogleButton";
import {
  Button,
  Checkbox,
  Divider,
  Text,
  TextInput,
  Title,
} from "@mantine/core";
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
      <Divider label="OR" color="gray.5" my="sm" />

      <form>
        <TextInput my="sm" label="Email" />
        <TextInput mb="sm" label="Password" />
        <Text href="/register" size="sm" c="gray" component={Link}>
          Forgot your password ?
        </Text>{" "}
        <Button fullWidth mt="lg">
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
