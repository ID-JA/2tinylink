"use client";
import Link from "next/link";
import { Container, Group, Tabs, Burger, Skeleton } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import classes from "./Header.module.css";
import { useParams, usePathname } from "next/navigation";

export function HeaderTabs() {
  const [opened, { toggle }] = useDisclosure(false);

  return (
    <div className={classes.header}>
      <Container className={classes.mainSection} size="md">
        <Group justify="space-between">
          <span>2tinyLink</span>
          <Burger opened={opened} onClick={toggle} hiddenFrom="xs" size="sm" />
          <UserDropDown />
        </Group>
      </Container>
      <Container size="md">
        <NavTabs />
      </Container>
    </div>
  );
}

const UserDropDown = () => {
  // const { data: user } = useCurrentUserProfile();
  // const [userMenuOpened, setUserMenuOpened] = useState(false);

  return (
    <>
      {/* {user && user?.userName ? (
        <Menu
          width={260}
          position="bottom-end"
          transitionProps={{ transition: "pop-top-right" }}
          onClose={() => setUserMenuOpened(false)}
          onOpen={() => setUserMenuOpened(true)}
          withinPortal
        >
          <Menu.Target>
            <UnstyledButton
              className={cx(classes.user, {
                [classes.userActive]: userMenuOpened,
              })}
            >
              <Group gap={7}>
                <Avatar
                  src={
                    "https://raw.githubusercontent.com/mantinedev/mantine/master/.demo/avatars/avatar-5.png"
                  }
                  alt={user.userName}
                  radius="xl"
                  size={20}
                />
                <Text fw={500} size="sm" lh={1} mr={3}>
                  {user.userName}
                </Text>
                <IconChevronDown
                  style={{ width: rem(12), height: rem(12) }}
                  stroke={1.5}
                />
              </Group>
            </UnstyledButton>
          </Menu.Target>
          <Menu.Dropdown>
            <Menu.Label>Settings</Menu.Label>
            <Menu.Item
              leftSection={
                <IconSettings
                  style={{ width: rem(16), height: rem(16) }}
                  stroke={1.5}
                />
              }
            >
              Account settings
            </Menu.Item>
            <Menu.Item
              leftSection={
                <IconSwitchHorizontal
                  style={{ width: rem(16), height: rem(16) }}
                  stroke={1.5}
                />
              }
            >
              Change account
            </Menu.Item>
            <Menu.Item
              leftSection={
                <IconLogout
                  style={{ width: rem(16), height: rem(16) }}
                  stroke={1.5}
                />
              }
            >
              Logout
            </Menu.Item>
          </Menu.Dropdown>
        </Menu>
      ) : (
        <Skeleton height={40} width={150} />
      )} */}
      <Skeleton height={40} width={150} />
    </>
  );
};

const NavTabs = () => {
  const { slug } = useParams() as { slug?: string };
  const pathname = usePathname();

  const tabs = [
    { name: "Links", href: `/${slug}` },
    { name: "Settings", href: `/${slug}/settings` },
  ];
  const items = tabs.map(({ name, href }) => {
    return (
      <Tabs.Tab
        value={name}
        key={href}
        component={(props: any) => <Link {...props} href={href} />}
      >
        {name}
      </Tabs.Tab>
    );
  });

  if (pathname === "/projects") return null;

  return (
    <Tabs
      defaultValue="Links"
      variant="outline"
      visibleFrom="sm"
      classNames={{
        root: classes.tabs,
        list: classes.tabsList,
        tab: classes.tab,
      }}
    >
      <Tabs.List>{items}</Tabs.List>
    </Tabs>
  );
};
