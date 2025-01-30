import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Separator } from "@/components/ui/separator";
import { cn } from "@/lib/utils";
import React from "react";

const colorClasses = {
  "proto-primary": "bg-proto-primary border-proto-primary",
  "proto-secondary": "bg-proto-secondary border-proto-secondary",
  "proto-tertiary": "bg-proto-tertiary border-proto-tertiary",
  "proto-quaternary": "bg-proto-quaternary border-proto-quaternary",
};

const DataCard = ({ card }) => {
  return (
    <div class=" ">
      <Card className={`w-full `}>
        <CardContent
          className={cn(
            "w-full flex items-center p-4 h-32 border-l-4 rounded-lg bg-white",
            colorClasses[card.primaryColor].split(" ")[1]
          )}
        >
          <div className="w-full flex justify-between space-x-4">
            <div className="flex items-center gap-4">
              <card.icon
                className={cn(
                  "w-20 h-20 rounded-full p-4 text-white",
                  colorClasses[card.primaryColor].split(" ")[0]
                )}
              ></card.icon>
            </div>
            <div className="w-[80%]">
              <CardTitle className="text-sm">{card.title}</CardTitle>
              <p className="font-extrabold text-2xl">
                {card.value}
                {card?.unreadMessages && (
                  <span className="ml-2 text-xs font-light text-proto-primary">
                    {"("}
                    {card?.unreadMessages} unread {")"}
                  </span>
                )}
              </p>
              <Separator className="my-2" />
              <CardDescription className="text-right">
                {card.action}
              </CardDescription>
            </div>
          </div>
        </CardContent>
      </Card>
    </div>
  );
};

export default DataCard;
