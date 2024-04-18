import CreateProjectModal from "@/components/projects/create-project-modal";
import ProjectsList from "@/components/projects/projects-list";
import {
  Box,
  Button,
  Container,
  Group,
  SimpleGrid,
  Title,
} from "@mantine/core";

function ProjectsPage() {
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
            <CreateProjectModal />
          </Group>
        </Container>
      </Box>
      <Container size="xl">
        <SimpleGrid
          cols={{ base: 1, sm: 2, lg: 3 }}
          spacing={{ base: 10, sm: "xl" }}
          verticalSpacing={{ base: "md", sm: "xl" }}
          my="xl"
        >
          <ProjectsList />
        </SimpleGrid>
      </Container>
    </>
  );
}

export default ProjectsPage;
