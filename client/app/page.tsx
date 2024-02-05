import { ColorSchemeToggle } from "@/components/ColorSchemeToggle/ColorSchemeToggle";
import classes from "./home.module.css";
import {
  ActionIcon,
  Box,
  Button,
  Container,
  Text,
  TextInput,
  Title,
  px,
  rem,
} from "@mantine/core";
import { IconArrowBack, IconLink } from "@tabler/icons-react";
import NextImage from "next/image";
import React from "react";

function Page() {
  return (
    <>
      <header className={classes.header}>
        <div className={classes.headerContent}>
          <Text fw="700" size="lg">
            2tinyLink
          </Text>
          <Button>Sign in</Button>
        </div>
      </header>
      <Container size="lg">
        <Box>
          <Box mb="xl" pos="relative" maw="600px" mx="auto" mt={rem(64)}>
            <NextImage
              style={{
                top: 0,
                left: "-6%",
                position: "absolute",
              }}
              className={classes.sparkle}
              width={48}
              height={48}
              src="/left_sparkle.gif"
              alt="left_sparkle.gif"
            />
            <NextImage
              data-left
              style={{
                top: 0,
                right: "-5%",
                position: "absolute",
              }}
              className={classes.sparkle}
              width={48}
              height={48}
              src="/right_sparkle.gif"
              alt="right_sparkle.gif"
            />
            <Title className={classes.title}>
              Simplify Navigation with{" "}
              <Text
                component="span"
                inherit
                variant="gradient"
                gradient={{ from: "pink", to: "yellow", deg: 90 }}
              >
                Short Links
              </Text>{" "}
            </Title>

            <Text ta="center" c="gray.7" mb="xl">
              Shorten and manage your web links efficiently with our easy-to-use
              short URL app.
            </Text>
            <TextInput
              placeholder="https://www.github.com/ID-JA/2tinylink"
              size="md"
              rightSectionPointerEvents="all"
              leftSection={
                <IconLink
                  style={{ width: "70%", height: "70%" }}
                  stroke={1.5}
                />
              }
              rightSection={
                <ActionIcon variant="light">
                  <IconArrowBack
                    style={{ width: "70%", height: "70%" }}
                    stroke={1.5}
                  />
                </ActionIcon>
              }
            />
          </Box>
        </Box>
      </Container>
    </>
  );
}

export default Page;
