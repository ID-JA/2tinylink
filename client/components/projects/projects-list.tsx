"use client";
import { SimpleGrid } from "@mantine/core";
import ProjectCard from "./project-card";
import useProjects from "@/lib/services/use-projects";

const PROJECTS = [
  {
    id: "1",
    name: "JAMAL ID AISSA",
    slug: "jamalid",
    logo: "/logo.png",
    usage: "2",
    plan: "Free",
  },
];

function ProjectsList() {
  const { loading, projects } = useProjects();
  return (
    <>
      {loading}
      <SimpleGrid
        cols={{ base: 1, sm: 2, lg: 3 }}
        spacing={{ base: 10, sm: "xl" }}
        verticalSpacing={{ base: "md", sm: "xl" }}
        my="xl"
      >
        {PROJECTS.map((project) => (
          <ProjectCard key={project.id} {...project} />
        ))}
      </SimpleGrid>
    </>
  );
}

export default ProjectsList;
