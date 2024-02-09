"use client";
import { Box, Button, Container, Flex, Grid, Text, Title } from "@mantine/core";
import { IconArrowLeft } from "@tabler/icons-react";
import Link from "next/link";
import React from "react";
import classes from "./auth.module.css";
import Image from "next/image";

function AuthLayout({ children }: { children: React.ReactNode }) {
  return (
    <Box bg="gray.1">
      <Button
        component={Link}
        passHref
        variant="subtle"
        href="/"
        styles={{
          root: {
            position: "fixed",
            top: "40px",
            left: "40px",
          },
        }}
        leftSection={<IconArrowLeft />}
      >
        Back To Home
      </Button>
      {/* <Container size="lg" h="100vh" w="100vw" className={classes.container}>
        <div className={classes.card}>
          <div className={classes.cardHeader}>
            <Title order={3} mb="sm" fw="bold" ta="center">
              2tinylink{" "}
            </Title>
            <Text size="sm" c="gray" ta="center">
              Use your email address and password to sign in.
            </Text>
          </div>
        </div>
      </Container> */}
      <div className={classes.container}>
        <div className={classes.left}>
          <div className={classes.card}>{children}</div>
        </div>
        <div className={classes.right}>
          <Image
            objectFit="cover"
            fill
            className={classes.image}
            alt="right side auth layout image"
            src="https://images.unsplash.com/photo-1525770041010-2a1233dd8152?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
          />
        </div>
      </div>
    </Box>
  );
}

export default AuthLayout;
