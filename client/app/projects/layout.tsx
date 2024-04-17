import { HeaderTabs } from "@/components/Header";

function DashboardLayout({ children }: { children: React.ReactNode }) {
  return (
    <div>
      <HeaderTabs />
      {children}
    </div>
  );
}

export default DashboardLayout;
