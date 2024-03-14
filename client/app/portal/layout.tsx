"use client";
import { HeaderTabs } from "@/components/Header";

import { axios } from "@/utils";
import { useQuery } from "@tanstack/react-query";

const useCurrentUserProfile = () => {
  const query = useQuery({
    queryKey: ["current-user"],
    queryFn: async () => {
      const response = await axios.get("/profiles/me");
      return response.data;
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
