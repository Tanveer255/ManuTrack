/* eslint-disable react/prop-types */
import {
  Card,
  CardContent,
  CardDescription,
  CardTitle,
} from "@/components/ui/card";

const DashboardCard = ({ card }) => {
  return (
    <Card className="p-4 border-l-4 border-primary">
      <CardContent className="p-0 flex items-center justify-between">
        <div className="p-3 flex justify-between items-center">
          <card.icon className="w-8 h-8 text-primary" />
        </div>
        <div className="flex flex-col gap-2 pr-2">
          <CardTitle className="text-md whitespace-nowrap tracking-tight">
            {card.title}
          </CardTitle>
          <CardDescription className="font-bold text-lg text-black">
            {card.numberOfContacts}
          </CardDescription>
        </div>
      </CardContent>
    </Card>
  );
};

export default DashboardCard;
