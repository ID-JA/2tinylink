import { Card, Group, Skeleton } from "@mantine/core";

function ProjectPlaceholder() {
  return (
    <Card shadow="sm" padding="lg" radius="md" withBorder>
      <Card.Section p="md">
        <Group mb="xl">
          <Skeleton height={50} circle />
          <div style={{ width: "80%" }}>
            <Skeleton height={8} width="50%" mb="md" radius="xl" />
            <Skeleton height={8} width="30%" radius="xl" />
          </div>
        </Group>
        <div>
          <Skeleton height={8} width="100%" mb="md" radius="xl" />
          <Group justify="space-between">
            <Skeleton height={8} width="50%" radius="xl" />
            <Skeleton height={10} width="10%" radius="xl" />
          </Group>
        </div>
      </Card.Section>
    </Card>
  );
}
export default ProjectPlaceholder;
