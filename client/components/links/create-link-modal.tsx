"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";

import { axios } from "@/utils";
import {
  ActionIcon,
  Button,
  Group,
  Input,
  Modal,
  TextInput,
  Title,
  Tooltip,
} from "@mantine/core";
import { useDisclosure, useMediaQuery } from "@mantine/hooks";
import { useMutation } from "@tanstack/react-query";
import { IconArrowsShuffle } from "@tabler/icons-react";

function CreateLinkModal() {
  const [opened, { open, close }] = useDisclosure(false);
  const isMobile = useMediaQuery("(max-width: 50em)");

  const router = useRouter();

  const [data, setData] = useState<{
    url: string;
    shortUrl: string;
  }>({
    url: "",
    shortUrl: "",
  });

  const { url, shortUrl } = data;

  const mutation = useMutation({
    mutationKey: ["create-link"],
    mutationFn: async (data: any) => {
      const response = await axios().post("/projects", data);
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
            Create new link
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
            name="url"
            label="URL"
            value={url}
            onChange={(e) => {
              setData({ ...data, url: e.target.value });
            }}
          />
          <Input.Wrapper mb="xl">
            <Input.Label w="100%">
              <Group justify="space-between">
                <span>Short URL</span>
                <Tooltip label="Generate random key">
                  <ActionIcon
                    variant="subtle"
                    color="gray"
                    size="sm"
                    aria-label="Settings"
                  >
                    <IconArrowsShuffle
                      style={{ width: "70%", height: "70%" }}
                      stroke={1.5}
                    />
                  </ActionIcon>
                </Tooltip>
              </Group>
            </Input.Label>
            <Input
              required
              name="shortUrl"
              placeholder="short-url"
              value={shortUrl}
              onChange={(e) => {
                setData({ ...data, shortUrl: e.target.value });
              }}
            />
          </Input.Wrapper>
          <Button fullWidth type="submit" loading={mutation.isPending}>
            Create link
          </Button>
        </form>
      </Modal>

      <Button onClick={open}>Create link</Button>
    </>
  );
}

export default CreateLinkModal;
