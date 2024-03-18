import "@mantine/core/styles.css";
import React, { ReactNode } from "react";
import { ColorSchemeScript } from "@mantine/core";
import { Providers } from "./providers";

export const metadata = {
  title: "2tinylink app",
  description: "2tinylink app",
};

interface IRootProps {
  children: ReactNode;
}

export default async function RootLayout({ children }: IRootProps) {
  return (
    <html lang="en">
      <head>
        <ColorSchemeScript />
        <meta
          name="viewport"
          content="minimum-scale=1, initial-scale=1, width=device-width, user-scalable=no"
        />
      </head>
      <body>
        <Providers>{children}</Providers>
      </body>
    </html>
  );
}
