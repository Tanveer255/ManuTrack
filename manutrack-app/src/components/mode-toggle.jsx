import { useTheme } from "@/components/theme-provider";

export function ModeToggle() {
  const { theme, setTheme } = useTheme();

  const options = [
    {
      id: "light",
      label: "Light",
      icon: (
        <div className="space-y-2 rounded-lg bg-[#ecedef] p-2">
          <div className="space-y-2 rounded-md bg-white p-2 shadow-sm">
            <div className="h-2 w-[80px] rounded-lg bg-[#ecedef]" />
            <div className="h-2 w-[100px] rounded-lg bg-[#ecedef]" />
          </div>
          <div className="flex items-center space-x-2 rounded-md bg-white p-2 shadow-sm">
            <div className="h-4 w-4 rounded-full bg-[#ecedef]" />
            <div className="h-2 w-[100px] rounded-lg bg-[#ecedef]" />
          </div>
          <div className="flex items-center space-x-2 rounded-md bg-white p-2 shadow-sm">
            <div className="h-4 w-4 rounded-full bg-[#ecedef]" />
            <div className="h-2 w-[100px] rounded-lg bg-[#ecedef]" />
          </div>
        </div>
      ),
    },
    {
      id: "dark",
      label: "Dark",
      icon: (
        <div className="space-y-2 rounded-lg bg-slate-950 p-2">
          <div className="space-y-2 rounded-md bg-slate-800 p-2 shadow-sm">
            <div className="h-2 w-[80px] rounded-lg bg-slate-400" />
            <div className="h-2 w-[100px] rounded-lg bg-slate-400" />
          </div>
          <div className="flex items-center space-x-2 rounded-md bg-slate-800 p-2 shadow-sm">
            <div className="h-4 w-4 rounded-full bg-slate-400" />
            <div className="h-2 w-[100px] rounded-lg bg-slate-400" />
          </div>
          <div className="flex items-center space-x-2 rounded-md bg-slate-800 p-2 shadow-sm">
            <div className="h-4 w-4 rounded-full bg-slate-400" />
            <div className="h-2 w-[100px] rounded-lg bg-slate-400" />
          </div>
        </div>
      ),
    },
  ];

  return (
    <div className="space-y-2">
      <div className="flex items-center gap-4">
        {options.map((option) => {
          return (
            <label
              key={option.id}
              className={`
                w-[10.5rem] cursor-pointer rounded-md border p-4 text-center transition 
                  ${
                    theme === option.id
                      ? theme === "light"
                        ? "border-black bg-muted"
                        : "border-muted bg-black"
                      : option.id === "light" && theme === "dark"
                      ? "border-black"
                      : "border-muted hover:border-accent"
                  }
              `}
            >
              <input
                type="radio"
                name="theme"
                value={option.id}
                checked={theme === option.id}
                onChange={(e) => {
                  e.preventDefault();
                  setTheme(option.id);
                }}
                className="sr-only"
              />
              {option.icon}
              <span className="mt-2 block text-sm font-medium">
                {option.label}
              </span>
            </label>
          );
        })}
      </div>
    </div>
  );
}
