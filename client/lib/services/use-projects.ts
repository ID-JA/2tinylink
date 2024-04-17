import { axios } from "@/utils";
import { useQuery } from "@tanstack/react-query";

export default function useProjects() {
  const {
    data: projects,
    error,
    isLoading,
  } = useQuery({
    queryKey: ["projects"],
    queryFn: async () => {
      const response = await axios().get("/projects");
      return response.data;
    },
  });

  return {
    projects,
    error,
    loading: !isLoading && !error && !projects,
  };
}
