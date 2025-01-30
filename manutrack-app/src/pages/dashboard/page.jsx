import { AreaChartComp } from "@/charts/AreaChart";
import { BarChartComp } from "@/charts/BarChart";
import { PieChartComp } from "@/charts/PieChart";
import { ModeToggle } from "@/components/mode-toggle";
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from "@/components/ui/breadcrumb";
import { Button } from "@/components/ui/button";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
//import exportToJson from "@/JSON/exportIntoJSON.jsx";
// import StatsPdf from "@/pdf/StatsPdf";
// import StatsXlsx from "@/xlsx/StatsXlsx";
import { PDFDownloadLink } from "@react-pdf/renderer";
import { useEffect, useState } from "react";

const fetchData = async () => {
  const response = await fetch("https://dummyjson.com/products");
  const data = await response.json();
  return data;
};

export default function Dashboard() {
  const [tableData, setTableData] = useState([]);

  useEffect(() => {
    fetchData().then((data) => setTableData(data));
  }, []);
  return (
    <SidebarInset>
      <header className="flex h-16 shrink-0 items-center gap-2 transition-[width,height] ease-linear group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12">
        <div className="flex items-center gap-2 px-4">
          <SidebarTrigger className="-ml-1" />
          <Separator orientation="vertical" className="mr-2 h-4" />
          <Breadcrumb>
            <BreadcrumbList>
              <BreadcrumbItem className="hidden md:block">
                <BreadcrumbLink href="/">Home</BreadcrumbLink>
              </BreadcrumbItem>
              <BreadcrumbSeparator className="hidden md:block" />
              <BreadcrumbItem>
                <BreadcrumbPage>Dashboard</BreadcrumbPage>
              </BreadcrumbItem>
            </BreadcrumbList>
          </Breadcrumb>
        </div>
      </header>
      <div className="flex flex-1 flex-col gap-4 p-4 pt-0">
        <div className="grid auto-rows-min gap-4 md:grid-cols-3">
          <div className="aspect-video rounded-xl bg-sidebar">
            <AreaChartComp />
          </div>
          <div className="aspect-video rounded-xl bg-sidebar">
            <BarChartComp />
          </div>
          <div className="aspect-video rounded-xl bg-sidebar">
            <PieChartComp />
          </div>
        </div>
        <div className="min-h-[100vh] flex-1 flex justify-around items-center rounded-xl bg-sidebar md:min-h-min">
          {/* <Button onClick={() => exportToJson(tableData)}>
            Export to JSON
          </Button> */}
          {/* <PDFDownloadLink
            document={<StatsPdf />}
            fileName="StatsPdf.pdf"
            className="bg-orange-500 hover:bg-orange-600 text-white font-semibold px-5 py-[10px] rounded-md transition duration-300"
          > */}
            {/* {({ loading }) =>
              loading ? "Loading document..." : "Download PDF"
            } */}
          {/* </PDFDownloadLink> */}
          {/* <StatsXlsx /> */}
        </div>
      </div>
    </SidebarInset>
  );
}
