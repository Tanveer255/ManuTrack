/* eslint-disable react-refresh/only-export-components */
/* eslint-disable react/prop-types */
"use client";

import * as React from "react";
import { Slot } from "@radix-ui/react-slot";
import { cva } from "class-variance-authority";

import { cn } from "@/lib/utils";
import {
  Tooltip,
  TooltipContent,
  TooltipProvider,
  TooltipTrigger,
} from "@/components/ui/tooltip";

const SIDEBAR_COOKIE_NAME = "sidebar:state";

const SidebarContext = (React.createContext < SidebarContext) | (null > null);

function useSidebar() {
  const context = React.useContext(SidebarContext);
  if (!context) {
    throw new Error("useSidebar must be used within a SidebarProvider");
  }
  return context;
}

function SidebarProvider({
  defaultOpen = true,
  open: openProp,
  onOpenChange: setOpenProp,
  className,
  children,
  ...props
}) {
  const [_open, _setOpen] = React.useState(defaultOpen);
  const open = openProp ?? _open;
  const setOpen = React.useCallback(
    (value) => {
      const openState = value;
      if (setOpenProp) {
        setOpenProp(openState);
      } else {
        _setOpen(openState);
      }
      document.cookie = `${SIDEBAR_COOKIE_NAME}=${openState}; path=/;`;
    },
    [setOpenProp]
  );

  const isMobile = React.useMemo(() => {
    if (typeof window === "undefined") return false;
    return window.innerWidth < 768;
  }, []);

  const toggleSidebar = React.useCallback(() => {
    setOpen(!open);
  }, [open, setOpen]);

  const state = open ? "expanded" : "collapsed";

  const contextValue = React.useMemo(
    () => ({
      state,
      open,
      setOpen,
      isMobile,
      toggleSidebar,
    }),
    [state, open, setOpen, isMobile, toggleSidebar]
  );

  return (
    <SidebarContext.Provider value={contextValue}>
      <TooltipProvider delayDuration={0}>
        <div
          className={cn("group/sidebar flex min-h-screen w-full", className)}
          {...props}
        >
          {children}
        </div>
      </TooltipProvider>
    </SidebarContext.Provider>
  );
}

function Sidebar({ collapsible = "none", className, children, ...props }) {
  const { state } = useSidebar();

  return (
    <div
      data-state={state}
      data-collapsible={collapsible}
      className={cn(
        "relative z-30 flex w-[250px] flex-col bg-sidebar transition-all duration-300 ease-in-out",
        "data-[state=collapsed]:w-[60px]",
        className
      )}
      {...props}
    >
      {children}
    </div>
  );
}

function SidebarHeader({ className, ...props }) {
  return <div className={cn("flex flex-col", className)} {...props} />;
}

function SidebarContent({ className, ...props }) {
  return (
    <div
      className={cn("flex flex-1 flex-col overflow-auto", className)}
      {...props}
    />
  );
}

function SidebarMenu({ className, ...props }) {
  return <div className={cn("flex flex-col", className)} {...props} />;
}

function SidebarMenuItem({ className, ...props }) {
  return <div className={cn("relative", className)} {...props} />;
}

const sidebarMenuButtonVariants = cva(
  "flex w-full items-center gap-2 rounded-lg p-2 text-sm font-medium outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus-visible:ring-2 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 [&>svg]:h-5 [&>svg]:w-5 [&>svg]:shrink-0",
  {
    variants: {
      variant: {
        default: "",
        ghost: "hover:bg-transparent hover:text-accent-foreground",
      },
    },
    defaultVariants: {
      variant: "default",
    },
  }
);

function SidebarMenuButton({
  className,
  variant,
  asChild = false,
  tooltip,
  ...props
}) {
  const { state } = useSidebar();
  const Comp = asChild ? Slot : "button";
  const isCollapsed = state === "collapsed";

  if (!tooltip || !isCollapsed) {
    return (
      <Comp
        className={cn(sidebarMenuButtonVariants({ variant }), className)}
        {...props}
      />
    );
  }

  return (
    <Tooltip>
      <TooltipTrigger asChild>
        <Comp
          className={cn(sidebarMenuButtonVariants({ variant }), className)}
          {...props}
        />
      </TooltipTrigger>
      <TooltipContent
        side="right"
        className="flex items-center gap-4"
        {...(typeof tooltip === "string" ? { children: tooltip } : tooltip)}
      />
    </Tooltip>
  );
}

// eslint-disable-next-line react/prop-types
function SidebarRail({ className, ...props }) {
  const { toggleSidebar } = useSidebar();

  return (
    <button
      className={cn(
        "absolute -right-[2px] top-1/2 z-20 h-8 w-1 -translate-y-1/2 cursor-col-resize rounded-none border-0 bg-slate-700 opacity-0 transition-opacity hover:opacity-100 group-hover/sidebar:opacity-100",
        className
      )}
      onClick={toggleSidebar}
      {...props}
    />
  );
}

export {
  Sidebar,
  SidebarContent,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuItem,
  SidebarMenuButton,
  SidebarProvider,
  SidebarRail,
  useSidebar,
};
