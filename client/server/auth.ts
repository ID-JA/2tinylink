import { NextAuthOptions, getServerSession } from "next-auth";
import Credentials from "next-auth/providers/credentials";
import { userService } from "./services/userService";

export const authOptions: NextAuthOptions = {
  session: {
    strategy: "jwt", //(1)
  },
  callbacks: {
    async jwt({ token, account }) {
      if (account && account.type === "credentials") {
        //(2)
        token.userId = account.providerAccountId; // this is Id that coming from authorize() callback
      }
      return token;
    },
    async session({ session, token }) {
      session.user.id = token.userId; //(3)
      return session;
    },
  },
  pages: {
    signIn: "/login", //(4) custom signin page path
  },
  providers: [
    Credentials({
      name: "Credentials",
      credentials: {
        username: { label: "Username", type: "text", placeholder: "username" },
        password: { label: "Password", type: "password" },
      },
      async authorize(credentials, req) {
        console.log("🚀 ~ authorize ~ credentials:", credentials);
        const { username, password } = credentials as {
          username: string;
          password: string;
        };
        // const user = { id: "1", name: "J Smith", email: "jsmith@example.com" };

        return userService.authenticate({
          userNameOrEmail: username,
          password,
        }); //(5)
        // return user;
      },
    }),
  ],
};

export const getServerAuthSession = () => getServerSession(authOptions); //(6)
