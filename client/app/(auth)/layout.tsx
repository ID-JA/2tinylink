"use client";
import { Box, Button } from "@mantine/core";
import { IconArrowLeft } from "@tabler/icons-react";
import Link from "next/link";
import React from "react";
import classes from "./auth.module.css";
import Image from "next/image";

function AuthLayout({ children }: { children: React.ReactNode }) {
  return (
    <Box bg="gray.1">
      <div className={classes.container}>
        <div className={classes.left}>
          <Button
            component={Link}
            passHref
            variant="subtle"
            href="/"
            leftSection={<IconArrowLeft className={classes.backIcon} />}
            className={classes.backButton}
          >
            Back To Home
          </Button>
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
