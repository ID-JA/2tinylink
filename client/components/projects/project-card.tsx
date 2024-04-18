"use client";

import { ProjectProps } from "@/lib/services/use-projects";
import { Card, Group, Avatar, Title } from "@mantine/core";
import Link from "next/link";

function ProjectCard({ id, name, description }: ProjectProps) {
  return (
    <Card
      shadow="sm"
      padding="lg"
      radius="md"
      withBorder
      component={Link}
      href={`/projects/${id}`} // slug
    >
      <Card.Section p="md">
        <Group mb="xl">
          <Avatar
            src={`https://api.dicebear.com/8.x/shapes/svg?seed=${name}`}
            radius="xl"
            alt={name}
          />
          <div>
            <Title order={4}>{name}</Title>
          </div>
        </Group>
        <div style={{ padding: "0px 10px" }}>
          {description}
          <span style={{ color: "gray" }}>2 links</span>
        </div>
      </Card.Section>
    </Card>
  );
}

export default ProjectCard;
