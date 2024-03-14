"use client";
import {
  ActionIcon,
  Box,
  Button,
  Container,
  Flex,
  Text,
  TextInput,
  Title,
  rem,
} from "@mantine/core";
import { IconArrowBack, IconLink } from "@tabler/icons-react";
import NextImage from "next/image";
import Link from "next/link";
import classes from "./home.module.css";

function HomePage() {
  return (
    <>
      <header className={classes.header}>
        <div className={classes.headerContent}>
          <Text fw="700" size="lg">
            2tinyLink
          </Text>
          <Flex gap="md">
            <Button component={Link} href="/register" variant="outline">
              Login
            </Button>
            <Button component={Link} href="/register">
              Register
            </Button>
          </Flex>
        </div>
      </header>
      <Container size="lg">
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
              gradient={{ from: "red", to: "yellow", deg: 90 }}
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
              <IconLink style={{ width: "70%", height: "70%" }} stroke={1.5} />
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
      </Container>
    </>
  );
}

export default HomePage;
