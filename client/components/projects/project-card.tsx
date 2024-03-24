"use client";

import { Card, Group, Avatar, Title } from "@mantine/core";
import Link from "next/link";

function ProjectCard({
  id,
  name,
  slug,
  logo,
  usage,
  plan,
}: {
  id: string;
  name: string;
  slug: string;
  logo: string;
  usage: string;
  plan: string;
}) {
  return (
    <Card
      shadow="sm"
      padding="lg"
      radius="md"
      withBorder
      component={Link}
      href={`/projects/${slug}`}
    >
      <Card.Section p="md">
        <Group mb="xl">
          <Avatar color="cyan" radius="xl">
            MK
          </Avatar>
          <div>
            <Title order={4}>JAMAL ID AISSA</Title>
          </div>
        </Group>
        <div style={{ padding: "0px 10px" }}>
          <span style={{ color: "gray" }}>2 links</span>
        </div>
      </Card.Section>
    </Card>
  );
}

export default ProjectCard;
