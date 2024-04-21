import CreateLinkModal from "@/components/links/create-link-modal";
import { Box, Container, Group, Title } from "@mantine/core";
import React from "react";

async function LinksPage() {
  return (
    <div>
      <Box
        h="140px"
        display="flex"
        style={{
          alignItems: "center",
          borderBottom: "1px solid rgb(229, 231, 235)",
        }}
      >
        <Container size="xl" w="100%">
          <Group justify="space-between" w="100%">
            <Title order={2}>Links</Title>
            <CreateLinkModal />
          </Group>
        </Container>
      </Box>
    </div>
  );
}

export default LinksPage;
