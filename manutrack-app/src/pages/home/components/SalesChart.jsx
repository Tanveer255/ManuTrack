import { CartesianGrid, Line, LineChart, XAxis, YAxis } from "recharts";

import { CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  ChartContainer,
  ChartTooltip,
  ChartTooltipContent,
} from "@/components/ui/chart";
import { Button } from "@/components/ui/button";

const chartData = [
  { month: "January", desktop: 186 },
  { month: "February", desktop: 305 },
  { month: "March", desktop: 237 },
  { month: "April", desktop: 73 },
  { month: "May", desktop: 209 },
  { month: "June", desktop: 214 },
];

const chartConfig = {
  desktop: {
    label: "Desktop",
    color: "hsl(var(--chart-1))",
  },
};

function SalesChart() {
  return (
    <>
      <CardHeader>
        <CardTitle className="text-lg">
          Sales:
          <Button variant="outline" size="sm" className="ml-2">
            Proto Admin
          </Button>
        </CardTitle>
      </CardHeader>
      <CardContent className="h-48">
        <ChartContainer config={chartConfig} className="h-full w-full">
          <LineChart accessibilityLayer data={chartData} margin={{}}>
            <CartesianGrid vertical={false} />
            <XAxis
              dataKey="month"
              tickLine={false}
              axisLine={false}
              tickMargin={8}
              tickFormatter={(value) => value.slice(0, 3)}
            />
            <YAxis
              tickLine={false}
              axisLine={false}
              tickMargin={30}
              tickFormatter={(value) => `${value}`}
            />
            <ChartTooltip
              cursor={false}
              content={<ChartTooltipContent hideLabel />}
            />
            <Line
              dataKey="desktop"
              type="linear"
              stroke="#0088CC"
              strokeWidth={2}
              dot={false}
            />
          </LineChart>
        </ChartContainer>
      </CardContent>
    </>
  );
}

export default SalesChart;
