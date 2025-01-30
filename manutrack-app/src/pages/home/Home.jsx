import React from "react";
import SalesCard from "./components/SalesCard";
import { DollarSignIcon, FileQuestion, ListOrdered, User } from "lucide-react";
import DataCard from "./components/DataCard";
import BestSellerChart from "./components/BestSellerChart";
import { ServerUsageChart } from "./components/ServerUsageChart";

const cardData = [
  {
    title: "Support Questions",
    value: "23",
    icon: FileQuestion,
    unreadMessages: 14,
    action: "(View All)",
    primaryColor: "proto-primary",
  },
  {
    title: "Total Profit",
    value: "$ 14,890.3",
    icon: DollarSignIcon,
    action: "(Withdraw)",
    primaryColor: "proto-secondary",
  },
  {
    title: "Today's Orders",
    value: "38",
    icon: ListOrdered,
    action: "(Statement)",
    primaryColor: "proto-tertiary",
  },
  {
    title: "Today's Visitors",
    value: "3765",
    icon: User,
    action: "(Report)",
    primaryColor: "proto-quaternary",
  },
];

const Home = () => {
  return (
    <div className="grid grid-cols-1 gap-4 p-4 lg:grid-cols-2">
      <div className=" text-white rounded-lg">
        <SalesCard />
      </div>
      <div className=" text-white rounded-lg ">
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
          {cardData.map((card, index) => (
            <DataCard key={index} card={card} />
          ))}
        </div>
      </div>
      <div className="rounded-lg">
        <BestSellerChart />
      </div>
      <div className=" rounded-lg">
        <ServerUsageChart />
      </div>
    </div>
  );
};

export default Home;
