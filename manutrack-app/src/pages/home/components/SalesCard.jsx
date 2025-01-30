import { Card } from "@/components/ui/card";
import GoalsPieChart from "./GoalsPieChart";
import SalesChart from "./SalesChart";

function SalesCard() {
  return (
    <Card className="min-h-48">
      <div className="grid grid-cols-1 lg:grid-cols-3 min-h-48 gap-4">
        <div className="rounded-lg lg:col-span-2">
          <SalesChart />
        </div>

        {/* Right Side Box */}
        <div className="rounded-lg min-h-48 sm:min-h-60 lg:min-h-full">
          <GoalsPieChart />
        </div>
      </div>
    </Card>
  );
}

export default SalesCard;
