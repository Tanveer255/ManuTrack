import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { TasksPrimaryButtons } from "./TaskPrimaryButtons";
import { DataTable } from "./datatable/DataTable";
import { columns } from "./datatable/columns";
import { payments } from "@/config";

const DashboardTabs = () => {
  return (
    <div>
      <Tabs
        orientation="vertical"
        defaultValue="overview"
        className="space-y-4"
      >
        <div className="w-full overflow-x-auto pb-2">
          <TabsList>
            <TabsTrigger value="overview">Overview</TabsTrigger>
            <TabsTrigger value="analytics">Analytics</TabsTrigger>
            <TabsTrigger value="reports">Reports</TabsTrigger>
            <TabsTrigger value="notifications">Notifications</TabsTrigger>
          </TabsList>
        </div>
        <TabsContent value="overview" className="space-y-4">
          <div className="mb-2 flex items-center justify-between space-y-2 flex-wrap gap-x-4">
            <div>
              <h2 className="text-2xl font-bold tracking-tight">Tasks</h2>
              <p className="text-muted-foreground">
                Here&apos;s a list of your tasks for this month!
              </p>
            </div>
            <TasksPrimaryButtons />
          </div>
          <div className="-mx-4 flex-1 overflow-auto px-4 py-1 lg:flex-row lg:space-x-12 lg:space-y-0">
            <DataTable data={payments} columns={columns} />
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
};

export default DashboardTabs;
