import { getServerAuthSession } from "@/server/auth";
import Link from "next/link";

async function ProjectsPage() {
  const authSession = await getServerAuthSession();

  return (
    <div>
      <pre>{JSON.stringify(authSession, null, 2)}</pre>
      {authSession?.user && (
        <pre>{JSON.stringify(authSession?.user, null, 2)}</pre>
      )}{" "}
      {!authSession?.user && ( //(3)
        <Link
          className="font-medium mt-2 text-blue-600 hover:underline"
          href="/login"
        >
          Login
        </Link>
      )}
    </div>
  );
}

export default ProjectsPage;
