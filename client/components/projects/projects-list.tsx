"use client";
import { SimpleGrid } from "@mantine/core";
import ProjectCard from "./project-card";

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
  return (
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
  );
}

export default ProjectsList;
