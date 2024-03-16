"use client";
import { HeaderTabs } from "@/components/Header";

import { axios } from "@/utils";
import { useQuery } from "@tanstack/react-query";
import { useRouter } from "next/navigation";

const useCurrentUserProfile = () => {
  const router = useRouter();

  const query = useQuery({
    queryKey: ["current-user"],
    queryFn: async () => {
      try {
        const response = await axios.get("/profiles/me");
        return response.data;
      } catch (error) {
        router.replace("/login?redirect=/portal");
        return null;
      }
    },
  });
  return query;
};

function DashboardLayout({ children }: { children: React.ReactNode }) {
  const { data } = useCurrentUserProfile();
  return (
    <div>
      <HeaderTabs user={data} />
      {children}
    </div>
  );
}

export default DashboardLayout;
