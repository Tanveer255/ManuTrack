import { Button } from "@/components/ui/button";
import { Download, Plus } from "lucide-react";

export function TasksPrimaryButtons() {
  return (
    <div className="flex gap-2">
      <Button variant="outline" className="space-x-1" onClick={() => {}}>
        <span>Import</span> <Download size={18} />
      </Button>
      <Button className="space-x-1" onClick={() => {}}>
        <span>Create</span> <Plus size={18} />
      </Button>
    </div>
  );
}
