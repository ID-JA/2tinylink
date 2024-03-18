import { GoogleButton } from "@/components/GoogleButton";
import { Title, TextInput, Button, Text, Divider, Group } from "@mantine/core";
import Link from "next/link";

function RegisterPage() {
  return (
    <div>
      <Title ta="center" order={3}>
        Sign up to 2tinyLink
      </Title>
      <Text ta="center" size="sm" mt="xs" c="gray">
        Start creating short links with superpowers
      </Text>
      <GoogleButton mt="lg" fullWidth>
        Google
      </GoogleButton>
      <Divider label="OR" color="gray.5" my="sm" />
      <form>
        <Group>
          <TextInput label="First Name" />
          <TextInput label="Last Name" />
        </Group>
        <TextInput my="sm" label="Email" />
        <TextInput mb="lg" label="Password" />
        <Button fullWidth>Sign up</Button>
      </form>
      <Text ta="center" c="gray" size="sm" mt="lg">
        Already have an account?{" "}
        <Text href="/login" c="black" fw="bold" td="underline" component={Link}>
          Log In.
        </Text>
      </Text>
    </div>
  );
}

export default RegisterPage;
