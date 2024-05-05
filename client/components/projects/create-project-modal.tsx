"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

import { axios } from "@/utils";
import {
  Box,
  Button,
  Collapse,
  Divider,
  Modal,
  TagsInput,
  TextInput,
  Title,
} from "@mantine/core";
import { useDisclosure, useMediaQuery } from "@mantine/hooks";
import { useMutation } from "@tanstack/react-query";

function CreateProjectModal() {
  const [opened, { open, close }] = useDisclosure(false);
  const [openedInviteUsers, { toggle: toggleOpenInviteUsers }] =
    useDisclosure(false);

  const isMobile = useMediaQuery("(max-width: 50em)");

  const router = useRouter();

  const [data, setData] = useState<{
    name: string;
    description: string;
  }>({
    name: "",
    description: "",
  });

  const [emails, setEmails] = useState<string[]>([]);

  const { name, description } = data;

  const mutation = useMutation({
    mutationKey: ["create-project"],
    mutationFn: async (data: { name: string; description: string }) => {
      const response = await axios().post("/projects", data);
      if (emails.length) {
        await axios().post(`/projects/invite`, {
          projectId: response.data,
          emails,
        });
      }
      return response.data;
    },
    onSuccess: (projectId) => {
      router.push(`/projects/${projectId}`);
      close();
    },
  });

  return (
    <>
      <Modal
        padding="0px"
        radius="md"
        opened={opened}
        onClose={close}
        withCloseButton={isMobile}
        centered
        fullScreen={isMobile}
        transitionProps={{ transition: "fade", duration: 200 }}
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
        <form
          onSubmit={(e) => {
            e.preventDefault();
            mutation.mutate(data);
          }}
          style={{ padding: "2rem 4rem" }}
        >
          <TextInput
            required
            mb="md"
            name="name"
            label="Project name"
            value={name}
            onChange={(e) => {
              setData({ ...data, name: e.target.value });
            }}
          />
          <TextInput
            required
            mb="xl"
            name="description"
            label="Description"
            value={description}
            onChange={(e) => {
              setData({ ...data, description: e.target.value });
            }}
          />
          <Box maw={400} mx="auto" mb="xl">
            <Divider
              onClick={toggleOpenInviteUsers}
              my="xs"
              label="You want to Invite member?"
              labelPosition="center"
              style={{ cursor: "pointer" }}
            />

            <Collapse in={openedInviteUsers}>
              <TagsInput
                type="email"
                label="Emails"
                placeholder="Enter email"
                value={emails}
                onChange={(value) => setEmails(value)}
              />
            </Collapse>
          </Box>
          <Button fullWidth type="submit" loading={mutation.isPending}>
            Create project
          </Button>
        </form>
      </Modal>

      <Button onClick={open}>Create project</Button>
    </>
  );
}

export default CreateProjectModal;
