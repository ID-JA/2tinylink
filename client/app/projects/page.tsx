import ProjectsList from "@/components/projects/projects-list";
import { Box, Button, Container, Group, Title } from "@mantine/core";

async function ProjectsPage() {
  return (
    <>
      <Box
        h="140px"
        display="flex"
        style={{
          alignItems: "center",
          borderBottom: "1px solid rgb(229, 231, 235)",
        }}
      >
        <Container w="100%">
          <Group justify="space-between" w="100%">
            <Title>My Projects</Title>
            <Button>Create Project</Button>
          </Group>
        </Container>
      </Box>
      <Container size="xl">
        <ProjectsList />
      </Container>
    </>
  );
}

export default ProjectsPage;
