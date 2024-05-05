"use client";

import ProjectCard from "./project-card";
import useProjects from "@/lib/services/use-projects";
import ProjectPlaceholder from "./project-placeholder";

function ProjectsList() {
  const { projects, loading } = useProjects();

  if (loading) {
    return Array.from({ length: 6 }).map((_, i) => (
      <ProjectPlaceholder key={i} />
    ));
  }

  if (projects?.length === 0) {
    return <div>No projects found</div>;
  }

  return projects?.map((project) => (
    <ProjectCard key={project.id} {...project} />
  ));
}

export default ProjectsList;
