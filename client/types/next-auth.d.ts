import NextAuth, { DefaultSession, DefaultJWT } from "next-auth";
import { JWT } from "next-auth/jwt";

declare module "next-auth" {
  interface Session extends DefaultSession {
    user: User;
  }
}

declare module "next-auth/jwt" {
  interface JWT {
    userId: string;
    user: User;
  }
}

export type User = {
  id?: string | null;
  token?: string | null;
  email?: string | null;
  userName?: string | null;
  emailConfirmed?: boolean | null;
  createdAt?: string | null;
};
