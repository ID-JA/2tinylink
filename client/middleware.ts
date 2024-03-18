import { getToken } from "next-auth/jwt";
import { NextFetchEvent, NextRequest, NextResponse } from "next/server";

export const config = {
  matcher: ["/((?!api/|_next/|_proxy/|_static|_vercel|[\\w-]+\\.\\w+).*)"],
};

export default async function middleware(req: NextRequest, _: NextFetchEvent) {
  const path = req.nextUrl.pathname;
  const searchParams = req.nextUrl.searchParams.toString();

  const fullPath = `${path}${
    searchParams.length > 0 ? `?${searchParams}` : ""
  }`;
  const session = await getToken({
    req,
  });

  if (!session?.email && path !== "/login") {
    return NextResponse.redirect(
      new URL(
        `/login${path === "/" ? "" : `?next=${encodeURIComponent(fullPath)}`}`,
        req.url
      )
    );
  } else if (session?.email) {
    if (path === "/login" || path === "/register") {
      return NextResponse.redirect(new URL("/portal", req.url));
    }
  }
  return NextResponse.rewrite(
    new URL(`${fullPath === "/" ? "" : fullPath}`, req.url)
  );
}
