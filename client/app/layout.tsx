import "@mantine/core/styles.css";
import React from "react";
import { MantineProvider, ColorSchemeScript } from "@mantine/core";
import { theme } from "../theme";
import { HydrationOverlay } from "@builder.io/react-hydration-overlay";

export const metadata = {
  title: "2tinylink app",
  description: "2tinylink app",
};

export default function RootLayout({ children }: { children: any }) {
  return (
    <html lang="en">
      <head>
        <ColorSchemeScript />
        <link rel="shortcut icon" href="/favicon.svg" />
        <meta
          name="viewport"
          content="minimum-scale=1, initial-scale=1, width=device-width, user-scalable=no"
        />
      </head>
      <body>
        <HydrationOverlay>
          <MantineProvider theme={theme}>{children}</MantineProvider>
        </HydrationOverlay>
      </body>
    </html>
  );
}
