"use client";

import { Button, Modal, TextInput, Title } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";

function CreateProjectModal() {
  const [opened, { open, close }] = useDisclosure(false);

  return (
    <>
      <Modal
        padding="0px"
        radius="md"
        opened={opened}
        onClose={close}
        withCloseButton={false}
        centered
        overlayProps={{
          backgroundOpacity: 0.55,
          blur: 3,
        }}
      >
        <div
          style={{
            padding: "2rem 4rem",
            borderBottom: "1px solid rgb(229, 231, 235)",
          }}
        >
          <Title ta="center" order={3}>
            Create new project
          </Title>
        </div>
        <form style={{ padding: "2rem 4rem" }}>
          <TextInput label="Project name" mb="md" />
          <TextInput label="Description" mb="xl" />
          <Button fullWidth>Create project</Button>
        </form>
      </Modal>

      <Button onClick={open}>Create project</Button>
    </>
  );
}

export default CreateProjectModal;
