"use client";

import { SimpleGrid } from "@mantine/core";
import ProjectCard from "./project-card";
import useProjects from "@/lib/services/use-projects";

function ProjectsList() {
  const { projects } = useProjects();
  return (
    <SimpleGrid
      cols={{ base: 1, sm: 2, lg: 3 }}
      spacing={{ base: 10, sm: "xl" }}
      verticalSpacing={{ base: "md", sm: "xl" }}
      my="xl"
    >
      {projects?.map((project) => (
        <ProjectCard key={project.id} {...project} />
      ))}
    </SimpleGrid>
  );
}

export default ProjectsList;
